using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Scp914;

namespace PluginAPI.Events.Args.Scp914
{
	public class Scp914KnobChangeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914KnobChange;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; set; }
		[EventArgument]
		public Scp914KnobSetting PreviousKnobSetting { get; }

		public Scp914KnobChangeEvent(ReferenceHub hub, Scp914KnobSetting setting, Scp914KnobSetting oldSetting)
		{
			Player = Core.Player.Get(hub);
			KnobSetting = setting;
			PreviousKnobSetting = oldSetting;
		}

		Scp914KnobChangeEvent() { }
	}
}
