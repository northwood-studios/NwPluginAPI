using PlayerStatsSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerDeathEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDeath;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Attacker { get; }
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
