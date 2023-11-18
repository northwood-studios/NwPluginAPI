namespace PluginAPI.Loader
{

	using System;
	using System.Reflection;

	internal sealed class PluginAssemblyInformation
	{

		public PluginAssemblyInformation(string path, Assembly assembly)
		{
			Path = path;
			Assembly = assembly;
		}

		public Type[] Types = Array.Empty<Type>();

		public readonly string Path;

		public readonly Assembly Assembly;

	}

}