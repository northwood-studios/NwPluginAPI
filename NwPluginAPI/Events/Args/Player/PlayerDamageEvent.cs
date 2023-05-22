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
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }

		public PlayerDamageEvent(ReferenceHub hub, ReferenceHub target, DamageHandlerBase handler)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
			DamageHandler = handler;
		}

		PlayerDamageEvent() { }
	}
}
