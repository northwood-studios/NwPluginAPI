using PlayerRoles.PlayableScps.Scp939;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp939
{
	public class Scp939LungeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp939Lunge;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp939LungeState State { get; }

		public Scp939LungeEvent(ReferenceHub hub, Scp939LungeState state)
		{
			Player = Core.Player.Get(hub);
			State = state;
		}

		Scp939LungeEvent() { }
	}
}
