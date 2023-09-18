using CommandSystem;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Server
{
	public class ConsoleCommandExecutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.ConsoleCommandExecuted;
		[EventArgument]
		public ICommandSender Sender { get; }
		[EventArgument]
		public string Command { get; }
		[EventArgument]
		public string[] Arguments { get; }
		[EventArgument]
		public bool Result { get; }
		[EventArgument]
		public string Response { get; set; }

		public ConsoleCommandExecutedEvent(ICommandSender sender, string command, string[] args, bool result, string response)
		{
			Sender = sender;
			Command = command;
			Arguments = args;
			Result = result;
			Response = response;
		}

		ConsoleCommandExecutedEvent() { }
	}
}
