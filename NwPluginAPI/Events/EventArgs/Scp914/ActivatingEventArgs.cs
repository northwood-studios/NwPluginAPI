using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using Scp914;

namespace PluginAPI.Events.EventArgs.Scp914
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp914Activate"/>.
	/// </summary>
	public class ActivatingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ActivatingEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="knobSetting"></param>
		public ActivatingEventArgs(IPlayer player, Scp914KnobSetting knobSetting)
		{
			Player = (Core.Player)player;
			KnobSetting = knobSetting;
		}

		/// <summary>
		/// Gets the player who's activated the SCP-914.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the Knob setting with which SCP-914 was activated.
		/// </summary>
		public Scp914KnobSetting KnobSetting { get; }
	}
}