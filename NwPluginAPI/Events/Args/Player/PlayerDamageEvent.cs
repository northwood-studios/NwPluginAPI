using PlayerStatsSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDamageEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDamage;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }

		public PlayerDamageEvent(ReferenceHub hub, ReferenceHub target, DamageHandlerBase handler)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
			DamageHandler = handler;
		}

		PlayerDamageEvent() { }
	}
}
