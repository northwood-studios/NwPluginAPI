using InventorySystem.Items.Firearms;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUnloadWeaponEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUnloadWeapon;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Firearm Firearm { get; }

		public PlayerUnloadWeaponEvent(ReferenceHub hub, Firearm firearm)
		{
			Player = Core.Player.Get(hub);
			Firearm = firearm;
		}

		PlayerUnloadWeaponEvent() { }
	}
}
