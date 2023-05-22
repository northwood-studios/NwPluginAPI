using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using MapGeneration;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079LockdownRoomEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079LockdownRoom;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public RoomIdentifier Room { get; }

		public Scp079LockdownRoomEvent(ReferenceHub hub, RoomIdentifier room)
		{
			Player = Player.Get(hub);
			Room = room;
		}

		Scp079LockdownRoomEvent() { }
	}
}
