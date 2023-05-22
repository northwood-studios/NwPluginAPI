using InventorySystem.Items.Radio;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUsingRadioEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUsingRadio;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public RadioItem Radio { get; }
		[EventArgument]
		public float Drain { get; set; }

		public PlayerUsingRadioEvent(ReferenceHub hub, RadioItem radio, float drain)
		{
			Player = Player.Get(hub);
			Radio = radio;
			Drain = drain;
		}

		PlayerUsingRadioEvent() { }
	}
}
