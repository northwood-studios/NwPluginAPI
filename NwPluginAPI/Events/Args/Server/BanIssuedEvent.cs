using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

using static BanHandler;

namespace PluginAPI.Events.Args.Server
{
	public class BanIssuedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.BanIssued;
		[EventArgument]
		public BanDetails BanDetails { get; }
		[EventArgument]
		public BanType BanType { get; }

		public BanIssuedEvent(BanDetails details, BanType type)
		{
			BanDetails = details;
			BanType = type;
		}

		BanIssuedEvent() { }
	}
}
