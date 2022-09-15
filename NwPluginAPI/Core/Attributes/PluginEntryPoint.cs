namespace PluginAPI.Core.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginEntryPoint : Attribute
	{
		public string Name { get; }
		public string Version { get; }
		public string Description { get; }
		public string Author { get; }

		public PluginEntryPoint(string pluginName, string pluginVersion, string description, string author)
		{
			Name = pluginName;
			Author = author;
			Description = description;
			Version = pluginVersion;
		}
	}
}
