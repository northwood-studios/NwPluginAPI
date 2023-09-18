using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp939
{
	public class Scp939AttackEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp939Attack;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public IDestructible Target { get; }

		public Scp939AttackEvent(ReferenceHub hub, IDestructible target)
		{
			Player = Core.Player.Get(hub);
			Target = target;
		}

		Scp939AttackEvent() { }
	}
}
