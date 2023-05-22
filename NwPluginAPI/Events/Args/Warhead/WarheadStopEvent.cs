using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Warhead
{
	public class WarheadStopEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.WarheadStop;
		[EventArgument]
		public Player Player { get; }

		public WarheadStopEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		WarheadStopEvent() { }
	}
}
