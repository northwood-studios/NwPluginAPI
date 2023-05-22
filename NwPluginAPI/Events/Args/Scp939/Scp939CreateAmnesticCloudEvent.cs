using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp939
{
	public class Scp939CreateAmnesticCloudEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp939CreateAmnesticCloud;
		[EventArgument]
		public Core.Player Player { get; }

		public Scp939CreateAmnesticCloudEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		Scp939CreateAmnesticCloudEvent() { }
	}
}
