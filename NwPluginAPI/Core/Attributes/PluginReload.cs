namespace PluginAPI.Core.Attributes
{
	using System;

	/// <summary>
	/// Marks a plugin reloaded event handler.
	/// Called when the plugin is reloaded.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginReload : Attribute
	{
	}
}
