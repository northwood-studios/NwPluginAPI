namespace PluginAPI.Loader
{
	using System;
	using System.Reflection;

	public readonly struct PluginFileInformation
	{
		public readonly string Path;

		public readonly Assembly PluginAssembly;

		public readonly Type[] Types;

		public PluginFileInformation(string path, Assembly pluginAssembly, Type[] types)
		{
			Path = path;
			PluginAssembly = pluginAssembly;
			Types = types;
		}
	}

}