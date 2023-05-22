using InventorySystem.Items.Firearms;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerAimWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerAimWeapon;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }
		[EventArgument]
		public bool IsAiming { get; }

		public PlayerAimWeaponEvent(ReferenceHub hub, Firearm firearm, bool isAiming)
		{
			Player = Player.Get(hub);
			Firearm = firearm;
			IsAiming = isAiming;
		}

		PlayerAimWeaponEvent() { }
	}
}
