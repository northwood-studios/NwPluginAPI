using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Scp914;

namespace PluginAPI.Events
{
	public class Scp914ActivateEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914Activate;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }

		public Scp914ActivateEvent(ReferenceHub hub, Scp914KnobSetting setting)
		{
			Player = Player.Get(hub);
			KnobSetting = setting;
		}

		Scp914ActivateEvent() { }
	}
}
