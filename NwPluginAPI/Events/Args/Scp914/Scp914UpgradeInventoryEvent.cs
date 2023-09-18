using InventorySystem.Items;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Scp914;

namespace PluginAPI.Events.Args.Scp914
{
	public class Scp914UpgradeInventoryEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914UpgradeInventory;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ItemBase Item { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }

		public Scp914UpgradeInventoryEvent(ReferenceHub hub, ItemBase item, Scp914KnobSetting setting)
		{
			Player = Core.Player.Get(hub);
			Item = item;
			KnobSetting = setting;
		}

		Scp914UpgradeInventoryEvent() { }
	}
}
