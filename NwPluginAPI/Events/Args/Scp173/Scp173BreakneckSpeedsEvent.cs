using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp173
{
	public class Scp173BreakneckSpeedsEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173BreakneckSpeeds;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public bool Activate { get; }

		public Scp173BreakneckSpeedsEvent(ReferenceHub hub, bool activate)
		{
			Player = Core.Player.Get(hub);
			Activate = activate;
		}

		Scp173BreakneckSpeedsEvent() { }
	}
}
