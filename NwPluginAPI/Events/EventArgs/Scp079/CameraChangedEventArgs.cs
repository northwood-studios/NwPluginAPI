using PlayerRoles.PlayableScps.Scp079;
using PlayerRoles.PlayableScps.Scp079.Cameras;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079CameraChanged"/>.
	/// </summary>
	public class CameraChangedEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CameraChangedEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="camera"></param>
		public CameraChangedEventArgs(IPlayer scp079, Scp079Camera camera, float energyCost)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Camera = camera;
			EnergyCost = energyCost;
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
		/// Get or set next camera of SCP-079.
		/// </summary>
		public Scp079Camera Camera { get; set; }

		/// <summary>
		/// Get or set energy cost for changing camera.
		/// </summary>
		public float EnergyCost { get; set; }
	}
}