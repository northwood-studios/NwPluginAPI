using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using static RoundSummary;

namespace PluginAPI.Events
{
	public class RoundEndEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RoundEnd;
		[EventArgument]
		public LeadingTeam LeadingTeam { get; }

		public RoundEndEvent(LeadingTeam leadingTeam)
		{
			LeadingTeam = leadingTeam;
		}

		RoundEndEvent() { }
	}
}
