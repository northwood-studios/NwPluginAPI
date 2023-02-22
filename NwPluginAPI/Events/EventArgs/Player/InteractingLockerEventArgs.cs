using MapGeneration.Distributors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerInteractLocker"/>.
	/// </summary>
	public class InteractingLockerEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="InteractingLockerEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="locker"></param>
		/// <param name="chamber"></param>
		/// <param name="chamberId"></param>
		/// <param name="canOpen"></param>
		public InteractingLockerEventArgs(IPlayer player, Locker locker, LockerChamber chamber, byte chamberId,
			bool canOpen)
		{
			Player = (Core.Player)player;
			Locker = locker;
			Chamber = chamber;
			ChamberId = chamberId;
			CanOpen = canOpen;
		}

		public Core.Player Player { get; }

		/// <summary>
		/// Gets the <see cref="Locker"/> instance.
		/// </summary>
		public Locker Locker { get; }

		/// <summary>
		/// Gets the interacting chamber.
		/// </summary>
		public LockerChamber Chamber { get; }

		/// <summary>
		/// Gets chamber id.
		/// </summary>
		public byte ChamberId { get; }

		/// <summary>
		/// Gets or sets a value indicating whether or not the player can open the locker.
		/// </summary>
		public bool CanOpen { get; set; }
	}
}