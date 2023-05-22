using UnityEngine;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

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
