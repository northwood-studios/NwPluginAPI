using InventorySystem.Items.Firearms;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerDryfireWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDryfireWeapon;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }

		public PlayerDryfireWeaponEvent(ReferenceHub hub, Firearm firearm)
		{
			Player = Player.Get(hub);
			Firearm = firearm;
		}

		PlayerDryfireWeaponEvent() { }
	}
}
