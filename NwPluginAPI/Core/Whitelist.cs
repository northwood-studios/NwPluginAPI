using GameCore;
using System.Collections.Generic;
using System.Linq;

namespace PluginAPI.Core
{
	public class Whitelist
	{
		/// <summary>
		/// Path to UserIDWhitelist file.
		/// </summary>
		public static string FilePath => ConfigSharing.Paths[2] + "UserIDWhitelist.txt";

		/// <summary>
		/// List of all whitelisted users.
		/// </summary>
		public static readonly IEnumerable<string> List = WhiteList.Users;

		/// <summary>
		/// Amount of players whitelisted.
		/// </summary>
		public static readonly int Count = WhiteList.Users.Count;

		/// <summary>
		/// Checks if player is on whitelist.
		/// </summary>
		/// <param name="userId">The userid.</param>
		/// <returns>If player is on whitelist.</returns>
		public static bool IsOnWhitelist(string userId) => WhiteList.IsOnWhitelist(userId);

		/// <summary>
		/// Reloads whitelist.
		/// </summary>
		public static void Reload() => WhiteList.Reload();

		/// <summary>
		/// Adds player to whitelist and saves it to file.
		/// </summary>
		/// <param name="userId">The userid.</param>
		public static void Add(string userId)
		{
			if (IsOnWhitelist(userId)) return;

			List<string> lines = FileManager.ReadAllLines(FilePath).ToList();

			lines.Add($"{userId}");

			FileManager.WriteToFile(lines, FilePath);
			WhiteList.Users.Add(userId);
		}

		/// <summary>
		/// Removes player from whitelist and saves it to file.
		/// </summary>
		/// <param name="userId">The userid.</param>
		public static void Remove(string userId)
		{
			if (!IsOnWhitelist(userId)) return;

			List<string> lines = FileManager.ReadAllLines(FilePath).ToList();

			lines.RemoveAll(x => x.Contains(userId));

			FileManager.WriteToFile(lines, FilePath);
			WhiteList.Users.Remove(userId);
		}
	}
}
