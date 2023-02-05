using PlayerRoles.PlayableScps.Scp173;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp173
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp173PlaySound"/>.
	/// </summary>
	public class PlayingSoundEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PlayingSound"/>.
		/// </summary>
		/// <param name="scp173">The player due to this event is executing</param>
		/// <param name="soundId">Sound id</param>
		public PlayingSoundEventArgs(IPlayer scp173, Scp173AudioPlayer.Scp173SoundId soundId)
		{
			Player = (Player)scp173;
			Scp173Role = Player.RoleBase as Scp173Role;
			SoundId = soundId;
		}

		/// <summary>
		/// Gets player playing SCP-173.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp173.Scp173Role"/> instance.
		/// </summary>
		public Scp173Role Scp173Role { get; }

		/// <summary>
		/// Gets or set sound id.
		/// </summary>
		public Scp173AudioPlayer.Scp173SoundId SoundId { get; set; }
	}
}