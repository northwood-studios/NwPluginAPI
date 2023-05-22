using Interactables.Interobjects.DoorUtils;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079LockDoorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079LockDoor;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public DoorVariant Door { get; }

		public Scp079LockDoorEvent(ReferenceHub hub, DoorVariant door)
		{
			Player = Core.Player.Get(hub);
			Door = door;
		}

		Scp079LockDoorEvent() { }
	}
}
