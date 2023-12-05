using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp096AddingTargetEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096AddingTarget;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }
		[EventArgument]
		public bool IsForLook { get; }

		public Scp096AddingTargetEvent(ReferenceHub hub, ReferenceHub target, bool isForLook)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
			IsForLook = isForLook;
		}

		Scp096AddingTargetEvent() { }
	}
}
