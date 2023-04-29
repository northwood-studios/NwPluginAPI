namespace PluginAPI.Commands
{
	using CommandSystem;
	using Loader;
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Reloads plugins or gameplay configs.
	/// </summary>
	public class ReloadConfigCommand : ICommand, IUsageProvider
	{
		public string Command { get; } = "reload";
		public string[] Aliases { get; } = null;
		public string Description { get; } = "Reload plugins configuration or config_gameplay";
		public string[] Usage { get; } = { "plugins/gameplay" };

		public static ReloadConfigCommand Instance = new();

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.IsEmpty())
			{
				response =
					$"Please specify a valid argument\nUsage: {arguments.Array[0]} {arguments.Array[1]} {this.DisplayCommandUsage()}";
				return false;
			}

			switch (arguments.At(0).ToLowerInvariant())
			{
				case "plugins":
				{
					var plugins = new List<string>();

					foreach (var plugin in AssemblyLoader.InstalledPlugins)
					{
						plugin.ReloadConfig(plugin);
						plugins.Add($"<color=lime>{plugin.PluginName}</color>");
					}

					response =
						$"{(plugins.Count == 0 ? "Reloaded 0 plugin configs!" : $"Reloaded {string.Join(", ", plugins)} plugin configs!")}";
					return true;
				}
				case "gameplay":
				{
					GameCore.ConfigFile.ReloadGameConfigs();
					response = $"config_gameplay successfully reloaded";
					return true;
				}
				default:
				{
					response = $"Please specify a valid argument\nUsage: plugins reload {this.DisplayCommandUsage()}";
					return false;
				}
			}
		}
	}
}