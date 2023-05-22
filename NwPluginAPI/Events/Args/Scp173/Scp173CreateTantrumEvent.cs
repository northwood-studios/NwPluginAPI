using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp173
{
	public class Scp173CreateTantrumEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173CreateTantrum;
		[EventArgument]
		public Core.Player Player { get; }

		public Scp173CreateTantrumEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		Scp173CreateTantrumEvent() { }
	}
}
