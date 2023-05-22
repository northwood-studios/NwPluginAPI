using PlayerRoles.PlayableScps.Scp079.Cameras;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079CameraChangedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079CameraChanged;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp079Camera Camera { get; }

		public Scp079CameraChangedEvent(ReferenceHub hub, Scp079Camera camera)
		{
			Player = Core.Player.Get(hub);
			Camera = camera;
		}

		Scp079CameraChangedEvent() { }
	}
}
