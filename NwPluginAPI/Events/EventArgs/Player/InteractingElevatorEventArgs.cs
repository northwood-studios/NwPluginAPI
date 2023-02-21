using Interactables.Interobjects;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerInteractElevator"/>.
	/// </summary>
	public class InteractingElevatorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="InteractingElevatorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="elevator"></param>
		public InteractingElevatorEventArgs(IPlayer player, ElevatorChamber elevator)
		{
			Player = (Core.Player)player;
			Elevator = elevator;
		}

		/// <summary>
		/// Gets player who's is interacting with a elevator.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the elevator interacted.
		/// </summary>
		public ElevatorChamber Elevator { get; }
	}
}