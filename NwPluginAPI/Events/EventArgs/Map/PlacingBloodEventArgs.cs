using JetBrains.Annotations;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Map
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlaceBlood"/>.
	/// </summary>
	public class PlacingBloodEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PlacingBloodEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="hit"></param>
		public PlacingBloodEventArgs(IPlayer player, RaycastHit hit)
		{
			Player = (Core.Player)player;
			Position = hit.point;
		}

		/// <summary>
		/// Gets the player who is bleeding.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get or set blood position.
		/// </summary>
		public Vector3 Position { get; set; }
	}
}