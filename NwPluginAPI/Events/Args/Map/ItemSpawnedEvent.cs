using UnityEngine;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Map
{
	public class ItemSpawnedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.ItemSpawned;
		[EventArgument]
		public ItemType Item { get; set; }
		[EventArgument]
		public Vector3 Position { get; set; }

		public ItemSpawnedEvent(ItemType item, Vector3 pos)
		{
			Item = item;
			Position = pos;
		}

		ItemSpawnedEvent() { }
	}
}
