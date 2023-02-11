using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.RoundEnd"/>.
	/// </summary>
	public class EndingRoundEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="EndingRoundEventArgs"/>.
		/// </summary>
		/// <param name="leadingTeam"></param>
		/// <param name="classList"></param>
		public EndingRoundEventArgs(RoundSummary.LeadingTeam leadingTeam, RoundSummary.SumInfo_ClassList classList)
		{
			LeadingTeam = leadingTeam;
			ClassList = classList;
		}

		/// <summary>
		/// Get or set leading team.
		/// </summary>
		public RoundSummary.LeadingTeam LeadingTeam { get; set; }

		/// <summary>
		/// Get or set round summary class list.
		/// </summary>
		public RoundSummary.SumInfo_ClassList ClassList { get; set; }
	}
}