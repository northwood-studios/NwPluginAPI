namespace PluginAPI.Core.Attributes
{
	using System;

	/// <summary>
	/// Config attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class PluginConfig : Attribute
	{
	}
}
