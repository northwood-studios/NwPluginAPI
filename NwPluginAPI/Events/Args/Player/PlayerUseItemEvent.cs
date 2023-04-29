using InventorySystem.Items.Usables;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerUseItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUseItem;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public UsableItem Item { get; }

		public PlayerUseItemEvent(ReferenceHub hub, UsableItem item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerUseItemEvent() { }
	}
}
