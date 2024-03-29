using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles.PlayableScps.Scp939;

namespace PluginAPI.Events
{
	public class Scp939LungeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp939Lunge;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp939LungeState State { get; }

		public Scp939LungeEvent(ReferenceHub hub, Scp939LungeState state)
		{
			Player = Player.Get(hub);
			State = state;
		}

		Scp939LungeEvent() { }
	}
}
