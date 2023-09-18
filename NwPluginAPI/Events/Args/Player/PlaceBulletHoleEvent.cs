using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.Args.Player
{
	public class PlaceBulletHoleEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlaceBulletHole;
		[EventArgument]
		public Vector3 Position { get; set; }

		public PlaceBulletHoleEvent(Vector3 position)
		{
			Position = position;
		}

		PlaceBulletHoleEvent() { }
	}
}
