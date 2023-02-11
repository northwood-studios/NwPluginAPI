using PlayerRoles.PlayableScps.Scp106;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp106
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp106Stalking"/>.
	/// </summary>
	public class StalkingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="StalkingEventArgs"/>.
		/// </summary>
		/// <param name="scp106"></param>
		/// <param name="isActivating"></param>
		public StalkingEventArgs(IPlayer scp106, bool isActivating)
		{
			Player = (Core.Player)scp106;
			Scp106Role = Player.RoleBase as Scp106Role;
			IsActivating = isActivating;
		}

		/// <summary>
		/// Gets player playing SCP-106.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp106.Scp106Role"/> instance.
		/// </summary>
		public Scp106Role Scp106Role { get; }

		/// <summary>
		/// Get or set if the SCP-106 is entering or leaving of the ground.
		/// </summary>
		public bool IsActivating { get; set; }
	}
}