using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles.PlayableScps.Scp096;

namespace PluginAPI.Events.Args.Scp096
{
	public class Scp096ChangeStateEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096ChangeState;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp096RageState RageState { get; }

		public Scp096ChangeStateEvent(ReferenceHub hub, Scp096RageState state)
		{
			Player = Core.Player.Get(hub);
			RageState = state;
		}

		Scp096ChangeStateEvent() { }
	}
}
