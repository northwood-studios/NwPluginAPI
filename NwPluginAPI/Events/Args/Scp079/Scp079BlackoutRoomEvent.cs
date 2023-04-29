using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using MapGeneration;

namespace PluginAPI.Events
{
	public class Scp079BlackoutRoomEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079BlackoutRoom;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public RoomIdentifier Room { get; }

		public Scp079BlackoutRoomEvent(ReferenceHub hub, RoomIdentifier room)
		{
			Player = Player.Get(hub);
			Room = room;
		}

		Scp079BlackoutRoomEvent() { }
	}
}
