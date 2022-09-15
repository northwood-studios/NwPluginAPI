namespace PluginAPI.Commands
{
	using CommandSystem;
	using PluginAPI.Loader;
	using System;
	using System.Collections.Generic;

	[CommandHandler(typeof(PluginsCommand))]
	public class ReloadCommmand : ICommand
	{
		public string Command { get; } = "reload";
		public string[] Aliases { get; } = null;
		public string Description { get; } = "Reload of plugins configs.";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			List<string> plugins = new List<string>();
			foreach (var plugin in AssemblyLoader.InstalledPlugins)
			{
				plugins.Add($"<color=lime>{(plugin.PluginName)}</color>");
			}

			response = $"{(plugins.Count == 0 ? "Reloaded 0 plugin configs!" : $"Reloaded {string.Join(", ", plugins)} plugin configs!")}";
			return true;
		}
	}
}