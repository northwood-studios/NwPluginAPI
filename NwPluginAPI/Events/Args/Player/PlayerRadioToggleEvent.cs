using InventorySystem.Items.Radio;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerRadioToggleEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerRadioToggle;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public RadioItem Radio { get; }
		[EventArgument]
		public bool NewState { get; set; }

		public PlayerRadioToggleEvent(ReferenceHub hub, RadioItem radio, bool newState)
		{
			Player = Core.Player.Get(hub);
			Radio = radio;
			NewState = newState;
		}

		PlayerRadioToggleEvent() { }
	}
}
