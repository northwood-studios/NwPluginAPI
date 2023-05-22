using InventorySystem.Items.Firearms;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerShotWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerShotWeapon;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }

		public PlayerShotWeaponEvent(ReferenceHub player, Firearm firearm)
		{
			Player = Player.Get(player);
			Firearm = firearm;
		}

		PlayerShotWeaponEvent() { }
	}
}
