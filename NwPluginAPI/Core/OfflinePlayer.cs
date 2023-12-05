using PluginAPI.Core.Interfaces;

namespace PluginAPI.Core
{
	public class OfflinePlayer : IPlayer
	{
		/// <summary>
		/// Gets if the player is in the server.
		/// </summary>
		public bool IsOffline { get; }

		/// <summary>
		/// Gets the player's user id.
		/// </summary>
		public string UserId { get; private set; }

		/// <summary>
		/// Gets the player's name.
		/// </summary>
		public string Nickname { get; private set; }

		/// <summary>
		/// Gets the player's ip address.
		/// </summary>
		public string IpAddress { get; private set; }

		/// <summary>
		/// Constructor for offline player.
		/// </summary>
		/// <param name="userId">The user id.</param>
		/// <param name="name">The nick name.</param>
		/// <param name="ipAddress">The ip address.</param>
		public OfflinePlayer(string userId, string name = "(no nick)", string ipAddress = "127.0.0.1")
		{
			IsOffline = true;
			UserId = userId;
			Nickname = name;
			IpAddress = ipAddress;
		}
	}
}
