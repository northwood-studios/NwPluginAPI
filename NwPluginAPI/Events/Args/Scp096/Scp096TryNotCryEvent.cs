using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp096TryNotCryEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096TryNotCry;
		[EventArgument]
		public Player Player { get; }

		public Scp096TryNotCryEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		Scp096TryNotCryEvent() { }
	}
}
