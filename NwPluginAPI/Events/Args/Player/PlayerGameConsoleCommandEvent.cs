using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerGameConsoleCommandEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerGameConsoleCommand;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public string Command { get; }
		[EventArgument]
		public string[] Arguments { get; }

		public PlayerGameConsoleCommandEvent(ReferenceHub hub, string command, string[] args)
		{
			Player = Player.Get(hub);
			Command = command;
			Arguments = args;
		}

		PlayerGameConsoleCommandEvent() { }
	}
}
