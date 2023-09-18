using CommandSystem;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Server
{
	public class ConsoleCommandEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.ConsoleCommand;
		[EventArgument]
		public ICommandSender Sender { get; }
		[EventArgument]
		public string Command { get; }
		[EventArgument]
		public string[] Arguments { get; }

		public ConsoleCommandEvent(ICommandSender sender, string command, string[] args)
		{
			Sender = sender;
			Command = command;
			Arguments = args;
		}

		ConsoleCommandEvent() { }
	}
}
