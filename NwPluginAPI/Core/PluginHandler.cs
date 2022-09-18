namespace PluginAPI.Core
{
	using System;
	using System.IO;
	using System.Reflection;
	using Attributes;
	using Loader.Features;
	using Serialization;

	/// <summary>
	/// Plugin.
	/// </summary>
	public class PluginHandler
	{
		private static readonly string UnknownName = "Unknown";
		private static readonly string UnknownVersion = "0.0.0";

		private readonly object _plugin;
		private readonly Type _pluginType;

        private readonly PluginEntryPoint _entryInfo;

        private readonly MethodInfo _entryPoint;
        private readonly MethodInfo _onUnload;

        /// <summary>
		/// Name of plugin.
		/// </summary>
        public string PluginName => _entryInfo?.Name ?? _pluginType.FullName;

		/// <summary>
		/// Version of plugin.
		/// </summary>
		public string PluginVersion => _entryInfo?.Version ?? UnknownVersion;

		/// <summary>
		/// Description of plugin.
		/// </summary>
		public string PluginDescription => _entryInfo?.Description ?? UnknownName;

		/// <summary>
		/// Author of plugin.
		/// </summary>
		public string PluginAuthor => _entryInfo?.Author ?? UnknownName;

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
					
					case PluginUnload _:
                        _onUnload = method;
                        break;
                }
			}

			if (_entryInfo == null)
			{
                Log.Error($"Missing entrypoint for plugin {PluginName}!");
                return;
			}

            if (!Directory.Exists(Path.Combine(directory.Plugins, PluginName)))
			{
                Directory.CreateDirectory(Path.Combine(directory.Plugins, PluginName));
                Log.Info($"Created missing plugin directory for \"{PluginName}\".");
            }

            foreach (var field in _pluginType.GetFields())
			{
                var attribute = field.GetCustomAttribute<Attribute>();

                switch (attribute)
				{
					case PluginConfig _:
                        var configType = field.FieldType;
                        var configInfo = field;

                        if (!File.Exists(Path.Combine(directory.Plugins, _entryInfo.Name, "config.yml")))
                        {

                            var defaultConfig = Activator.CreateInstance(configType);

                            configInfo.SetValue(_plugin, defaultConfig);

                            File.WriteAllText(Path.Combine(directory.Plugins, _entryInfo.Name, "config.yml"), YamlParser.Serializer.Serialize(defaultConfig));
                            Log.Info($"Created missing config file for \"{PluginName}\".");
                        }
                        else
                        {
                            var config = YamlParser.Deserializer.Deserialize(File.ReadAllText(Path.Combine(directory.Plugins, _entryInfo.Name, "config.yml")), configType);
                            configInfo.SetValue(_plugin, config);
                            Log.Info($"Loaded config file for \"{PluginName}\".");
                        }
                        break;
				}
			}
		}
	}
}
