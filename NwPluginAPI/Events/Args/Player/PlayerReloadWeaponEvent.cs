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
		public Core.Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }

		public PlayerReloadWeaponEvent(ReferenceHub hub, Firearm firearm)
		{
			Player = Core.Player.Get(hub);
			Firearm = firearm;
		}

		PlayerReloadWeaponEvent() { }
	}
}
