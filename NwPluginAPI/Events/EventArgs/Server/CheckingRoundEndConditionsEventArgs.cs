using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// Contains all the information before a check if the round can end.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.RoundEndConditionsCheck"/>.
	/// </remarks>
	/// </summary>
	public class CheckingRoundEndConditionsEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="CheckingRoundEndConditionsEventArgs"/>.
		/// </summary>
		/// <param name="baseGameConditionsSatisfied"></param>
		public CheckingRoundEndConditionsEventArgs(bool baseGameConditionsSatisfied)
		{
			BaseGameConditionsSatisfied = baseGameConditionsSatisfied;
		}

		/// <summary>
		/// Gets a value indicating if the round is going to finish.
		/// </summary>
		public bool BaseGameConditionsSatisfied { get; }
	}
}