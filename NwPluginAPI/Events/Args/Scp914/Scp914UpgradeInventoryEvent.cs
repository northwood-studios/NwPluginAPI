using InventorySystem.Items;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Scp914;

namespace PluginAPI.Events
{
	public class Scp914UpgradeInventoryEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914UpgradeInventory;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }

		public Scp914UpgradeInventoryEvent(ReferenceHub hub, ItemBase item, Scp914KnobSetting setting)
		{
			Player = Player.Get(hub);
			Item = item;
			KnobSetting = setting;
		}

		Scp914UpgradeInventoryEvent() { }
	}
}
