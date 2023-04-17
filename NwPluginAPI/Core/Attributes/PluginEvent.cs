namespace PluginAPI.Core.Attributes
{
	using Enums;
	using System;

	/// <summary>
	/// Marks a plugin event handler method.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginEvent : Attribute
	{
		public ServerEventType EventType { get; } = ServerEventType.None;

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginEvent"/> class.
		/// </summary>
		/// <param name="eventType">The <see cref="ServerEventType"/>.</param>
		public PluginEvent(ServerEventType eventType)
		{
			EventType = eventType;
		}

		public PluginEvent() { }
	}
}