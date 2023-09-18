using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.Args.Player
{
	public class PlaceBloodEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlaceBlood;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Vector3 Position { get; set; }

		public PlaceBloodEvent(ReferenceHub hub, Vector3 position)
		{
			Player = Player.Get(hub);
			Position = position;
		}

		PlaceBloodEvent() { }
	}
}
