using InventorySystem.Items.Radio;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerUsingRadioEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerUsingRadio;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public RadioItem Radio { get; }
		[EventArgument]
		public float Drain { get; set; }

		public PlayerUsingRadioEvent(ReferenceHub hub, RadioItem radio, float drain)
		{
			Player = Core.Player.Get(hub);
			Radio = radio;
			Drain = drain;
		}

		PlayerUsingRadioEvent() { }
	}
}
