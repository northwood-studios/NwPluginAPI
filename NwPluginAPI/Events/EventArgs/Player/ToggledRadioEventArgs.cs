using InventorySystem.Items.Radio;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player changes the state of his radio
	/// <remarks>This EventArgs is for <see cref="ServerEventType.PlayerRadioToggle"/>.</remarks>
	/// </summary>
	public class ToggledRadioEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ToggledRadioEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="radio"></param>
		/// <param name="newState"></param>
		public ToggledRadioEventArgs(IPlayer player, RadioItem radio, bool newState)
		{
			Player = (Core.Player)player;
			Radio = radio;
			NewState = newState;
		}

		/// <summary>
		/// Gets the player toggling the radio
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the radio who is begin toggle
		/// </summary>
		public RadioItem Radio { get; }

		/// <summary>
		/// Get or set new radio state.
		/// <remarks>On or off</remarks>
		/// </summary>
		public bool NewState { get; set; }
	}
}