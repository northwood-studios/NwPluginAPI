using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using RelativePositioning;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// Contains all information before SCP-079 pinged the map.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp079Pining"/>.
	/// </remarks>
	/// </summary>
	public class PiningEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PiningEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="position"></param>
		/// <param name="energyCost"></param>
		/// <param name="pingType"></param>
		public PiningEventArgs(IPlayer scp079, RelativePosition relative, int energyCost, byte proccesorindex)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Position = relative.Position;
			EnergyCost = energyCost;
			PingType = (PingType)proccesorindex;
		}

		/// <summary>
		/// Gets player playing SCP-079.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp079.Scp079Role"/> instance.
		/// </summary>
		public Scp079Role Scp079Role { get; }

		/// <summary>
		/// Gets or set ping position.
		/// </summary>
		public Vector3 Position { get; set; }

		/// <summary>
		/// Get or set SCP-079 energy cost.
		/// </summary>
		public int EnergyCost { get; set; }

		/// <summary>
		/// Get or set ping type.
		/// </summary>
		public PingType PingType { get; set; }
	}
}