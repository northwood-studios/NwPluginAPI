using InventorySystem.Items.Usables;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerCancelUsingItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCancelUsingItem;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public UsableItem Item { get; }

		public PlayerCancelUsingItemEvent(ReferenceHub hub, UsableItem item)
		{
			Player = Core.Player.Get(hub);
			Item = item;
		}

		PlayerCancelUsingItemEvent() { }
	}
}
