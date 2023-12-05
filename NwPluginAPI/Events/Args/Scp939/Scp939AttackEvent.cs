using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp939AttackEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp939Attack;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public IDestructible Target { get; }

		public Scp939AttackEvent(ReferenceHub hub, IDestructible target)
		{
			Player = Player.Get(hub);
			Target = target;
		}

		Scp939AttackEvent() { }
	}
}
