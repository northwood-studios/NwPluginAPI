using PlayerRoles.Ragdolls;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp049ResurrectBodyEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp049ResurrectBody;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Player Target { get; }
		[EventArgument]
		public BasicRagdoll Body { get; }

		public Scp049ResurrectBodyEvent(ReferenceHub hub, ReferenceHub target, BasicRagdoll body)
		{
			Player = Player.Get(hub);
			Target = Player.Get(target);
			Body = body;
		}

		Scp049ResurrectBodyEvent() { }
	}
}
