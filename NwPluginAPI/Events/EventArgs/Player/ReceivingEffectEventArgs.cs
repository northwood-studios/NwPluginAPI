using CustomPlayerEffects;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerReceiveEffect"/>.
	/// </summary>
	public class ReceivingEffectEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ReceivingEffectEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="effect"></param>
		/// <param name="intensity"></param>
		/// <param name="duration"></param>
		public ReceivingEffectEventArgs(IPlayer player, StatusEffectBase effect, byte intensity, float duration)
		{
			Player = (Core.Player)player;
			Effect = effect;
			Intensity = intensity;
			Duration = duration;
		}

		/// <summary>
		/// Gets the player receiving the effect.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the effect being received.
		/// </summary>
		public StatusEffectBase Effect { get; }

		/// <summary>
		/// Get or set effect intensity.
		/// </summary>
		public byte Intensity { get; set; }

		/// <summary>
		/// Get or set effect duration.
		/// </summary>
		public float Duration { get; set; }
	}
}