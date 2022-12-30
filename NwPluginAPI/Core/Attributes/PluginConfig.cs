namespace PluginAPI.Core.Attributes
{
	using System;

	/// <summary>
	/// Marks a plugin config.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class PluginConfig : Attribute
	{
		public string ConfigPath { get; set; }

		public PluginConfig() { }

		public PluginConfig(string configPath)
		{
			ConfigPath = configPath;
		}
	}
}