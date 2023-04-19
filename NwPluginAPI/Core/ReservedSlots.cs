using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI.Core
{
	public class ReservedSlots
	{
		/// <summary>
		/// Path to UserIDReservedSlots file.
		/// </summary>
		public static string FilePath => ConfigSharing.Paths[3] + "UserIDReservedSlots.txt";

		/// <summary>
		/// List of all reserved slots.
		/// </summary>
		public static readonly IEnumerable<string> List = ReservedSlot.Users;

		/// <summary>
		/// Amount of players with reserverd slots.
		/// </summary>
		public static readonly int Count = ReservedSlot.Users.Count;

		/// <summary>
		/// Checks if player is on reserverd slots.
		/// </summary>
		/// <param name="userId">The userid.</param>
		/// <returns>If player is on reserved slots.</returns>
		public static bool HasReservedSlot(string userId) => ReservedSlot.Users.Contains(userId);

		/// <summary>
		/// Reloads reserverd slots.
		/// </summary>
		public static void Reload() => ReservedSlot.Reload();

		/// <summary>
		/// Adds player to reserved slots and saves it to file.
		/// </summary>
		/// <param name="userId">The userid.</param>
		public static void Add(string userId)
		{
			if (HasReservedSlot(userId)) return;

			List<string> lines = FileManager.ReadAllLines(FilePath).ToList();

			lines.Add($"{userId}");

			FileManager.WriteToFile(lines, FilePath);
			ReservedSlot.Users.Add(userId);
		}

		/// <summary>
		/// Removes player from reserverd slots and saves it to file.
		/// </summary>
		/// <param name="userId">The userid.</param>
		public static void Remove(string userId)
		{
			if (!HasReservedSlot(userId)) return;

			List<string> lines = FileManager.ReadAllLines(FilePath).ToList();

			lines.RemoveAll(x => x.Contains(userId));

			FileManager.WriteToFile(lines, FilePath);
			ReservedSlot.Users.Remove(userId);
		}
	}
}
