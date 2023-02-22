using InventorySystem.Items.Radio;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player drains the battery of his radio
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerUsingRadio"/>.
	/// </remarks>
	/// </summary>
	public class UsingRadioBatteryEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingRadioBatteryEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="radio"></param>
		/// <param name="drain"></param>
		public UsingRadioBatteryEventArgs(IPlayer player, RadioItem radio, float drain)
		{
			Player = (Core.Player)player;
			Radio = radio;
			Drain = drain;
		}

		/// <summary>
		/// Gets the player using the radio.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the radio being used.
		/// </summary>
		public RadioItem Radio { get; }

		/// <summary>
		/// Get or set the radio drain battery percent.
		/// </summary>
		public float Drain { get; set; }
	}
}