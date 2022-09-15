namespace PluginAPI.Core
{
	using System;
	using System.IO;
	using System.Reflection;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Loader.Features;
	using Serialization;

	/// <summary>
	/// Plugin.
	/// </summary>
	public class PluginHandler
	{
		private static string _unknownName { get; } = "Unknown";
		private static string _unknownVersion { get; } = "0.0.0";

        private PluginDirectory _pluginDirectory;

        private object _plugin;
		private Type _pluginType;

        private PluginEntryPoint _entryInfo;

        private MethodInfo _entryPoint;
        private MethodInfo _onReload;
        private MethodInfo _onUnload;

        private FieldInfo _configInfo;

        private Type _configType;

		/// <summary>
		/// Name of plugin.
		/// </summary>
        public string PluginName => _entryInfo?.Name ?? _pluginType.FullName;

		/// <summary>
		/// Version of plugin.
		/// </summary>
		public string PluginVersion => _entryInfo?.Version ?? _unknownVersion;

		/// <summary>
		/// Description of plugin.
		/// </summary>
		public string PluginDescription => _entryInfo?.Description ?? _unknownName;

		/// <summary>
		/// Author of plugin.
		/// </summary>
		public string PluginAuthor => _entryInfo?.Author ?? _unknownName;

		/// <summary>
		/// Unloads plugin.
		/// </summary>
		public void Unload()
		{
            if (_onUnload == null)
            {
                Log.Warning($"Plugin {PluginName} has missing unload method!");
                return;
            }

            try
			{
				_onUnload.Invoke(_plugin, null);
			}
			catch (Exception ex)
			{
				Log.Error($"Failed unloading plugin {PluginName}!\n{ex}");
			}
		}

		/// <summary>
		/// Loads plugin.
		/// </summary>
		public void Load()
		{
			if (_entryPoint == null)
			{
				Log.Error($"Failed loading plugin {PluginName}, invalid entrypoint!");
				return;
			}

			try
			{
				_entryPoint.Invoke(_plugin, null);
			}
			catch (Exception ex)
			{
				Log.Error($"Failed loading plugin {_entryInfo.Name},\n{ex}");
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="directory">The directory of plugin.</param>
		/// <param name="type">The type of plugin.</param>
        public PluginHandler(PluginDirectory directory, Type type)
		{
			_pluginDirectory = directory;

			_plugin = Activator.CreateInstance(type);
            _pluginType = _plugin.GetType();

            foreach (var method in _pluginType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				var attribute = method.GetCustomAttribute<Attribute>();

				switch (attribute)
				{
					case PluginEntryPoint pluginEntryPoint:
                        _entryPoint = method;
                        _entryInfo = pluginEntryPoint;
                        break;
					case PluginUnload pluginUnload:
                        _onUnload = method;
                        break;
                }
			}

			if (_entryInfo == null)
			{
                Log.Error($"Missing entrypoint for plugin {PluginName}!");
                return;
			}

            if (!Directory.Exists(Path.Combine(_pluginDirectory.Plugins, PluginName)))
			{
                Directory.CreateDirectory(Path.Combine(_pluginDirectory.Plugins, PluginName));
                Log.Info($"Created missing plugin directory for \"{PluginName}\".");
            }

            foreach (var field in _pluginType.GetFields())
			{
                var attribute = field.GetCustomAttribute<Attribute>();

                switch (attribute)
				{
					case PluginConfig pluginConfig:
                        _configType = field.FieldType;
                        _configInfo = field;

                        if (!File.Exists(Path.Combine(_pluginDirectory.Plugins, _entryInfo.Name, "config.yml")))
                        {

                            var defaultConfig = Activator.CreateInstance(_configType);

                            _configInfo.SetValue(_plugin, defaultConfig);

                            File.WriteAllText(Path.Combine(_pluginDirectory.Plugins, _entryInfo.Name, "config.yml"), YamlParser.Serializer.Serialize(defaultConfig));
                            Log.Info($"Created missing config file for \"{PluginName}\".");
                        }
                        else
                        {
                            var config = YamlParser.Deserializer.Deserialize(File.ReadAllText(Path.Combine(_pluginDirectory.Plugins, _entryInfo.Name, "config.yml")), _configType);
                            _configInfo.SetValue(_plugin, config);
                            Log.Info($"Loaded config file for \"{PluginName}\".");
                        }
                        break;
				}
			}
		}
	}
}
