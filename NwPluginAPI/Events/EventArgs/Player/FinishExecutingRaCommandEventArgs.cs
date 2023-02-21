using CommandSystem;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	// I hate this events.... i don't understand its use.

	/// <summary>
	/// Contains all the information when a remote admin command is finished executing.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.RemoteAdminCommandExecuted"/>.
	/// </remarks>
	/// </summary>
	public class FinishExecutingRaCommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="FinishExecutingRaCommandEventArgs"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="command"></param>
		/// <param name="arguments"></param>
		public FinishExecutingRaCommandEventArgs(ICommandSender sender, string command, string[] arguments, bool result, string response)
		{
			Sender = sender;
			Command = command;
			Arguments = arguments;
			Result = result;
			Response = response;
		}

		/// <summary>
		/// Gets the <see cref="ICommandSender"/> of the player who's use the command.
		/// </summary>
		public ICommandSender Sender { get; }

		/// <summary>
		/// Gets the command executed.
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