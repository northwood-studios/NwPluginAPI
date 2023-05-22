using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Warhead
{
	public class WarheadStartEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.WarheadStart;
		[EventArgument]
		public bool IsAutomatic { get; }
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public bool IsResumed { get; }

		public WarheadStartEvent(bool isAutomatic, ReferenceHub hub, bool isResumed)
		{
			IsAutomatic = isAutomatic;
			Player = Player.Get(hub);
			IsResumed = isResumed;
		}

		WarheadStartEvent() { }
	}
}
