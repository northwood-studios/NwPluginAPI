using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerMakeNoise"/>.
	/// </summary>
	public class MakingNoiseEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="MakingNoiseEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="distance"></param>
		public MakingNoiseEventArgs(IPlayer player, Vector3 distance)
		{
			Player = (Core.Player)player;
			Distance = distance;
		}

		/// <summary>
		/// Gets the player making noise.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the footsteps distance.
		/// </summary>
		public Vector3 Distance { get; }
	}
}