using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp096
{
	public class Scp096StartCryingEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp096StartCrying;
		[EventArgument]
		public Core.Player Player { get; }

		public Scp096StartCryingEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		Scp096StartCryingEvent() { }
	}
}
