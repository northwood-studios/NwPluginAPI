using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using RelativePositioning;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// Create a new ServerEvenType licht.
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
		public PiningEventArgs(IPlayer scp079, RelativePosition relative, int energyCost, byte pingType)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Position = relative.Position;
			EnergyCost = energyCost;
			PingType = pingType;
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
		public byte PingType { get; set; }
	}
}