using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Map
{
	/// <summary>
	/// This EventArgs is for ServerEvenType.<see cref="ServerEventType.PlaceBulletHole"/>
	/// </summary>
	public class PlacingBulletHoleEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PlacingBulletHoleEventArgs"/>.
		/// </summary>
		/// <param name="shooter"></param>
		/// <param name="hit"></param>
		public PlacingBulletHoleEventArgs(IPlayer shooter, RaycastHit hit)
		{
			Player = (Core.Player)shooter;
			Position = hit.point;
			Rotation = Quaternion.LookRotation(hit.normal);
		}

		/// <summary>
		/// Gets player that put the bullet hole
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get or set bullet hole position.
		/// </summary>
		public Vector3 Position { get; set; }

		/// <summary>
		/// Get or set bullet hole rotation.
		/// </summary>
		public Quaternion Rotation { get; set; }
	}
}