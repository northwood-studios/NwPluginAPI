using InventorySystem.Items;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerToggleFlashlightEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerToggleFlashlight;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }
		[EventArgument]
		public bool IsToggled { get; }

		public PlayerToggleFlashlightEvent(ReferenceHub hub, ItemBase item, bool isToggled)
		{
			Player = Player.Get(hub);
			Item = item;
			IsToggled = isToggled;
		}

		PlayerToggleFlashlightEvent() { }
	}
}
