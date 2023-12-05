using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class Scp096StartCryingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096StartCrying;
		[EventArgument]
		public Player Player { get; }

		public Scp096StartCryingEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		Scp096StartCryingEvent() { }
	}
}
