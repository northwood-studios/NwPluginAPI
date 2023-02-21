using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information when a player console command is finished executing.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerGameConsoleCommandExecuted"/>.
	/// </remarks>
	/// </summary>
	public class FinishExecutingGameConsoleCommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="FinishExecutingGameConsoleCommandEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="command"></param>
		/// <param name="arguments"></param>
		/// <param name="result"></param>
		/// <param name="response"></param>
		public FinishExecutingGameConsoleCommandEventArgs(IPlayer player, string command, string[] arguments, bool result, string response)
		{
			Sender = (Core.Player)player;
			Command = command;
			Arguments = arguments;
			Result = result;
			Response = response;
		}

		/// <summary>
		/// Gets the player who's use the command.
		/// </summary>
		public Core.Player Sender { get; }

		/// <summary>
		/// Gets the command executed.
		/// </summary>
		public string Command { get; }

		/// <summary>
		/// Gets the command arguments.
		/// </summary>
		public string[] Arguments { get; }

		/// <summary>
		/// Gets command result
		/// </summary>
		public bool Result { get; }

		/// <summary>
		/// Gets command response.
		/// </summary>
		public string Response { get; }
	}
}