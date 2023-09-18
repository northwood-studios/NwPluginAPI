using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using static RoundSummary;

namespace PluginAPI.Events.Args.Server
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
