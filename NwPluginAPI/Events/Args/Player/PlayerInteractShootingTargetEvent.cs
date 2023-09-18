using AdminToys;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerInteractShootingTargetEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractShootingTarget;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ShootingTarget ShootingTarget { get; }

		public PlayerInteractShootingTargetEvent(ReferenceHub hub, ShootingTarget target)
		{
			Player = Core.Player.Get(hub);
			ShootingTarget = target;
		}

		PlayerInteractShootingTargetEvent() { }
	}
}
