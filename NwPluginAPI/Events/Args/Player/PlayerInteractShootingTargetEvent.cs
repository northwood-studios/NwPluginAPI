using AdminToys;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerInteractShootingTargetEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractShootingTarget;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ShootingTarget ShootingTarget { get; }

		public PlayerInteractShootingTargetEvent(ReferenceHub hub, ShootingTarget target)
		{
			Player = Player.Get(hub);
			ShootingTarget = target;
		}

		PlayerInteractShootingTargetEvent() { }
	}
}
