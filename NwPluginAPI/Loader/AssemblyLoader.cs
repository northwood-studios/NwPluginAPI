namespace PluginAPI.Loader
{
	using System.IO.Compression;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using Core;
	using Core.Extensions;
	using Helpers;
	using Features;
	using Log = Core.Log;
	using PluginAPI.Events;

	/// <summary>
	/// Manages initialization of plugin system and loading of plugins.
	/// </summary>
	public static class AssemblyLoader
	{
		private static Assembly _mainAssembly;

		/// <summary>
		/// Gets a main assembly of game.
		/// </summary>
		public static Assembly MainAssembly
		{
			get
			{
				if (_mainAssembly == null) _mainAssembly = typeof(GameCore.Console).Assembly;
				return _mainAssembly;
			}
		}

		/// <summary>
		/// Gets a list of all recognized and loaded plugins.
		/// </summary>
		public static Dictionary<Assembly, Dictionary<Type, PluginHandler>> Plugins { get; } = new Dictionary<Assembly, Dictionary<Type, PluginHandler>>();

		internal static Dictionary<object, Assembly> PluginToAssembly { get; } = new Dictionary<object, Assembly>();

		/// <summary>
		/// Gets a list of all installed and enabled plugins.
		/// </summary>
		public static IEnumerable<PluginHandler> InstalledPlugins => Plugins.Values.SelectMany(p => p.Values);

		/// <summary>
		/// Gets a list of all recognized and loaded dependencies.
		/// </summary>
		public static List<Assembly> Dependencies { get; } = new List<Assembly>();

		/// <summary>
		/// Whether the loader has been run already.
		/// <remarks>This exists to prevent the loader from being ran multiple times in one session.</remarks>
		/// </summary>
		public static bool IsLoaded { get; set; } = false;

		/// <summary>
		/// Ran on server startup, loads plugins and dependencies and all main features from the API.
		/// </summary>
		public static void Initialize()
		{
			if (IsLoaded)
				return;

			if (StartupArgs.Args.Any(arg => string.Equals(arg, "-disableAnsiColors", StringComparison.OrdinalIgnoreCase)))
				Log.DisableBetterColors = true;

			Log.Info("<---<  Startup of plugin system...  <---<");
			Log.Info("Loading of dependencies and plugins in progress...");
			IsLoaded = true;

			Paths.Setup();
			FactoryManager.Init();
			EventManager.Init();

			Log.Info("<---<    Loading global plugins     <---<");
			// Load plugins from the Global directory inside "configs".
			LoadDependencies(Paths.GlobalPlugins.Dependencies);
			LoadPlugins(Paths.GlobalPlugins);

			Log.Info("<---<     Loading server plugins    <---<");
			// Load plugins from the [Server port] directory inside "configs".
			LoadDependencies(Paths.LocalPlugins.Dependencies);
			LoadPlugins(Paths.LocalPlugins);

			Log.Info("<---<        Load all plugins       <---<");

			foreach (var plugin in Plugins.Values.SelectMany(x => x.Values).OrderBy(x => x.LoadPriority))
			{
				try
				{
					plugin.Load();
				}
				catch (Exception ex)
				{
					Log.Error($"Failed loading plugin &6{plugin.PluginName}&r.\n{ex}");
				}
			}

			Log.Info("<---<    Plugin system is ready !    <---<");
		}

		/// <summary>
		/// Load plugins from a specified directory.
		/// </summary>
		/// <param name="directory">The paths from which to load plugins and their configs from.</param>
		private static void LoadPlugins(PluginDirectory directory)
		{
			string[] files = Directory.GetFiles(directory.Plugins, "*.dll");

			Log.Info($"Loading &2{files.Length}&r plugins...");
			int successes = 0;

			var loadedAssemblies = AppDomain.CurrentDomain
				.GetAssemblies()
				.ToDictionary(x => x.GetName().Name, x => x.GetName().Version);

			var loadedPluginAssemblies = new List<PluginAssemblyInformation>();
			var pluginsToInitialize = new List<PluginAssemblyInformation>();

			foreach (string pluginPath in files)
			{
				if (!TryGetAssembly(pluginPath, out Assembly assembly))
					continue;
				loadedPluginAssemblies.Add(new PluginAssemblyInformation(pluginPath, assembly));
				loadedAssemblies[assembly.GetName().Name] = assembly.GetName().Version;
			}

			foreach (var pluginInfo in loadedPluginAssemblies)
			{
				var missingDependencies = pluginInfo.Assembly
					.GetReferencedAssemblies()
					.Where(x => !loadedAssemblies.ContainsKey(x.Name))
					.ToDictionary(x => x.Name, x => x.Version);
				var versionMismatch = pluginInfo.Assembly
					.GetReferencedAssemblies()
					.Where(x => loadedAssemblies.ContainsKey(x.Name) && loadedAssemblies[x.Name] != x.Version)
					.ToDictionary(x => x.Name, x => (Expected: x.Version, Actual: loadedAssemblies[x.Name]));

				try
				{
					if (missingDependencies.Count != 0)
						ResolveAssemblyEmbeddedResources(pluginInfo.Assembly, missingDependencies);
					if (missingDependencies.Count != 0)
					{
						Log.Error($"Failed loading plugin &2{Path.GetFileNameWithoutExtension(pluginInfo.Path)}&r, missing dependencies\n&2{string.Join("\n", missingDependencies.Select(x => "&r - &2" + x.Key + " v" + x.Value.ToString(3) + "&r"))}", "Loader");
						continue;
					}

					pluginInfo.Types = pluginInfo.Assembly.GetTypes();
					pluginsToInitialize.Add(pluginInfo);
				}
				catch (Exception e)
				{
					if (missingDependencies.Count != 0)
					{
						Log.Error($"Failed loading plugin &2{Path.GetFileNameWithoutExtension(pluginInfo.Path)}&r, missing dependencies\n&2{string.Join("\n", missingDependencies.Select(x => "&r - &2" + x.Key + " v" + x.Value.ToString(3) + "&r"))}\n\n{e}", "Loader");
					}
					else
					{
						Log.Error("Failed loading plugin &2" + Path.GetFileNameWithoutExtension(pluginInfo.Path) + "&r, " + e, "Loader");
					}

					continue;
				}

				if (versionMismatch.Count != 0)
				{
					Log.Warning($"Dependency version mismatch in plugin &2{Path.GetFileNameWithoutExtension(pluginInfo.Path)}&r\n&2{string.Join("\n", versionMismatch.Select(x => "&r - &2" + x.Key + " v" + x.Value.Actual.ToString(3) + " (expected version by plugin: " + x.Value.Expected.ToString(3) + ")" + "&r"))}", "Loader");
				}
			}

			Log.Info($"Initializing &2{pluginsToInitialize.Count}&r plugins...");
			foreach (var pluginInfo in pluginsToInitialize)
			{
				var pluginPath = pluginInfo.Path;
				var assembly = pluginInfo.Assembly;
				var types = pluginInfo.Types;
				foreach (var entryType in types)
				{
					try
					{
						if (!entryType.IsValidEntrypoint()) continue;
					}
					catch (Exception ex)
					{
						Log.Error($"Failed checking entrypoint for plugin &2{Path.GetFileNameWithoutExtension(pluginPath)}&r.\n{ex}");
						continue;
					}

					if (!Plugins.ContainsKey(assembly)) Plugins.Add(assembly, new Dictionary<Type, PluginHandler>());

					if (!Plugins[assembly].ContainsKey(entryType))
					{
						object plugin = null;
						try
						{
							plugin = Activator.CreateInstance(entryType);
						}
						catch (Exception ex)
						{
							Log.Error($"Failed creating instance of plugin &2{Path.GetFileNameWithoutExtension(pluginPath)}&r.\n{ex}", "Loader");
							continue;
						}

						PluginToAssembly.Add(plugin, assembly);

						Plugins[assembly].Add(entryType, new PluginHandler(directory, plugin, entryType, types)
						{
							PluginFilePath = pluginPath
						});
						successes++;
					}
				}
			}

			if (successes > 0)
				CustomNetworkManager.Modded = true;

			Log.Info($"Loaded &2{successes}&r/&2{files.Length}&r plugins.");
		}

		/// <summary>
		/// Load dependencies from a specified directory.
		/// </summary>
		/// <param name="path">The path from which to load the dependencies.</param>
		private static void LoadDependencies(string path)
		{
			int successes = 0;
			string[] files = Directory.GetFiles(path, "*.dll");

			Log.Info($"Loading &2{files.Length}&r dependencies...");

			foreach (string dependencyPath in files)
			{
				if (!TryGetAssembly(dependencyPath, out Assembly assembly))
					continue;

				try
				{
					Dependencies.Add(assembly);
				}
				catch (Exception ex)
				{
					Log.Error($"Failed loading dependency &2{Path.GetFileNameWithoutExtension(dependencyPath)}&r.\n{ex}");
					continue;
				}

				successes++;
			}

			Log.Info($"Loaded &2{successes}&r/&2{files.Length}&r dependencies");
		}

		/// <summary>
		/// Attempts to load an assembly from a specified path.
		/// </summary>
		/// <param name="path">The path to load the assembly from.</param>
		/// <param name="assembly">The loaded assembly, if the method returns false, it will be null.</param>
		/// <returns>Returns whether or not the assembly was loaded correctly.</returns>
		private static bool TryGetAssembly(string path, out Assembly assembly)
		{
			try
			{
				assembly = Assembly.Load(File.ReadAllBytes(path));
				return true;
			}
			catch (Exception e)
			{
				Log.Error($"Attempting to load assembly at \"&2{path}&r\" caused an exception.\n{e}");
			}

			assembly = null;
			return false;
		}

		/// <summary>
		/// Attempts to load Embedded assemblies (compressed) from the target
		/// </summary>
		/// <param name="target">Assembly to check for embedded assemblies</param>
		/// <param name="missingDependencies"></param>
		private static void ResolveAssemblyEmbeddedResources(Assembly target, Dictionary<string, Version> missingDependencies)
		{
			Log.Debug($"Attempting to load embedded resources for {target.FullName}", Log.DebugMode);


			var resourceNames = target.GetManifestResourceNames();
			foreach (var name in resourceNames)
			{
				Log.Debug($"Found {name}", Log.DebugMode);
				if (name.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
				{
					using (MemoryStream stream = new MemoryStream())
					{
						Log.Debug($"Loading {name}", Log.DebugMode);
						var dataStream = target.GetManifestResourceStream(name);
						if (dataStream == null)
						{
							Log.Error($"Unable to resolve {name} Stream was null");
							continue;
						}

						dataStream.CopyTo(stream);
						var assemblyName = Assembly.Load(stream.ToArray()).GetName();
						missingDependencies.Remove(assemblyName.Name);
						Log.Debug($"Loaded {name}", Log.DebugMode);
					}
				}
				else if (name.EndsWith(".dll.compressed", StringComparison.OrdinalIgnoreCase))
				{
					var dataStream = target.GetManifestResourceStream(name);
					if (dataStream == null)
					{
						Log.Error($"Unable to resolve {name} Stream was null");
						continue;
					}

					using (DeflateStream stream = new DeflateStream(dataStream, CompressionMode.Decompress))
					using (MemoryStream memStream = new MemoryStream())
					{
						Log.Debug($"Loading {name}", Log.DebugMode);
						stream.CopyTo(memStream);
						var assemblyName = Assembly.Load(memStream.ToArray()).GetName();
						missingDependencies.Remove(assemblyName.Name);
						Log.Debug($"Loaded {name}", Log.DebugMode);
					}
				}
			}
		}
	}
}