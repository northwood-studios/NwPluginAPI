using InventorySystem.Items.Radio;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerRadioToggleEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerRadioToggle;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public RadioItem Radio { get; }
		[EventArgument]
		public bool NewState { get; set; }

		public PlayerRadioToggleEvent(ReferenceHub hub, RadioItem radio, bool newState)
		{
			Player = Player.Get(hub);
			Radio = radio;
			NewState = newState;
		}

		PlayerRadioToggleEvent() { }
	}
}
