using CommandSystem;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Server
{
	public class RemoteAdminCommandEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RemoteAdminCommand;
		[EventArgument]
		public ICommandSender Sender { get; }
		[EventArgument]
		public string Command { get; }
		[EventArgument]
		public string[] Arguments { get; }

		public RemoteAdminCommandEvent(ICommandSender sender, string command, string[] arguments)
		{
			Sender = sender;
			Command = command;
			Arguments = arguments;
		}

		RemoteAdminCommandEvent() { }
	}
}
