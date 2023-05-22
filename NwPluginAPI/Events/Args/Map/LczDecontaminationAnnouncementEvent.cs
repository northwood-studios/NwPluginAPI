using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Map
{
	public class LczDecontaminationAnnouncementEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.LczDecontaminationAnnouncement;
		[EventArgument]
		public int Id { get; }

		public LczDecontaminationAnnouncementEvent(int id)
		{
			Id = id;
		}

		LczDecontaminationAnnouncementEvent() { }
	}
}
