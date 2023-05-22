using UnityEngine;
using Footprinting;
using InventorySystem.Items.Pickups;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Map
{
	public class GrenadeExplodedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.GrenadeExploded;
		[EventArgument]
		public Footprint Thrower { get; }
		[EventArgument]
		public Vector3 Position { get; }
		[EventArgument]
		public ItemPickupBase Grenade { get; }

		public GrenadeExplodedEvent(Footprint thrower, Vector3 pos, ItemPickupBase grenade)
		{
			Thrower = thrower;
			Position = pos;
			Grenade = grenade;
		}

		GrenadeExplodedEvent() { }
	}
}
