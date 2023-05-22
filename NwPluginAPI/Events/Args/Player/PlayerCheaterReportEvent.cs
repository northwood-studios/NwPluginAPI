using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerCheaterReportEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCheaterReport;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }
		[EventArgument]
		public string Reason { get; set; }

		public PlayerCheaterReportEvent(ReferenceHub hub, ReferenceHub target, string reason)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
			Reason = reason;
		}

		PlayerCheaterReportEvent() { }
	}
}
