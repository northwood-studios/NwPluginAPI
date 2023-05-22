using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerCheaterReportEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCheaterReport;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }
		[EventArgument]
		public string Reason { get; set; }

		public PlayerCheaterReportEvent(ReferenceHub hub, ReferenceHub target, string reason)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
			Reason = reason;
		}

		PlayerCheaterReportEvent() { }
	}
}
