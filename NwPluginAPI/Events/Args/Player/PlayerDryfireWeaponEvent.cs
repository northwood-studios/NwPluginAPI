using InventorySystem.Items.Firearms;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDryfireWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDryfireWeapon;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }

		public PlayerDryfireWeaponEvent(ReferenceHub hub, Firearm firearm)
		{
			Player = Core.Player.Get(hub);
			Firearm = firearm;
		}

		PlayerDryfireWeaponEvent() { }
	}
}
