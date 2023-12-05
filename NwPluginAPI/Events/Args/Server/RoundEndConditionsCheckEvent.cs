using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class RoundEndConditionsCheckEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RoundEndConditionsCheck;
		[EventArgument]
		public bool BaseGameConditionsSatisfied { get; }

		public RoundEndConditionsCheckEvent(bool baseGameConditionsSatisfied)
		{
			BaseGameConditionsSatisfied = baseGameConditionsSatisfied;
		}

		RoundEndConditionsCheckEvent() { }
	}
}
