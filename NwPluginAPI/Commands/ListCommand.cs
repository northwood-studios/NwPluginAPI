namespace PluginAPI.Commands
{
    using System;
    using System.Collections.Generic;
    using CommandSystem;
    using Loader;

    [CommandHandler(typeof(PluginsCommand))]
	public class ListCommand : ICommand
	{
		/// <inheritdoc/>
		public string Command { get; } = "list";
		/// <inheritdoc/>
		public string[] Aliases { get; } = null;
		/// <inheritdoc/>
        public string Description { get; } = "List of installed plugins.";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			List<string> plugins = new List<string>();
			foreach (var plugin in AssemblyLoader.InstalledPlugins)
			{
				plugins.Add($"<color=lime>{(plugin.PluginName)}</color> v<color=orange>{plugin.PluginVersion}</color>");
			}

			response = $"Plugins: {(plugins.Count == 0 ? "0 plugins enabled" : string.Join(", ", plugins))}";
			return true;
		}
	}
}