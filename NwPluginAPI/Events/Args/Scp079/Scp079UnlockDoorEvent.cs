using Interactables.Interobjects.DoorUtils;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp079UnlockDoorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079UnlockDoor;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public DoorVariant Door { get; }

		public Scp079UnlockDoorEvent(ReferenceHub hub, DoorVariant door)
		{
			Player = Player.Get(hub);
			Door = door;
		}

		Scp079UnlockDoorEvent() { }
	}
}
