namespace PluginAPI.Commands
{
	using CommandSystem;
	using PluginAPI.Core;

	/// <summary>
	/// Represents a command that can be executed.
	/// </summary>
	public class Command
	{
		public ICommand Object;
		public PluginHandler Plugin;
	}
}