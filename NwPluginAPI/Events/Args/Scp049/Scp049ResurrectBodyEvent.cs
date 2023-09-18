using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp049
{
	public class Scp049ResurrectBodyEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp049ResurrectBody;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Core.Player Target { get; }
		[EventArgument]
		public BasicRagdoll Body { get; }

		public Scp049ResurrectBodyEvent(ReferenceHub hub, ReferenceHub target, BasicRagdoll body)
		{
			Player = Core.Player.Get(hub);
			Target = Core.Player.Get(target);
			Body = body;
		}

		Scp049ResurrectBodyEvent() { }
	}
}
