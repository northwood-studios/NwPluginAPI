using InventorySystem.Items.Firearms;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerShotWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerShotWeapon;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }

		public PlayerShotWeaponEvent(ReferenceHub player, Firearm firearm)
		{
			Player = Core.Player.Get(player);
			Firearm = firearm;
		}

		PlayerShotWeaponEvent() { }
	}
}
