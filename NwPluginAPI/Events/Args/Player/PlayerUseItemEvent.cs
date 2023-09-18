using InventorySystem.Items.Usables;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUseItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUseItem;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public UsableItem Item { get; }

		public PlayerUseItemEvent(ReferenceHub hub, UsableItem item)
		{
			Player = Core.Player.Get(hub);
			Item = item;
		}

		PlayerUseItemEvent() { }
	}
}
