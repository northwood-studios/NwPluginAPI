using UnityEngine;
using InventorySystem.Items.Pickups;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Scp914;

namespace PluginAPI.Events
{
	public class Scp914PickupUpgradedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914PickupUpgraded;
		[EventArgument]
		public ItemPickupBase Item { get; }
		[EventArgument]
		public Vector3 NewPosition { get; set; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }

		public Scp914PickupUpgradedEvent(ItemPickupBase item, Vector3 newPosition, Scp914KnobSetting setting)
		{
			Item = item;
			NewPosition = newPosition;
			KnobSetting = setting;
		}

		Scp914PickupUpgradedEvent() { }
	}
}
