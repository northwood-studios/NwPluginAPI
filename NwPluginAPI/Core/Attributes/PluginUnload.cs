namespace PluginAPI.Core.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginUnload : Attribute
	{
	}
}
