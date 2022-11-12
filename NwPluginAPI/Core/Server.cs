namespace PluginAPI.Core
{
	using System.Collections.Generic;
	using Mirror;
	using Interfaces;
	using RoundRestarting;
	using static BanHandler;
	using static Broadcast;

	public class Server : Player
	{
		/// <summary>
		/// Instance of server.
		/// </summary>
		public static Server Instance { get; private set; }

		/// <summary>
		/// Constructor for server.
		/// </summary>
		/// <param name="hub">The hub of server.</param>
		public Server(IGameComponent hub) : base(hub)
		{
			Instance = this;
		}

		/// <summary>
		/// Gets the Ip address of the server.
		/// </summary>
		public static string ServerIpAddress => ServerConsole.Ip;

		/// <summary>
		/// Gets the port of the server.
		/// </summary>
		public static ushort Port => ServerStatic.ServerPort;

		/// <summary>
		/// Gets or sets a value if server has enabled friendly fire.
		/// </summary>
		public static bool FriendlyFire
		{
			get => ServerConsole.FriendlyFire;
			set => ServerConsole.FriendlyFire = value;
		}

		/// <summary>
		/// Gets or sets a value of maximum online players.
		/// </summary>
		public static int MaxPlayers
		{
			get => CustomNetworkManager.slots;
			set => CustomNetworkManager.slots = value;
		}

		#region Ban System
		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="player">The target player which will be banned.</param>
		/// <param name="reason">The reason of ban.</param>
		/// <param name="duration">The duration of ban in seconds.</param>
		/// <returns>If ban is successful.</returns>
		public static bool BanPlayer(Player player, string reason, long duration) => global::BanPlayer.BanUser(player.ReferenceHub, reason, duration);

		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="player">The player which gets banned.</param>
		/// <param name="issuer">The player which issued ban.</param>
		/// <param name="reason">The reason of ban.</param>
		/// <param name="duration">The duration of ban in seconds.</param>
		/// <returns>If ban is successful.</returns>
		public static bool BanPlayer(Player player, IPlayer issuer, string reason, long duration) => global::BanPlayer.BanUser(player.ReferenceHub, issuer.ReferenceHub, reason, duration);

		/// <summary>
		/// Kicks player from server.
		/// </summary>
		/// <param name="player">The player which will be kicked.</param>
		/// <param name="issuer">The player which issued kick.</param>
		/// <param name="reason">The reason of kick.</param>
		public static void KickPlayer(Player player, IPlayer issuer, string reason) => global::BanPlayer.KickUser(player.ReferenceHub, issuer.ReferenceHub, reason);

		/// <summary>
		/// Kicks player from server.
		/// </summary>
		/// <param name="player">The player which will be kicked.</param>
		/// <param name="reason">The reason of kick.</param>
		public static void KickPlayer(Player player, string reason) => global::BanPlayer.KickUser(player.ReferenceHub, reason);

		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="userId">The userid of player which will be banned.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of banned player.</param>
		/// <returns>If ban is successful.</returns>
		public static bool BanPlayerByUserId(string userId, string reason, long duration, string bannedPlayerNickname = "UnknownName") => BanPlayerByUserId(userId, Instance, reason, duration, bannedPlayerNickname);

		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="userId">The userid of player which will be banned.</param>
		/// <param name="issuer">The issuer of ban.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of banned player.</param>
		/// <returns>If ban is successful.</returns>
		public static bool BanPlayerByUserId(string userId, Player issuer, string reason, long duration, string bannedPlayerNickname = "UnknownName")
		{
			if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(reason)) return false;

			return IssueBan(new BanDetails()
			{
				Id = userId,
				IssuanceTime = TimeBehaviour.CurrentTimestamp(),
				Expires = TimeBehaviour.GetBanExpirationTime((uint)duration),
				Issuer = issuer.UserId,
				OriginalName = bannedPlayerNickname,
				Reason = reason,
			}, BanType.UserId);
		}

		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="ipAddress">The ip address of player which will be banned.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of banned player.</param>
		/// <returns>If ban is successful.</returns>
		public static bool BanPlayerByIpAddress(string ipAddress, string reason, long duration, string bannedPlayerNickname = "UnknownName") => BanPlayerByIpAddress(ipAddress, Instance, reason, duration, bannedPlayerNickname);

		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="ipAddress">The ip address of player which will be banned.</param>
		/// <param name="issuer">The issuer of ban.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of banned player.</param>
		/// <returns>If ban is successful.</returns>
		public static bool BanPlayerByIpAddress(string ipAddress, Player issuer, string reason, long duration, string bannedPlayerNickname = "UnknownName")
		{
			if (string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(reason)) return false;

			return IssueBan(new BanDetails()
			{
				Id = ipAddress,
				IssuanceTime = TimeBehaviour.CurrentTimestamp(),
				Expires = TimeBehaviour.GetBanExpirationTime((uint)duration),
				Issuer = issuer.UserId,
				OriginalName = bannedPlayerNickname,
				Reason = reason,
			}, BanType.IP);
		}

		/// <summary>
		/// Unbans player from server.
		/// </summary>
		/// <param name="userId">The userid of player.</param>
		/// <returns>If unban is successful.</returns>
		public static bool UnbanPlayerByUserId(string userId)
		{
			if (string.IsNullOrEmpty(userId)) return false;

			if (!IsPlayerBanned(userId)) return false;

			RemoveBan(userId, BanType.UserId);
			return true;
		}

		/// <summary>
		/// Unbans player from server.
		/// </summary>
		/// <param name="ipAddress">The ip address of player.</param>
		/// <returns>If unban is successful.</returns>
		public static bool UnbanPlayerByIpAddress(string ipAddress)
		{
			if (string.IsNullOrEmpty(ipAddress)) return false;

			if (!IsPlayerBanned(ipAddress)) return false;

			RemoveBan(ipAddress, BanType.IP);
			return true;
		}

		/// <summary>
		/// Checks if player is banned.
		/// </summary>
		/// <param name="value">The value can be as userid or ip address of player.</param>
		/// <returns>If player is banned.</returns>
		public static bool IsPlayerBanned(string value)
		{
			if (string.IsNullOrEmpty(value)) return false;

			return (value.Contains("@") ? GetBan(value, BanType.UserId) : GetBan(value, BanType.IP)) != null;
		}

		/// <summary>
		/// Gets all banned players.
		/// </summary>
		/// <returns>List of all banned players.</returns>
		public static BanDetails[] GetAllPlayersBanned()
		{
			List<BanDetails> bans = GetBans(BanType.UserId);
			bans.AddRange(GetBans(BanType.IP));
			return bans.ToArray();
		}

		/// <summary>
		/// Gets all banned players.
		/// </summary>
		/// <param name="banType">The type of ban.</param>
		/// <returns>List of specified ban types.</returns>
		public static BanDetails[] GetAllPlayersBanned(BanType banType) => GetBans(banType).ToArray();
		#endregion

		/// <summary>
		/// Restarts the server and reconnects all players.
		/// </summary>
		public static void Restart() => Round.Restart(false, true, ServerStatic.NextRoundAction.Restart);

		/// <summary>
		/// Restarts the server and reconnects all players to target server port.
		/// </summary>
		public static void Restart(ushort redirectPort)
		{
			NetworkServer.SendToAll(new RoundRestartMessage(RoundRestartType.RedirectRestart, 0.1f, redirectPort, true, false));
			Round.Restart(false, true, ServerStatic.NextRoundAction.Restart);
		}

		/// <summary>
		/// Shutdowns the server and disconnects all players.
		/// </summary>
		public static void Shutdown() => global::Shutdown.Quit();

		/// <summary>
		/// Shutdowns the server and reconnects all players to target server port.
		/// </summary>
		public static void Shutdown(ushort redirectPort)
		{
			NetworkServer.SendToAll(new RoundRestartMessage(RoundRestartType.RedirectRestart, 0.0f, redirectPort, true, false));
			Shutdown();
		}

		/// <summary>
		/// Run command as server.
		/// </summary>
		/// <param name="command">The command name.</param>
		/// <param name="sender">The <see cref="CommandSender"/> running the command.</param>
		public static string RunCommand(string command, CommandSender sender = null) => ServerConsole.EnterCommand(command, sender);

		/// <summary>
		/// Shows a broadcast to the player.
		/// </summary>
		/// <param name="message">The message to be broadcasted.</param>
		/// <param name="duration">The broadcast duration.</param>
		/// <param name="type">The broadcast type.</param>
		/// <param name="shouldClearPrevious">Clears previous displayed broadcast.</param>
		public new static void SendBroadcast(string message, ushort duration, BroadcastFlags type = BroadcastFlags.Normal, bool shouldClearPrevious = false)
		{
			if (shouldClearPrevious) ClearBroadcasts();

			Instance.GetComponent<Broadcast>().RpcAddElement(message, duration, type);
		}

		/// <summary>
		/// Clears displayed broadcast.
		/// </summary>
		public new static void ClearBroadcasts() => Instance.GetComponent<Broadcast>().RpcClearElements();
	}
}
