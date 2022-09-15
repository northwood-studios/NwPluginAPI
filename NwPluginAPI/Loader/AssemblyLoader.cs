namespace PluginAPI.Loader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using PluginAPI.Core;
    using PluginAPI.Core.Extensions;
    using PluginAPI.Helpers;
    using PluginAPI.Loader.Features;

	/// <summary>
	/// Manages initialization of plugin system and loading of plugins.
	/// </summary>
	public static class AssemblyLoader
	{
		/// <summary>
		/// A list of all recognized and loaded plugins.
		/// </summary>
		public static Dictionary<Assembly, Dictionary<Type, PluginHandler>> Plugins { get; } = new Dictionary<Assembly, Dictionary<Type, PluginHandler>>();

		/// <summary>
		/// A list of all installed and enabled plugins.
		/// </summary>
		public static IEnumerable<PluginHandler> InstalledPlugins => Plugins.Values.SelectMany(p => p.Values);

		/// <summary>
		/// A list of all recognized and loaded dependencies.
		/// </summary>
		public static List<Assembly> Dependencies { get; } = new List<Assembly>();

		/// <summary>
		/// Whether the Loader has been run already, prevents it from being ran multiple times during runtime.
		/// </summary>
		public static bool IsLoaded { get; set; } = false;

		/// <summary>
		/// Ran on server startup, loads plugins and dependencies and all main features from our API.
		/// </summary>
		public static void Initialize()
		{
			if (IsLoaded)
				return;

			Log.Info("<---<  Startup of plugin system...  <---<");
			Log.Info("Loading of dependencies and plugins in progress...");
			IsLoaded = true;
			Paths.Setup();
			FactoryManager.Init();

			Log.Info("<---<    Loading global plugins     <---<");
			// Load plugins from the Global directory inside "configs".
			LoadDependencies(Paths.GlobalPlugins.Dependencies);
			LoadPlugins(Paths.GlobalPlugins);

			Log.Info("<---<     Loading server plugins    <---<");
			// Load plugins from the [Server port] directory inside "configs".
			LoadDependencies(Paths.LocalPlugins.Dependencies);
			LoadPlugins(Paths.LocalPlugins);

			Log.Info("<---<       Start all plugins       <---<");
			foreach (var plugin in Plugins.Values)
			{
				foreach (var pluginType in plugin.Values)
				{
					try
					{
						pluginType.Load();
					}
					catch (Exception ex)
					{
						Log.Error($"Failed loading plugin &6{pluginType.PluginName}&r.\n{ex}");
					}
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

            foreach (string dependencyPath in files)
            {
                if (!TryGetAssembly(dependencyPath, out Assembly assembly))
					continue;

                foreach (var type in assembly.GetTypes())
				{
					if (!type.IsValidEntrypoint()) continue;

                    if (!Plugins.ContainsKey(assembly)) Plugins.Add(assembly, new Dictionary<Type, PluginHandler>());

					if (!Plugins[assembly].ContainsKey(type))
					{
						Plugins[assembly].Add(type, new PluginHandler(directory, type));
						successes++;
					}
				}
			}
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

			Log.Info($"Loading &2{files.Length}&r dependencies...", "Loader");

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
					Log.Error($"Failed loading dependency &2{Path.GetFileNameWithoutExtension(dependencyPath)}&r.\n{ex}", "Loader");
					continue;
				}
				successes++;
			}

			Log.Info($"Loaded &2{successes}&r/&2{files.Length}&r dependencies", "Loader");
		}

		/// <summary>
		/// Attempts to load an assembly from a specified path.
		/// </summary>
		/// <param name="path">The path to load the assembly from.</param>
		/// <param name="assembly">The loaded assembly, if the method returns false, it will be null.</param>
		/// <returns>Returns whether the assembly was loaded correctly.</returns>
		private static bool TryGetAssembly(string path, out Assembly assembly)
		{
			try
			{
				return (assembly = Assembly.Load(File.ReadAllBytes(path))) != null;
			}
			catch (Exception e)
			{
				Log.Error($"Attempting to load assembly at \"&2{path}&r\" caused an exception.\n{e}");
			}

			assembly = null;
			return false;
		}
	}
}
