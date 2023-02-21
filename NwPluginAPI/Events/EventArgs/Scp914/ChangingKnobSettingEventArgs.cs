using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using Scp914;

namespace PluginAPI.Events.EventArgs.Scp914
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp914KnobChange"/>.
	/// </summary>
	public class ChangingKnobSettingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ChangingKnobSettingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="knobSetting"></param>
		public ChangingKnobSettingEventArgs(IPlayer player, Scp914KnobSetting knobSetting)
		{
			Player = (Core.Player)player;
			KnobSetting = knobSetting;
		}

		/// <summary>
		/// Gets the player who's changing the SCP-914 knob setting.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets or sets the SCP-914 knob setting.
		/// </summary>
		public Scp914KnobSetting KnobSetting { get; set; }
	}
}