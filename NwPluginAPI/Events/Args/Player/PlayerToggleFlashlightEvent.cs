using InventorySystem.Items;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerToggleFlashlightEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerToggleFlashlight;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }
		[EventArgument]
		public bool IsToggled { get; }

		public PlayerToggleFlashlightEvent(ReferenceHub hub, ItemBase item, bool isToggled)
		{
			Player = Core.Player.Get(hub);
			Item = item;
			IsToggled = isToggled;
		}

		PlayerToggleFlashlightEvent() { }
	}
}
