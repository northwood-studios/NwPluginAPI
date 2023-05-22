using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp939
{
	public class Scp939CreateAmnesticCloudEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp939CreateAmnesticCloud;
		[EventArgument]
		public Player Player { get; }

		public Scp939CreateAmnesticCloudEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		Scp939CreateAmnesticCloudEvent() { }
	}
}
