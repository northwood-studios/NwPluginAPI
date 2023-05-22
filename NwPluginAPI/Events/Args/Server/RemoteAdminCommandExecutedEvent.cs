using CommandSystem;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Server
{
	public class RemoteAdminCommandExecutedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RemoteAdminCommandExecuted;
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

		public RemoteAdminCommandExecutedEvent(ICommandSender sender, string command, string[] arguments, bool result, string response)
		{
			Sender = sender;
			Command = command;
			Arguments = arguments;
			Result = result;
			Response = response;
		}

		RemoteAdminCommandExecutedEvent() { }
	}
}
