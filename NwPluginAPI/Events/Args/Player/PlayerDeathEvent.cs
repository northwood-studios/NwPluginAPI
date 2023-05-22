using PlayerStatsSystem;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDeathEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDeath;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Attacker { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }

		public PlayerDeathEvent(ReferenceHub hub, ReferenceHub attacker, DamageHandlerBase handler)
		{
			Player = Player.Get(hub);
			Attacker = Player.Get(attacker);
			DamageHandler = handler;
		}

		PlayerDeathEvent() { }
	}
}
