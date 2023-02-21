using InventorySystem.Items.Radio;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerChangeRadioRange"/>.
	/// </summary>
	public class ChangingRadioRangeEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChangingRadioRangeEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="radio"></param>
		/// <param name="range"></param>
		public ChangingRadioRangeEventArgs(IPlayer player, RadioItem radio, RadioMessages.RadioRangeLevel range)
		{
			Player = (Core.Player)player;
			Radio = radio;
			NewRange = range;
		}

		/// <summary>
		/// Gets player who's is triggering this action.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets radio item.
		/// </summary>
		public RadioItem Radio { get; }

		/// <summary>
		/// Get or set new radio range.
		/// </summary>
		public RadioMessages.RadioRangeLevel NewRange { get; set; }
	}
}