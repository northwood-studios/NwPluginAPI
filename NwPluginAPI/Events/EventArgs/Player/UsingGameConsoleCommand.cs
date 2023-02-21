using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all the information before a player executes a game console command.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.PlayerGameConsoleCommand"/>.
	/// </remarks>
	/// </summary>
	public class UsingGameConsoleCommand
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingGameConsoleCommand"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="command"></param>
		/// <param name="arguments"></param>
		public UsingGameConsoleCommand(IPlayer player, string command, string[] arguments)
		{
			Sender = (Core.Player)player;
			Command = command;
			Arguments = arguments;
		}

		/// <summary>
		/// Gets the player using the command.
		/// </summary>
		public Core.Player Sender { get; }

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