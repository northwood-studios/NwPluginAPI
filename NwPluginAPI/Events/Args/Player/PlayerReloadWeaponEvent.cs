using InventorySystem.Items.Firearms;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerReloadWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerReloadWeapon;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }

		public PlayerReloadWeaponEvent(ReferenceHub hub, Firearm firearm)
		{
			Player = Player.Get(hub);
			Firearm = firearm;
		}

		PlayerReloadWeaponEvent() { }
	}
}
