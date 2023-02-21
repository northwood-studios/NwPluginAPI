using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerDamagedWindow"/>.
	/// </summary>
	public class DamagingWindowEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="DamagingWindowEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="window"></param>
		/// <param name="damageAmount"></param>
		public DamagingWindowEventArgs(IPlayer player, BreakableWindow window, float damageAmount)
		{
			Player = (Core.Player)player;
			Window = window;
			Amount = damageAmount;
		}
		/// <summary>
		/// Gets player damaging a window.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets <see cref="BreakableWindow"/> that is being damaged.
		/// </summary>
		public BreakableWindow Window { get; }

		/// <summary>
		/// Get or set damaged deal.
		/// </summary>
		public float Amount { get; set; }
	}
}