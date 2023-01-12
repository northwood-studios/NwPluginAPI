using System;
using CustomPlayerEffects;
using UnityEngine;

namespace PluginAPI.Core
{
	using CommandSystem;
	using RemoteAdmin;
	using System.Collections.Generic;
	using Mirror;
	using Interfaces;
	using RoundRestarting;
	using static BanHandler;
	using static Broadcast;

	/// <summary>
	/// Represents the server.
	/// </summary>
	public class Server : Player
	{
		private static bool _isInitialized;

		/// <summary>
		/// Initializes server instance.
		/// </summary>
		public static void Init()
		{
			if (_isInitialized) return;

			_isInitialized = true;
			Instance = new Server(ReferenceHub.HostHub);
		}

		/// <summary>
		/// The <see cref="Server"/> instance.
		/// </summary>
		public static Server Instance { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Server"/> class.
		/// </summary>
		/// <param name="hub">The hub of server.</param>
		public Server(IGameComponent hub) : base(hub) { }

		/// <summary>
		/// Gets the Ip address of the server.
		/// </summary>
		public static string ServerIpAddress => ServerConsole.Ip;

		/// <summary>
		/// Gets the port of the server.
		/// </summary>
		public static ushort Port => ServerStatic.ServerPort;

		/// <summary>
		/// Gets or sets a value indicating whether or not server has enabled friendly fire.
		/// </summary>
		public static bool FriendlyFire
		{
			get => ServerConsole.FriendlyFire;
			set
			{
				if (FriendlyFire == value)
					return;

				ServerConsole.FriendlyFire = value;
				ServerConfigSynchronizer.Singleton.RefreshMainBools();
				ServerConfigSynchronizer.OnRefreshed?.Invoke();
			}
		}

		/// <summary>
		/// Get the amount of players connected to the server.
		/// </summary>
		public static int PlayerCount => Player.Count;

		/// <summary>
		/// Gets or sets the maximum amount of players online at the same time.
		/// </summary>
		public static int MaxPlayers
		{
			get => CustomNetworkManager.slots;
			set => CustomNetworkManager.slots = value;
		}

		/// <summary>
		/// Gets or sets the amount of reserved slots.
		/// </summary>
		public static int ReservedSlots
		{
			get => CustomNetworkManager.reservedSlots;
			set => CustomNetworkManager.reservedSlots = value;
		}

		public static Broadcast Broadcast => Broadcast.Singleton;

		/// <summary>
		/// Get server <see cref="PermissionsHandler"/>
		/// </summary>
		public static PermissionsHandler PermissionsHandler => ServerStatic.GetPermissionsHandler();

		/// <summary>
		/// Get actual ticks per second of the server.
		/// </summary>
		public static double TPS => Math.Round(1f / Time.smoothDeltaTime);

		/// <summary>
		/// Get or set server spawn protection duration.
		/// </summary>
		public static float SpawnProtectDuration
		{
			get => SpawnProtected.SpawnDuration;
			set => SpawnProtected.SpawnDuration = value;
		}

		/// <summary>
		/// Get or set if server is heavily modded.
		/// </summary>
		public static bool IsHeavilyModded
		{
			get => CustomNetworkManager.HeavilyModded;
			set => CustomNetworkManager.HeavilyModded = value;
		}

		#region Ban System

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="player">The target player which will be banned.</param>
		/// <param name="reason">The reason of the ban.</param>
		/// <param name="duration">The duration of the ban in seconds.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayer(Player player, string reason, long duration) => global::BanPlayer.BanUser(player.ReferenceHub, reason, duration);

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="player">The player which will be banned.</param>
		/// <param name="issuer">The player who issued the ban.</param>
		/// <param name="reason">The reason of ban.</param>
		/// <param name="duration">The duration of the ban in seconds.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayer(Player player, IPlayer issuer, string reason, long duration) => global::BanPlayer.BanUser(player.ReferenceHub, issuer.ReferenceHub, reason, duration);

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="player">The player which will be banned.</param>
		/// <param name="issuer">The player who issued the ban.</param>
		/// <param name="reason">The reason of ban.</param>
		/// <param name="duration">The duration of the ban in seconds.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayer(Player player, ICommandSender issuer, string reason, long duration) => global::BanPlayer.BanUser(player.ReferenceHub, issuer, reason, duration);

		/// <summary>
		/// Kicks a player from the server.
		/// </summary>
		/// <param name="player">The player which will be kicked.</param>
		/// <param name="issuer">The player who issued kick.</param>
		/// <param name="reason">The reason of the kick.</param>
		public static void KickPlayer(Player player, IPlayer issuer, string reason) => global::BanPlayer.KickUser(player.ReferenceHub, issuer.ReferenceHub, reason);

		/// <summary>
		/// Kicks a player from the server.
		/// </summary>
		/// <param name="player">The player which will be kicked.</param>
		/// <param name="issuer">The player who issued kick.</param>
		/// <param name="reason">The reason of the kick.</param>
		public static void KickPlayer(Player player, ICommandSender issuer, string reason) => global::BanPlayer.KickUser(player.ReferenceHub, issuer, reason);

		/// <summary>
		/// Kicks a player from the server.
		/// </summary>
		/// <param name="player">The player which will be kicked.</param>
		/// <param name="reason">The reason of the kick.</param>
		public static void KickPlayer(Player player, string reason) => global::BanPlayer.KickUser(player.ReferenceHub, reason);

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="userId">The userid of player which will be banned.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of the ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of the banned player.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayerByUserId(string userId, string reason, long duration, string bannedPlayerNickname = "UnknownName") => BanPlayerByUserId(userId, ServerConsole.Scs, reason, duration, bannedPlayerNickname);

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="userId">The userid of the player which will be banned.</param>
		/// <param name="issuer">The issuer of the ban.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of the ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of the banned player.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayerByUserId(string userId, IPlayer issuer, string reason, long duration, string bannedPlayerNickname = "UnknownName") => BanPlayerByUserId(userId, new PlayerCommandSender(issuer.ReferenceHub), reason, duration, bannedPlayerNickname);

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="userId">The userid of the player which will be banned.</param>
		/// <param name="issuer">The issuer of the ban.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of the ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of the banned player.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayerByUserId(string userId, ICommandSender issuer, string reason, long duration, string bannedPlayerNickname = "UnknownName")
		{
			if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(reason)) return false;

			return IssueBan(new BanDetails()
			{
				Id = userId,
				IssuanceTime = TimeBehaviour.CurrentTimestamp(),
				Expires = TimeBehaviour.GetBanExpirationTime((uint)duration),
				Issuer = issuer.LogName,
				OriginalName = bannedPlayerNickname,
				Reason = reason,
			}, BanType.UserId);
		}

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="ipAddress">The ip address of the player which will be banned.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of the ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of the the banned player.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayerByIpAddress(string ipAddress, string reason, long duration, string bannedPlayerNickname = "UnknownName") => BanPlayerByIpAddress(ipAddress, ServerConsole.Scs, reason, duration, bannedPlayerNickname);

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="ipAddress">The ip address of the player which will be banned.</param>
		/// <param name="issuer">The issuer of the ban.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of the ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of the banned player.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayerByIpAddress(string ipAddress, IPlayer issuer, string reason, long duration, string bannedPlayerNickname = "UnknownName") => BanPlayerByIpAddress(ipAddress, new PlayerCommandSender(issuer.ReferenceHub), reason, duration, bannedPlayerNickname);

		/// <summary>
		/// Bans a player from the server.
		/// </summary>
		/// <param name="ipAddress">The ip address of the player which will be banned.</param>
		/// <param name="issuer">The issuer of the ban.</param>
		/// <param name="reason">The ban reason.</param>
		/// <param name="duration">The duration of the ban.</param>
		/// <param name="bannedPlayerNickname">The nickname of the banned player.</param>
		/// <returns>Whether or not the ban was successful.</returns>
		public static bool BanPlayerByIpAddress(string ipAddress, ICommandSender issuer, string reason, long duration, string bannedPlayerNickname = "UnknownName")
		{
			if (string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(reason)) return false;

			return IssueBan(new BanDetails()
			{
				Id = ipAddress,
				IssuanceTime = TimeBehaviour.CurrentTimestamp(),
				Expires = TimeBehaviour.GetBanExpirationTime((uint)duration),
				Issuer = issuer.LogName,
				OriginalName = bannedPlayerNickname,
				Reason = reason,
			}, BanType.IP);
		}

		/// <summary>
		/// Unbans a player from the server.
		/// </summary>
		/// <param name="userId">The userid of the player to unban.</param>
		/// <returns>Whether or not the unban was successful.</returns>
		public static bool UnbanPlayerByUserId(string userId)
		{
			if (string.IsNullOrEmpty(userId)) return false;

			if (!IsPlayerBanned(userId)) return false;

			RemoveBan(userId, BanType.UserId);
			return true;
		}

		/// <summary>
		/// Unbans a player from the server.
		/// </summary>
		/// <param name="ipAddress">The ip address of the player.</param>
		/// <returns>Whether or not the unban was successful.</returns>
		public static bool UnbanPlayerByIpAddress(string ipAddress)
		{
			if (string.IsNullOrEmpty(ipAddress)) return false;

			if (!IsPlayerBanned(ipAddress)) return false;

			RemoveBan(ipAddress, BanType.IP);
			return true;
		}

		/// <summary>
		/// Checks whether or not a player is banned.
		/// </summary>
		/// <param name="value">The userid or ip of the player.</param>
		/// <returns>Whether or not the player is banned.</returns>
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

		/// <summary>
		/// Indicates whether the server is in the Idle Mode.
		/// </summary>
		public static bool IdleModeActive => IdleMode.IdleModeActive;

		/// <summary>
		/// Gets or sets whether the server temporarily can't enter the Idle Mode.
		/// </summary>
		public static bool PauseIdleMode
		{
			get => IdleMode.PauseIdleMode;

			set => IdleMode.PauseIdleMode = value;
		}

		/// <summary>
		/// Gets or sets whether the idle mode is available on the server.
		/// </summary>
		public static bool IdleModeAvailable
		{
			get => IdleMode.IdleModeEnabled;

			set => IdleMode.IdleModeEnabled = value;
		}

		/// <summary>
		/// Enters or leaves the idle mode.
		/// </summary>
		/// <param name="state">Value indicating whether the server should enter the idle mode.</param>
		public static void SetIdleMode(bool state) => IdleMode.SetIdleMode(state);
	}
}