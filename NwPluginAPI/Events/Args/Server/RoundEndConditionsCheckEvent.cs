using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Server
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
