namespace PluginAPI.Commands
{
	using System;
	using System.Collections.Generic;
	using CommandSystem;
	using Loader;

	/// <summary>
	/// Lists all plugins on the server.
	/// </summary>
	public class ListCommand : ICommand
	{
		public string Command { get; } = "list";
		public string[] Aliases { get; } = null;
		public string Description { get; } = "List of installed plugins.";
		public bool SanitizeResponse { get; } = false;
		public static ListCommand Instance = new();

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			var plugins = new List<string>();
			foreach (var plugin in AssemblyLoader.InstalledPlugins)
			{
				plugins.Add(
					$"<color=lime>{plugin.PluginName}</color> v<color=orange>{plugin.PluginVersion}</color> - <color=blue>{plugin.PluginAuthor}</color>\n");
			}

			response = $"Plugins: {(plugins.Count == 0 ? "0 plugins enabled" : string.Join(", ", plugins))}";
			return true;
		}
	}
}