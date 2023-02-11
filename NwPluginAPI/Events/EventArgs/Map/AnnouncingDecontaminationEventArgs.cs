using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Map
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.LczDecontaminationAnnouncement"/>.
	/// </summary>
	public class AnnouncingDecontaminationEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="AnnouncingDecontaminationEventArgs"/>.
		/// </summary>
		/// <param name="announceType"></param>
		public AnnouncingDecontaminationEventArgs(int announceType)
		{
			AnnounceType = announceType;
		}

		/// <summary>
		/// Get LCZ decontamination id, from 0 to 6.
		/// </summary>
		public int AnnounceType { get; }
	}
}