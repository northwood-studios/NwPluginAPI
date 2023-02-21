using CommandSystem;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// Contains all the information when a console command is finished executing.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.ConsoleCommandExecuted"/>.
	/// </remarks>
	/// </summary>
	public class FinishExecutingConsoleCommand
	{
		/// <summary>
		/// Initializes a new instance of <see cref="FinishExecutingConsoleCommand"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="command"></param>
		/// <param name="arguments"></param>
		/// <param name="result"></param>
		/// <param name="response"></param>
		public FinishExecutingConsoleCommand(ICommandSender sender, string command, string[] arguments, bool result,
			string response)
		{
			Sender = sender;
			Command = command;
			Arguments = arguments;
			Result = result;
			Response = response;
		}

		/// <summary>
		/// Gets the <see cref="ICommandSender"/> that use the command.
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

		/// <summary>
		/// Gets the command result
		/// </summary>
		public bool Result { get; }

		/// <summary>
		/// Gets the command response.
		/// </summary>
		public string Response { get; }
	}
}