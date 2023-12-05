using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp173CreateTantrumEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173CreateTantrum;
		[EventArgument]
		public Player Player { get; }

		public Scp173CreateTantrumEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		Scp173CreateTantrumEvent() { }
	}
}
