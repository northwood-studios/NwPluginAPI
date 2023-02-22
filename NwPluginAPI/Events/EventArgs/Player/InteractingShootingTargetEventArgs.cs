using AdminToys;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerInteractShootingTarget"/>.
	/// </summary>
	public class InteractingShootingTargetEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="InteractingShootingTargetEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="target"></param>
		public InteractingShootingTargetEventArgs(IPlayer player, ShootingTarget target)
		{
			Player = (Core.Player)player;
			ShootingTarget = target;
		}

		/// <summary>
		/// Gets the player interacting with the shooting target.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the shooting target being interacted with.
		/// </summary>
		public ShootingTarget ShootingTarget { get; }
	}
}