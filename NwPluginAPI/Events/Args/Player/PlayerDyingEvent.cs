using PlayerStatsSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerDyingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDying;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Attacker { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }

		public PlayerDyingEvent(ReferenceHub hub, ReferenceHub attacker, DamageHandlerBase handler)
		{
			Player = Player.Get(hub);
			Attacker = Player.Get(attacker);
			DamageHandler = handler;
		}

		PlayerDyingEvent() { }
	}
}
