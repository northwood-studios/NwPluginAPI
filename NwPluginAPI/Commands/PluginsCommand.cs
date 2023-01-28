namespace PluginAPI.Commands
{
	using CommandSystem;
	using System;
	using UnityEngine;

	/// <summary>
	/// The parent command for the NW-API commands.
	/// </summary>
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	public class PluginsCommand : ParentCommand, IUsageProvider
	{
		public override string Command { get; } = "plugins";
		public override string[] Aliases { get; } = { "pluign", "pluginapi" };
		public override string Description { get; } = "Commands for plugin api system.";
		public string[] Usage { get; } = { "list/reload" };

		public static PluginsCommand Create()
		{
			PluginsCommand command = new PluginsCommand();
			command.LoadGeneratedCommands();
			return command;
		}

		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender,
			out string response)
		{
			response = $"Available commands: <color=green>list/reload</color>";
			return true;
		}

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(ReloadConfigCommand.Instance);
			RegisterCommand(ListCommand.Instance);
			Debug.LogError("Command loading has not been patched!");
		}
	}
}