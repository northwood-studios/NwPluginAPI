using UnityEngine;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlaceBloodEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlaceBlood;
		[EventArgument]
		public Player Player { get; }
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
