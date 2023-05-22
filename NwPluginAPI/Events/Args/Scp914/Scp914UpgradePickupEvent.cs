using UnityEngine;
using InventorySystem.Items.Pickups;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Scp914;

namespace PluginAPI.Events.Args.Scp914
{
	public class Scp914UpgradePickupEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914UpgradePickup;
		[EventArgument]
		public ItemPickupBase Item { get; }
		[EventArgument]
		public Vector3 OutputPosition { get; set; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }

		public Scp914UpgradePickupEvent(ItemPickupBase item, Vector3 outputPosition, Scp914KnobSetting setting)
		{
			Item = item;
			OutputPosition = outputPosition;
			KnobSetting = setting;
		}

		Scp914UpgradePickupEvent() { }
	}
}
