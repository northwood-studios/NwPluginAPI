using MapGeneration;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079CancelRoomLockdownEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079CancelRoomLockdown;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public RoomIdentifier Room { get; }

		public Scp079CancelRoomLockdownEvent(ReferenceHub hub, RoomIdentifier room)
		{
			Player = Core.Player.Get(hub);
			Room = room;
		}

		Scp079CancelRoomLockdownEvent() { }
	}
}
