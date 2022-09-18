namespace PluginAPI.Core.Attributes
{
	using Enums;
	using System;

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginEvent : Attribute
	{
		public ServerEventType EventType { get; }

		public PluginEvent(ServerEventType eventType)
		{
			EventType = eventType;
		}
	}
}
