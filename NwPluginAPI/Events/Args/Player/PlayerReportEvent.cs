using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerReportEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerReport;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }
		[EventArgument]
		public string Reason { get; set; }

		public PlayerReportEvent(ReferenceHub hub, ReferenceHub target, string reason)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
			Reason = reason;
		}

		PlayerReportEvent() { }
	}
}
