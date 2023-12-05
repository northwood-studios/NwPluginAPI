using System;

namespace PluginAPI.Core.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class EventArgument : Attribute { }
}
