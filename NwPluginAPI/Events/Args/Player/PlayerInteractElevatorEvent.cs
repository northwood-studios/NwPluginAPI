using Interactables.Interobjects;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerInteractElevatorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractElevator;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ElevatorChamber Elevator { get; }

		public PlayerInteractElevatorEvent(ReferenceHub hub, ElevatorChamber elevator)
		{
			Player = Player.Get(hub);
			Elevator = elevator;
		}

		PlayerInteractElevatorEvent() { }
	}
}
