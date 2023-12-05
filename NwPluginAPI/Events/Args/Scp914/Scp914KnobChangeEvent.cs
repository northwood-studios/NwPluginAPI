using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using Scp914;

namespace PluginAPI.Events
{
	public class Scp914KnobChangeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914KnobChange;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; set; }
		[EventArgument]
		public Scp914KnobSetting PreviousKnobSetting { get; }

		public Scp914KnobChangeEvent(ReferenceHub hub, Scp914KnobSetting setting, Scp914KnobSetting oldSetting)
		{
			Player = Player.Get(hub);
			KnobSetting = setting;
			PreviousKnobSetting = oldSetting;
		}

		Scp914KnobChangeEvent() { }
	}
}
