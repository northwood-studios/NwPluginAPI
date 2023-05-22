using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerGameConsoleCommandEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerGameConsoleCommand;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public string Command { get; }
		[EventArgument]
		public string[] Arguments { get; }

		public PlayerGameConsoleCommandEvent(ReferenceHub hub, string command, string[] args)
		{
			Player = Core.Player.Get(hub);
			Command = command;
			Arguments = args;
		}

		PlayerGameConsoleCommandEvent() { }
	}
}
