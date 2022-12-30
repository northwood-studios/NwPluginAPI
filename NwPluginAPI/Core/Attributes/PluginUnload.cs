namespace PluginAPI.Core.Attributes
{
	using System;

	/// <summary>
	/// Marks a plugin unloaded event handler.
	/// Called when the plugin is unloaded.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginUnload : Attribute { }
}