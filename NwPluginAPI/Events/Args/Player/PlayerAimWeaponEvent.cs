using InventorySystem.Items.Firearms;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerAimWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerAimWeapon;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }
		[EventArgument]
		public bool IsAiming { get; }

		public PlayerAimWeaponEvent(ReferenceHub hub, Firearm firearm, bool isAiming)
		{
			Player = Core.Player.Get(hub);
			Firearm = firearm;
			IsAiming = isAiming;
		}

		PlayerAimWeaponEvent() { }
	}
}
