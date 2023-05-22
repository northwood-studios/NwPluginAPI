using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

using static BanHandler;

namespace PluginAPI.Events.Args.Server
{
	public class BanUpdatedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.BanUpdated;
		[EventArgument]
		public BanDetails BanDetails { get; }
		[EventArgument]
		public BanType BanType { get; }

		public BanUpdatedEvent(BanDetails details, BanType type)
		{
			BanDetails = details;
			BanType = type;
		}

		BanUpdatedEvent() { }
	}
}
