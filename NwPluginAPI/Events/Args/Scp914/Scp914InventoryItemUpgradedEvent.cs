using InventorySystem.Items;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Scp914;

namespace PluginAPI.Events
{
	public class Scp914InventoryItemUpgradedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914InventoryItemUpgraded;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }

		public Scp914InventoryItemUpgradedEvent(ReferenceHub hub, ItemBase item, Scp914KnobSetting setting)
		{
			Player = Player.Get(hub);
			Item = item;
			KnobSetting = setting;
		}

		Scp914InventoryItemUpgradedEvent() { }
	}
}
