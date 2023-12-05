using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles.PlayableScps.Scp079.Cameras;

namespace PluginAPI.Events
{
	public class Scp079CameraChangedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079CameraChanged;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp079Camera Camera { get; }

		public Scp079CameraChangedEvent(ReferenceHub hub, Scp079Camera camera)
		{
			Player = Player.Get(hub);
			Camera = camera;
		}

		Scp079CameraChangedEvent() { }
	}
}
