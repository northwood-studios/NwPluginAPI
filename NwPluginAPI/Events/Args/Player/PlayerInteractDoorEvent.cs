using Interactables.Interobjects.DoorUtils;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerInteractDoorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractDoor;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public DoorVariant Door { get; }
		[EventArgument]
		public bool CanOpen { get; set; }

		public PlayerInteractDoorEvent(ReferenceHub hub, DoorVariant door, bool canOpen)
		{
			Player = Player.Get(hub);
			Door = door;
			CanOpen = canOpen;
		}

		PlayerInteractDoorEvent() { }
	}
}
