using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using Scp914;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Scp914
{
	/// <summary>
	/// Contains all information before a player is processed by SCP-914
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.Scp914ProcessPlayer"/>.
	/// </remarks>
	/// </summary>
	public class ProcessingPlayerEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="ProcessingPlayerEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="knobSetting"></param>
		/// <param name="outPosition"></param>
		public ProcessingPlayerEventArgs(IPlayer player, Scp914KnobSetting knobSetting, Vector3 outPosition)
		{
			Player = (Core.Player)player;
			KnobSetting = knobSetting;
			OutPosition = outPosition;
		}

		/// <summary>
		/// Gets the player process.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Get the knob setting by which the player is being process.
		/// </summary>
		public Scp914KnobSetting KnobSetting { get; }

		/// <summary>
		/// Get or set player out position.
		/// </summary>
		public Vector3 OutPosition { get; set; }
	}
}