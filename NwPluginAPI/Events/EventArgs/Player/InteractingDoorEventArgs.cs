using Interactables.Interobjects.DoorUtils;
using PluginAPI.Core.Doors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player interact with a door.
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerInteractDoor"/>.</remarks>
	/// </summary>
	public class InteractingDoorEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="InteractingDoorEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="doorVariant"></param>
		/// <param name="canOpen"></param>
		public InteractingDoorEventArgs(IPlayer player, DoorVariant doorVariant, bool canOpen)
		{
			Player = (Core.Player)player;
			Door = FacilityDoor.Get(doorVariant);
			CanOpen = canOpen;
		}

		/// <summary>
		/// Gets the player trying to open a door.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the door who's the players is interacting
		/// </summary>
		public FacilityDoor Door { get; }

		/// <summary>
		/// Get or set a value indicating if the player can open or not the door.
		/// </summary>
		public bool CanOpen { get; set; }
	}
}