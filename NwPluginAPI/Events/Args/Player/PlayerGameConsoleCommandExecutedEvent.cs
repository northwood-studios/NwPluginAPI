using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerGameConsoleCommandExecutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerGameConsoleCommandExecuted;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public string Command { get; }
		[EventArgument]
		public string[] Arguments { get; }
		[EventArgument]
		public bool Result { get; }
		[EventArgument]
		public string Response { get; set; }

		public PlayerGameConsoleCommandExecutedEvent(ReferenceHub hub, string command, string[] args, bool result, string response)
		{
			Player = Player.Get(hub);
			Command = command;
			Arguments = args;
			Result = result;
			Response = response;
		}

		PlayerGameConsoleCommandExecutedEvent() { }
	}
}
