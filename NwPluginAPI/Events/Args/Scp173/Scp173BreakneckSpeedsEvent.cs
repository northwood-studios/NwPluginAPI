using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp173
{
	public class Scp173BreakneckSpeedsEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173BreakneckSpeeds;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public bool Activate { get; }

		public Scp173BreakneckSpeedsEvent(ReferenceHub hub, bool activate)
		{
			Player = Player.Get(hub);
			Activate = activate;
		}

		Scp173BreakneckSpeedsEvent() { }
	}
}
