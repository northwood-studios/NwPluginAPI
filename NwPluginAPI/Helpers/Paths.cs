namespace PluginAPI.Helpers
{
	using System;
	using System.IO;
	using Core;
	using Loader.Features;
	using NorthwoodLib;

	/// <summary>
	/// Contains all important folder paths.
	/// </summary>
	public static class Paths
	{
		/// <summary>
		/// Gets the path to global config folder.
		/// </summary>
		public static string Global { get; private set; }

		/// <summary>
		/// Gets the paths to global plugins and dependencies.
		/// </summary>
		public static PluginDirectory GlobalPlugins { get; internal set; }

		/// <summary>
		/// Gets the paths to this server port's plugins and dependencies.
		/// </summary>
		public static PluginDirectory LocalPlugins { get; internal set; }

		/// <summary>
		/// Gets the path to the server's config settings.
		/// </summary>
		public static string Configs { get; private set; }

		/// <summary>
		/// Gets the path to the system's AppData folder.
		/// </summary>
		public static string AppData { get; private set; }

		/// <summary>
		/// Gets the path to the "Secret Laboratory" folder, located inside AppData.
		/// </summary>
		public static string SecretLab { get; private set; }

		/// <summary>
		/// Gets the path to the "Plugin API" folder, located inside the "SCP Secret laboratory Dedicated Server" folder.
		/// </summary>
		public static string PluginAPI { get; private set; }

		/// <summary>
		/// Gets the path to the "Plugins" folder, located inside the "Plugin API" folder.
		/// </summary>
		public static string Plugins { get; private set; }

		/// <summary>
		/// Gets the path to the "Dependencies" folder, located inside the "Plugins" folder.
		/// </summary>
		public static string Dependencies { get; private set; }

		/// <summary>
		/// Intializes all the paths.
		/// </summary>
		internal static void Setup()
		{
			AppData = GetHosterPolicy() ? 
				"AppData" : 
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			if (!Directory.Exists(AppData)) Directory.CreateDirectory(AppData);

			SecretLab = GetDirectory(AppData, "SCP Secret Laboratory");

			PluginAPI = GetDirectory(SecretLab, "PluginAPI");
			Plugins = GetDirectory(PluginAPI, "plugins");

			GlobalPlugins = new PluginDirectory(GetDirectory(Plugins, "global"));
			LocalPlugins = new PluginDirectory(GetDirectory(Plugins, Server.Port.ToString()));
		}

		internal static bool GetHosterPolicy()
		{
			if (!File.Exists("hoster_policy.txt"))
				return false;

			var lines = File.ReadAllLines("hoster_policy.txt");

			foreach (var l in lines)
			{
				if (!l.Contains("gamedir_for_configs: true", StringComparison.OrdinalIgnoreCase))
					continue;

				return true;
			}

			return false;
		}

		/// <summary>
		/// Similar to <see cref="Path.Combine(string, string)"/>, will combine two paths and create the directory if it doesn't.
		/// </summary>
		/// <param name="path1">Path to be combined with <paramref name="path2"/>.</param>
		/// <param name="path2">Path to be combined with <paramref name="path2"/>.</param>
		/// <returns>The two paths combined.</returns>
		internal static string GetDirectory(string path1, string path2)
		{
			string combinedPath = Path.Combine(path1, path2);

			if (!Directory.Exists(combinedPath))
				Directory.CreateDirectory(combinedPath);

			return combinedPath;
		}
	}
}
