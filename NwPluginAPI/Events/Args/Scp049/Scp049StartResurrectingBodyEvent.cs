using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp049
{
	public class Scp049StartResurrectingBodyEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp049StartResurrectingBody;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }
		[EventArgument]
		public BasicRagdoll Body { get; }
		[EventArgument]
		public bool CanResurrct { get; }

		public Scp049StartResurrectingBodyEvent(ReferenceHub hub, ReferenceHub target, BasicRagdoll body, bool canResurrct)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
			Body = body;
			CanResurrct = canResurrct;
		}

		Scp049StartResurrectingBodyEvent() { }
	}
}
