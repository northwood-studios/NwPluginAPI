namespace PluginAPI.Core
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	using Attributes;
	using CommandSystem;
	using Loader.Features;
	using PluginAPI.Commands;
	using PluginAPI.Enums;
	using PluginAPI.Loader;
	using Serialization;
	using Directory = System.IO.Directory;
	using File = System.IO.File;

	/// <summary>
	/// Handles a plugin.
	/// </summary>
	public class PluginHandler
	{
		private static readonly string UnknownName = "Unknown";
		private static readonly string UnknownVersion = "0.0.0";

		private readonly string _pluginDirectory;
		private readonly string _mainConfigPath;

        private readonly PluginEntryPoint _entryInfo;

        private readonly MethodInfo _entryPoint;
        private readonly MethodInfo _onUnload;

		private readonly object _plugin;
		private readonly Type _pluginType;

		/// <summary>
		/// Gets plugin handler.
		/// </summary>
		/// <param name="plugin">The plugin.</param>
		/// <returns>The Plugin handler.</returns>
		public static PluginHandler Get(object plugin)
		{
			if (!AssemblyLoader.PluginToAssembly.TryGetValue(plugin, out Assembly ass)) return null;

			if (!AssemblyLoader.Plugins.TryGetValue(ass, out Dictionary<Type, PluginHandler> handlers)) return null;

			if (!handlers.TryGetValue(plugin.GetType(), out PluginHandler handler)) return null;

			return handler;
		}

		/// <summary>
		/// Gets the loading priority.
		/// </summary>
		public byte LoadPriority { get; } = 128;

		/// <summary>
		/// Gets the name of the plugin.
		/// </summary>
		public string PluginName => _entryInfo?.Name ?? _pluginType.FullName;

		/// <summary>
		/// Gets the version of the plugin.
		/// </summary>
		public string PluginVersion => _entryInfo?.Version ?? UnknownVersion;

		/// <summary>
		/// Gets the description of the plugin.
		/// </summary>
		public string PluginDescription => _entryInfo?.Description ?? UnknownName;

		/// <summary>
		/// Gets the author of the plugin.
		/// </summary>
		public string PluginAuthor => _entryInfo?.Author ?? UnknownName;

		/// <summary>
		/// Gets the path of plugin file. ( default name: pluginName.dll )
		/// </summary>
		public string PluginFilePath { get; internal set; }

		/// <summary>
		/// Gets the path of plugin directory.
		/// </summary>
		public string PluginDirectoryPath => _pluginDirectory;

		/// <summary>
		/// Gets the path of main plugin config. ( default name: config.yml )
		/// </summary>
		public string MainConfigPath => _mainConfigPath;

		/// <summary>
		/// Unloads the plugin.
		/// </summary>
		public void Unload()
		{
            if (_onUnload == null)
            {
                Log.Warning($"Plugin &2{PluginName}&r has missing unload method!");
                return;
            }

            try
			{
				_onUnload.Invoke(_plugin, null);
			}
			catch (Exception ex)
			{
				Log.Error($"Failed unloading plugin &2{PluginName}&r!\n{ex}");
			}
		}

		/// <summary>
		/// Loads the plugin.
		/// </summary>
		public void Load()
		{
			if (_entryPoint == null)
			{
				Log.Error($"Failed loading plugin &2{PluginName}&r, invalid entrypoint!");
				return;
			}

			try
			{
				_entryPoint.Invoke(_plugin, null);
			}
			catch (Exception ex)
			{
				Log.Error($"Failed loading plugin &2{_entryInfo.Name}&r,\n{ex}");
			}
		}

		/// <summary>
		/// Loads the plugin config.
		/// </summary>
		/// <param name="plugin">The class location of config field.</param>
		/// <param name="configField">The name of config field.</param>
		public void LoadConfig(object plugin, string configField)
		{
			var field = plugin.GetType().GetField(configField);
			if (field == null) return;

			var attribute = field.GetCustomAttribute<Attribute>();

			if (!(attribute is PluginConfig cfg)) return;

			string targetPath = string.IsNullOrEmpty(cfg.ConfigPath) ? _mainConfigPath : Path.Combine(PluginDirectoryPath, cfg.ConfigPath);

			if (!Directory.Exists(Path.GetDirectoryName(targetPath))) Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

			if (!File.Exists(targetPath))
			{
				LoadDefaultConfig(plugin, configField);
				Log.Debug($"Created missing config file for &2{PluginName}&r.", Log.DebugMode);
			}
			else
			{
				object config;
				try
				{
					config = YamlParser.Deserializer.Deserialize(File.ReadAllText(targetPath), field.FieldType);
				}
				catch(Exception ex)
				{
					Log.Error($"Failed deserializing config file for &2{PluginName}&r,\n{ex}");
					return;
				}

				field.SetValue(plugin, config);
				File.WriteAllText(targetPath, YamlParser.Serializer.Serialize(config));

				Log.Debug($"Loaded config file for &2{PluginName}&r.", Log.DebugMode);
			}	
		}
		/// <summary>
		/// Loads the default plugin config.
		/// </summary>
		/// <param name="plugin">The class location of config field.</param>
		/// <param name="configField">The name of config field.</param>
		public void LoadDefaultConfig(object plugin, string configField)
		{
			var field = plugin.GetType().GetField(configField);
			if (field == null) return;

			var attribute = field.GetCustomAttribute<Attribute>();

			if (!(attribute is PluginConfig cfg)) return;

			string targetPath = string.IsNullOrEmpty(cfg.ConfigPath) ? _mainConfigPath : Path.Combine(PluginDirectoryPath, cfg.ConfigPath);

			if (!Directory.Exists(Path.GetDirectoryName(targetPath))) Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

			var defaultConfig = Activator.CreateInstance(field.FieldType);
			field.SetValue(plugin, defaultConfig);

			File.WriteAllText(targetPath, YamlParser.Serializer.Serialize(defaultConfig));
		}

		/// <summary>
		/// Saves the plugin config.
		/// </summary>
		/// <param name="plugin">The class location of config field.</param>
		/// <param name="configField">The name of config field.</param>
		public void SaveConfig(object plugin, string configField)
		{
			var field = plugin.GetType().GetField(configField);
			if (field == null) return;

			var attribute = field.GetCustomAttribute<Attribute>();

			if (!(attribute is PluginConfig cfg)) return;

			string targetPath = string.IsNullOrEmpty(cfg.ConfigPath) ? _mainConfigPath : Path.Combine(PluginDirectoryPath, cfg.ConfigPath);

			if (!Directory.Exists(Path.GetDirectoryName(targetPath))) Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

			File.WriteAllText(targetPath, YamlParser.Serializer.Serialize(field.GetValue(plugin)));

			Log.Debug($"Saved config file for &2{PluginName}&r.", Log.DebugMode);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginHandler"/> class.
		/// </summary>
		/// <param name="directory">The directory of plugin.</param>
		/// <param name="plugin">The plugin object.</param>
		/// <param name="pluginType">The type of plugin.</param>
		/// <param name="types">The all types in plugin.</param>
		public PluginHandler(PluginDirectory directory, object plugin, Type pluginType, Type[] types)
		{
			_plugin = plugin;
			_pluginType = pluginType;

			foreach (var method in _pluginType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				foreach(var attribute in method.GetCustomAttributes<Attribute>())
				{
					switch (attribute)
					{
						case PluginPriority priority:
							LoadPriority = priority.Priority;
							break;
						case PluginEntryPoint pluginEntryPoint:
							_entryPoint = method;
							_entryInfo = pluginEntryPoint;
							break;
						case PluginUnload _:
							_onUnload = method;
							break;
					}
				}
			}

			if (_entryInfo == null)
			{
                Log.Error($"Missing entrypoint for plugin &2{PluginName}&r!");
                return;
			}

			_pluginDirectory = Path.Combine(directory.Plugins, PluginName);
			_mainConfigPath = Path.Combine(_pluginDirectory, "config.yml");

			foreach (var type in types)
			{
				if (!type.IsClass) continue;

				if (!typeof(ICommand).IsAssignableFrom(type)) continue;

				foreach (var attributeData in type.GetCustomAttributesData())
				{
					if (attributeData.AttributeType != typeof(CommandHandlerAttribute)) continue;

					CommandsManager.RegisterCommand(this, (Type)attributeData.ConstructorArguments[0].Value, type);
				}
			}

			if (!Directory.Exists(_pluginDirectory))
			{
                Directory.CreateDirectory(_pluginDirectory);
                Log.Debug($"Created missing plugin directory for \"&2{PluginName}&r\".", Log.DebugMode);
            }

            foreach (var field in _pluginType.GetFields())
			{
				foreach(var attribute in field.GetCustomAttributes<Attribute>())
				{
					switch (attribute)
					{
						case PluginConfig _:
							LoadConfig(_plugin, field.Name);
							break;
					}
				}
			}
		}
	}
}
