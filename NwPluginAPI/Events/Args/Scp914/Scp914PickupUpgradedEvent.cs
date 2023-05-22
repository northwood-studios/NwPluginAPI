using InventorySystem.Items.Pickups;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Scp914;
using UnityEngine;

namespace PluginAPI.Events.Args.Scp914
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
