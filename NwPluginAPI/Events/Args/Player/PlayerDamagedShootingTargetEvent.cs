using AdminToys;
using PlayerStatsSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDamagedShootingTargetEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDamagedShootingTarget;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ShootingTarget ShootingTarget { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }
		[EventArgument]
		public float DamageAmount { get; set; }

		public PlayerDamagedShootingTargetEvent(ReferenceHub hub, ShootingTarget target, DamageHandlerBase handler, float damageAmount)
		{
			Player = Player.Get(hub);
			ShootingTarget = target;
			DamageHandler = handler;
			DamageAmount = damageAmount;
		}

		PlayerDamagedShootingTargetEvent() { }
	}
}
