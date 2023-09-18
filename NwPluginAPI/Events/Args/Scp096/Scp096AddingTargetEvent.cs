using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp096
{
	public class Scp096AddingTargetEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096AddingTarget;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }
		[EventArgument]
		public bool IsForLook { get; }

		public Scp096AddingTargetEvent(ReferenceHub hub, ReferenceHub target, bool isForLook)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
			IsForLook = isForLook;
		}

		Scp096AddingTargetEvent() { }
	}
}
