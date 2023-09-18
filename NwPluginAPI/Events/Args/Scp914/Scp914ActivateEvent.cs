using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Scp914;

namespace PluginAPI.Events.Args.Scp914
{
	public class Scp914ActivateEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914Activate;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }

		public Scp914ActivateEvent(ReferenceHub hub, Scp914KnobSetting setting)
		{
			Player = Core.Player.Get(hub);
			KnobSetting = setting;
		}

		Scp914ActivateEvent() { }
	}
}
