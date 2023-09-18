using Interactables.Interobjects;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerInteractElevatorEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractElevator;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ElevatorChamber Elevator { get; }

		public PlayerInteractElevatorEvent(ReferenceHub hub, ElevatorChamber elevator)
		{
			Player = Core.Player.Get(hub);
			Elevator = elevator;
		}

		PlayerInteractElevatorEvent() { }
	}
}
