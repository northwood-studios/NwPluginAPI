using CommandSystem;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// Contains all the information before a console command is executed.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.ConsoleCommand"/>.
	/// </remarks>
	/// </summary>
	public class UseConsoleCommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UseConsoleCommandEventArgs"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="command"></param>
		/// <param name="arguments"></param>
		public UseConsoleCommandEventArgs(ICommandSender sender, string command, string[] arguments)
		{
			Sender = sender;
			Command = command;
			Arguments = arguments;
		}

		/// <summary>
		/// Gets the <see cref="ICommandSender"/> that is using the command.
		/// </summary>
		public ICommandSender Sender { get; }

		/// <summary>
		/// Gets the command being executed.
		/// </summary>
		public string Command { get; }

		/// <summary>
		/// Gets the command arguments.
		/// </summary>
		public string[] Arguments { get; }
	}
}