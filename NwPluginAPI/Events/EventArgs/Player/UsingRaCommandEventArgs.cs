using CommandSystem;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// Contains all information before a player use a Remote admin command.
	/// <remarks>
	/// This EventArgs is for <see cref="ServerEventType.RemoteAdminCommand"/>.
	/// </remarks>
	/// </summary>
	public class UsingRaCommandEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingRaCommandEventArgs"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="command"></param>
		/// <param name="arguments"></param>
		public UsingRaCommandEventArgs(ICommandSender sender, string command, string[] arguments)
		{
			Sender = sender;
			Command = command;
			Arguments = arguments;
		}

		/// <summary>
		/// Gets the <see cref="ICommandSender"/> of the player using the command.
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