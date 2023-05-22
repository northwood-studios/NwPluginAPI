using PlayerStatsSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDamagedWindowEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDamagedWindow;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public BreakableWindow Window { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }
		[EventArgument]
		public float DamageAmount { get; set; }

		public PlayerDamagedWindowEvent(ReferenceHub hub, BreakableWindow window, DamageHandlerBase handler)
		{
			Player = Core.Player.Get(hub);
			Window = window;
			DamageHandler = handler;
		}

		PlayerDamagedWindowEvent() { }
	}
}
