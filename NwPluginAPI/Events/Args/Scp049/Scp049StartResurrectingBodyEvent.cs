using PlayerRoles.Ragdolls;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp049StartResurrectingBodyEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp049StartResurrectingBody;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }
		[EventArgument]
		public BasicRagdoll Body { get; }
		[EventArgument]
		public bool CanResurrect { get; }

		public Scp049StartResurrectingBodyEvent(ReferenceHub hub, ReferenceHub target, BasicRagdoll body, bool canResurrect)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
			Body = body;
			CanResurrect = canResurrect;
		}

		Scp049StartResurrectingBodyEvent() { }
	}
}
