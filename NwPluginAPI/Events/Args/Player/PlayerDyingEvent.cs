using PlayerStatsSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDyingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDying;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Attacker { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }

		public PlayerDyingEvent(ReferenceHub hub, ReferenceHub attacker, DamageHandlerBase handler)
		{
			Player = Core.Player.Get(hub);
			Attacker = Core.Player.Get(attacker);
			DamageHandler = handler;
		}

		PlayerDyingEvent() { }
	}
}
