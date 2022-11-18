namespace PluginAPI.Core
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using Attributes;
	using CommandSystem;
	using Loader.Features;
	using PluginAPI.Commands;
	using RemoteAdmin;
	using Serialization;

	/// <summary>
	/// Handles a plugin.
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
		/// Initializes a new instance of the <see cref="PluginHandler"/> class.
		/// </summary>
		/// <param name="directory">The directory of plugin.</param>
		/// <param name="entryType">The type of plugin.</param>
		/// <param name="types">The all types in plugin.</param>
		public PluginHandler(PluginDirectory directory, Type entryType, Type[] types)
		{
			_plugin = Activator.CreateInstance(entryType);
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
                Log.Error($"Missing entrypoint for plugin &2{PluginName}&r!");
                return;
			}

			foreach(var type in types)
			{
				if (!type.IsClass) continue;

				if (!typeof(ICommand).IsAssignableFrom(type)) continue;

				foreach (var attributeData in type.GetCustomAttributesData())
				{
					if (attributeData.AttributeType != typeof(CommandHandlerAttribute)) continue;

					CommandsManager.RegisterCommand(this, (Type)attributeData.ConstructorArguments[0].Value, type);
				}
			}

            if (!Directory.Exists(Path.Combine(directory.Plugins, PluginName)))
			{
                Directory.CreateDirectory(Path.Combine(directory.Plugins, PluginName));
                Log.Info($"Created missing plugin directory for \"&2{PluginName}&r\".");
            }

            foreach (var field in _pluginType.GetFields())
			{
                var attribute = field.GetCustomAttribute<Attribute>();

                switch (attribute)
				{
					case PluginConfig _:
                        if (!File.Exists(Path.Combine(directory.Plugins, _entryInfo.Name, "config.yml")))
                        {
                            var defaultConfig = Activator.CreateInstance(field.FieldType);

							field.SetValue(_plugin, defaultConfig);

                            File.WriteAllText(Path.Combine(directory.Plugins, _entryInfo.Name, "config.yml"), YamlParser.Serializer.Serialize(defaultConfig));
                            Log.Info($"Created missing config file for &2{PluginName}&r.");
                        }
                        else
                        {
                            var config = YamlParser.Deserializer.Deserialize(File.ReadAllText(Path.Combine(directory.Plugins, _entryInfo.Name, "config.yml")), field.FieldType);
							field.SetValue(_plugin, config);
							File.WriteAllText(Path.Combine(directory.Plugins, _entryInfo.Name, "config.yml"), YamlParser.Serializer.Serialize(config));

							Log.Info($"Loaded config file for &2{PluginName}&r.");
                        }
                        break;
				}
			}
		}
	}
}
