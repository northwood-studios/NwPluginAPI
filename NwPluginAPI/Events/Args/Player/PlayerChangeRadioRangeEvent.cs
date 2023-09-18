using InventorySystem.Items.Radio;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using static InventorySystem.Items.Radio.RadioMessages;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerChangeRadioRangeEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerChangeRadioRange;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public RadioItem Radio { get; }
		[EventArgument]
		public RadioRangeLevel Range { get; set; }

		public PlayerChangeRadioRangeEvent(ReferenceHub hub, RadioItem radio, RadioRangeLevel range)
		{
			Player = Core.Player.Get(hub);
			Radio = radio;
			Range = range;
		}

		PlayerChangeRadioRangeEvent() { }
	}
}
