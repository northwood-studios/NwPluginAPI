using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerGetGroupEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerGetGroup;
		[EventArgument]
		public string UserId { get; }
		[EventArgument]
		public UserGroup Group { get; }

		public PlayerGetGroupEvent(string userId, UserGroup group)
		{
			UserId = userId;
			Group = group;
		}

		PlayerGetGroupEvent() { }
	}
}
