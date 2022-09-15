namespace PluginAPI.Core.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginReload : Attribute
	{
	}
}
