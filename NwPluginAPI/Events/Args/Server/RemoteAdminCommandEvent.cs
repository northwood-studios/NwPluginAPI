using CommandSystem;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
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
