namespace PluginAPI.Core
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Hints;
	using InventorySystem;
	using InventorySystem.Items;
	using Mirror;
	using PlayerRoles;
	using PlayerRoles.FirstPersonControl;
	using PlayerStatsSystem;
	using Factories;
	using Interfaces;
	using RoundRestarting;
	using UnityEngine;
	using VoiceChat;
	using VoiceChat.Playbacks;
	using static Broadcast;

	/// <summary>
	/// Player connected to server.
	/// </summary>
	public class Player : IPlayer
    {
        #region Static Internal Variables
        internal static Dictionary<int, IGameComponent> PlayersIds = new Dictionary<int, IGameComponent>();
        internal static Dictionary<string, IGameComponent> PlayersUserIds = new Dictionary<string, IGameComponent>();
        #endregion

        #region Static Parameters
        /// <summary>
        /// Amount of online players.
        /// </summary>
        public static int Count => ReferenceHub.AllHubs.Count;
        #endregion

        #region Static Methods

        /// <summary>
        /// Gets all players.
        /// </summary>
        public static List<T> GetPlayers<T>() where T : IPlayer
		{
            if (!FactoryManager.FactoryTypes.TryGetValue(typeof(T), out Type plugin))
            {
                return (List<T>)Enumerable.Empty<T>();
            }

            if (!FactoryManager.PlayerFactories.TryGetValue(plugin, out PlayerFactory factory))
            {
                return (List<T>)Enumerable.Empty<T>();
            }

			foreach (var hub in ReferenceHub.AllHubs)
			{
				if (hub.isServer) continue;
				factory.GetOrAdd(hub);
			}

			return factory.Get()
				.Cast<T>()
				.ToList();
        }

        /// <summary>
        /// Gets the <see cref="Player"/> from <see cref="IGameComponent"/>.
        /// </summary>
        public static bool TryGet<T>(IGameComponent component, out T player) where T : IPlayer
        {
            if (!FactoryManager.FactoryTypes.TryGetValue(typeof(T), out Type plugin))
            {
                player = default(T);
                return false;
            }

            if (!FactoryManager.PlayerFactories.TryGetValue(plugin, out PlayerFactory factory))
            {
                player = default(T);
                return false;
            }

            player = (T)factory.GetOrAdd(component);
            return true;
        }

        #region Get player from gameobject.

        /// <summary>
        /// Gets the <see cref="Player"/> from <see cref="GameObject"/>.
        /// </summary>
        public static T Get<T>(GameObject gameObject) where T : IPlayer
        {
			TryGet(gameObject, out T player);
            return player;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> from <see cref="GameObject"/>.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if player found or <see langword="false"/> if not found.</returns>
        public static bool TryGet<T>(GameObject gameObject, out T player) where T : IPlayer
        {
			if (gameObject == null)
			{
				player = default(T);
				return false;
			}

            if (!ReferenceHub.TryGetHub(gameObject, out ReferenceHub hub))
			{
				player = default(T);
				return false;
			}

			if (!TryGet(hub, out T plr))
			{
                player = default(T);
                return false;
            }

			player = plr;
			return true;
        }
        #endregion

        #region Get player from reference hub.
        /// <summary>
        /// Gets the <see cref="Player"/> from <see cref="ReferenceHub"/>.
        /// </summary>
        public static T Get<T>(ReferenceHub hub) where T : IPlayer
        {
			TryGet(hub, out T player);
            return player;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> from <see cref="ReferenceHub"/>.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if player found or <see langword="false"/> if not found.</returns>
        public static bool TryGet<T>(ReferenceHub hub, out T player) where T : IPlayer
        {
            if (hub == null)
            {
                player = default(T);
                return false;
			}

            if (!TryGet((IGameComponent)hub, out T plr))
			{
				player = default(T);
				return false;
			}
          
			player = plr;
            return true;
        }
        #endregion

        #region Get player from network identity.
        /// <summary>
        /// Gets the <see cref="Player"/> from <see cref="NetworkIdentity"/>.
        /// </summary>
        public static T Get<T>(NetworkIdentity netIdentity) where T : IPlayer
		{
			TryGet(netIdentity, out T player);
			return player;
		}

        /// <summary>
        /// Gets the <see cref="Player"/> from <see cref="NetworkIdentity"/>.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if player found or <see langword="false"/> if not found.</returns>
        public static bool TryGet<T>(NetworkIdentity netIdentity, out T player) where T : IPlayer
        {
            if (netIdentity == null)
            {
                player = default(T);
                return false;
            }

            if (!TryGet(netIdentity.netId, out player))
			{
				player = default(T);
				return false;
			}

            return true;
        }
        #endregion

        #region Get player from name.

        /// <summary>
        /// Gets the <see cref="Player"/> by name.
        /// </summary>
        public static T GetByName<T>(string name) where T : IPlayer
        {
			TryGetByName(name, out T player);
			return player;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> by name.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if player found or <see langword="false"/> if not found.</returns>
        public static bool TryGetByName<T>(string name, out T player) where T : IPlayer
        {
            if (string.IsNullOrEmpty(name))
            {
                player = default(T);
                return false;
			}

            var hub = ReferenceHub.AllHubs.Where(p =>
                p.nicknameSync.MyNick == name ||
                p.nicknameSync.MyNick.ToLower().Replace(" ", "") == name.ToLower().Replace(" ", ""))
                .FirstOrDefault();

			if (hub == null)
			{
				player = default(T);
				return false;
			}

			if (!TryGet(hub, out T plr))
			{
				player = default(T);
				return false;
			}

			player = plr;
            return true;
        }
        #endregion

        #region Get player from player id.

        /// <summary>
        /// Gets the <see cref="Player"/> by player id.
        /// </summary>
        public static T Get<T>(int playerId) where T : IPlayer
        {
			TryGet(playerId, out T player);
            return player;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> by player id.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if player found or <see langword="false"/> if not found.</returns>
        public static bool TryGet<T>(int playerId, out T player) where T : IPlayer
        {
            if (!PlayersIds.TryGetValue(playerId, out IGameComponent component))
            {
				player = default(T);
                return false;
            }

            if (!TryGet(component, out T plr))
			{
				player = default(T);
				return false;
			}

			player = plr;
            return true;
        }
        #endregion

        #region Get player from userid.

        /// <summary>
        /// Gets the <see cref="Player"/> by user id.
        /// </summary>
        public static T Get<T>(string userId) where T : IPlayer
        {
			TryGet(userId, out T player);
            return player;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> by user id.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if player found or <see langword="false"/> if not found.</returns>
        public static bool TryGet<T>(string userId, out T player) where T : IPlayer
        {
            if (string.IsNullOrEmpty(userId))
            {
                player = default(T);
                return false;
            }

            if (!PlayersUserIds.TryGetValue(userId, out IGameComponent component))
            {
                player = default(T);
                return false;
            }

			if (!TryGet(component, out T plr))
			{
				player = default(T);
                return false;
			}

			player = plr;
			return true;
        }
        #endregion

        #region Get player from network id.

        /// <summary>
        /// Gets the <see cref="Player"/> by network id.
        /// </summary>
        public static T Get<T>(uint networkId) where T : IPlayer
        {
			TryGet(networkId, out T player);
            return player;
        }

        /// <summary>
        /// Gets the <see cref="Player"/> by network id.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if player found or <see langword="false"/> if not found.</returns>
        public static bool TryGet<T>(uint networkId, out T player) where T : IPlayer
        {
            if (!ReferenceHub.TryGetHubNetID(networkId, out ReferenceHub hub))
			{
				player = default(T);
				return false;
            }

			if (!TryGet(hub, out T plr))
			{
                player = default(T);
                return false;
			}

            player = plr;
            return true;
        }
        #endregion
        #endregion

        #region Public Parameters
        /// <summary>
        /// Gets the player's <see cref="global::ReferenceHub"/>.
        /// </summary>
        public ReferenceHub ReferenceHub { get; }

		/// <summary>
		/// Gets the player's <see cref="UnityEngine.GameObject"/>.
		/// </summary>
		public GameObject GameObject => ReferenceHub.gameObject;

		/// <summary>
		/// Gets the network id.
		/// </summary>
		public uint NetworkId => ReferenceHub.characterClassManager.netId;

		/// <summary>
		/// Gets the player unique id per round.
		/// </summary>
		public int PlayerId => ReferenceHub.PlayerId;

		/// <summary>
		/// Gets the player name.
		/// </summary>
		public string Nickname => string.IsNullOrEmpty(ReferenceHub.nicknameSync.MyNick) ? "(unknown nickname)" : ReferenceHub.nicknameSync.MyNick;

		/// <summary>
		/// Gets or sets player display name.
		/// </summary>
		public string DisplayNickname
		{
			get => ReferenceHub.nicknameSync.DisplayName;
			set => ReferenceHub.nicknameSync.DisplayName = value;
		}

		/// <summary>
		/// Gets the player user id.
		/// </summary>
		public string UserId => IsServer ? "server@server" : ReferenceHub.characterClassManager.UserId;

		/// <summary>
		/// Gets the player ip address.
		/// </summary>
		public string IpAddress => ReferenceHub.characterClassManager.connectionToClient.address;

		/// <summary>
		/// Gets or sets player current role.
		/// </summary>
		public RoleTypeId Role
		{
			get => ReferenceHub.GetRoleId();
			set => ReferenceHub.roleManager.ServerSetRole(value, RoleChangeReason.RemoteAdmin);
		}

		/// <summary>
		/// Gets or sets player custom info.
		/// </summary>
		public string CustomInfo
		{
			get => ReferenceHub.nicknameSync.CustomPlayerInfo;
			set => ReferenceHub.nicknameSync.CustomPlayerInfo = value;
		}

		/// <summary>
		/// Gets or sets player current unit.
		/// </summary>
		public string CurrentUnit
		{
			get => ReferenceHub.characterClassManager.CurUnitName;
			set => ReferenceHub.characterClassManager.CurUnitName = value;
		}

		/// <summary>
		/// Gets or sets player current health;
		/// </summary>
		public float Health
		{
			get => ((HealthStat)ReferenceHub.playerStats.StatModules[0]).CurValue;
			set => ((HealthStat)ReferenceHub.playerStats.StatModules[0]).CurValue = value;
		}

		/// <summary>
		/// Gets player current maximum health;
		/// </summary>
		public float MaxHealth => ((HealthStat)ReferenceHub.playerStats.StatModules[0]).MaxValue;

		/// <summary>
		/// Gets or sets player current artificial health;
		/// </summary>
		public float ArtificialHealth
		{
			get => ((AhpStat)ReferenceHub.playerStats.StatModules[0]).CurValue;
			set => ((AhpStat)ReferenceHub.playerStats.StatModules[0]).CurValue = value;
		}

		/// <summary>
		/// Gets player current maximum artifical health.
		/// </summary>
		public float MaxArtificalHealth => ((AhpStat)ReferenceHub.playerStats.StatModules[1]).MaxValue;

		/// <summary>
		/// Gets if player has remoteadmin access. 
		/// </summary>
		public bool RemoteAdminAccess => ReferenceHub.serverRoles.RemoteAdmin;

		/// <summary>
		/// Gets if player has DoNotTrack enabled.
		/// </summary>
		public bool DoNotTrack => ReferenceHub.serverRoles.DoNotTrack;

		/// <summary>
		/// Gets or sets if player is using overwatch.
		/// </summary>
		public bool IsOverwatchEnabled
		{
			get => ReferenceHub.serverRoles.OverwatchEnabled;
			set => ReferenceHub.serverRoles.OverwatchEnabled = value;
		}

		/// <summary>
		/// Player info displayed while looking at player.
		/// </summary>
		public PlayerInfo PlayerInfo { get; }

		/// <summary>
		/// Gets or sets the item in the player's hand, returns the default value if empty.
		/// </summary>
		public ItemBase CurrentItem
		{
			get => ReferenceHub.inventory.CurInstance;
			set
			{
				if (value == null || value.ItemTypeId == ItemType.None)
					ReferenceHub.inventory.ServerSelectItem(0);
				else
					ReferenceHub.inventory.ServerSelectItem(value.ItemSerial);
			}
		}

		/// <summary>
		/// Gets if player is muted.
		/// </summary>
		public bool IsMuted => VoiceChatMutes.QueryLocalMute(UserId);

		/// <summary>
		/// Gets if player is muted at intercom.
		/// </summary>
		public bool IsIntercomMuted => VoiceChatMutes.QueryLocalMute(UserId, true);

		/// <summary>
		/// Gets if player is using voicechat.
		/// </summary>
		public bool IsUsingVoiceChat => PersonalRadioPlayback.IsTransmitting(ReferenceHub);

		/// <summary>
		/// Gets if player is global moderator.
		/// </summary>
		public bool IsGlobalModerator => ReferenceHub.serverRoles.RaEverywhere;

		/// <summary>
		/// Gets if player is northwood staff.
		/// </summary>
		public bool IsNorthwoodStaff => ReferenceHub.serverRoles.Staff;

		/// <summary>
		/// Gets if player has bypass mode.
		/// </summary>
		public bool IsBypassEnabled
		{
			get => ReferenceHub.serverRoles.BypassMode;
			set => ReferenceHub.serverRoles.BypassMode = value;
		}

		/// <summary>
		/// Gets if player has god mode.
		/// </summary>
		public bool IsGodModeEnabled
		{
			get => ReferenceHub.characterClassManager.GodMode;
			set => ReferenceHub.characterClassManager.GodMode = value;
		}

		/// <summary>
		/// Gets if player has noclip.
		/// </summary>
		public bool IsNoclipEnabled
		{
			get => ReferenceHub.playerStats.GetModule<AdminFlagsStat>().HasFlag(AdminFlags.Noclip);
			set => ReferenceHub.playerStats.GetModule<AdminFlagsStat>().SetFlag(AdminFlags.Noclip, value);
		}

		/// <summary>
		/// Gets if player is human.
		/// </summary>
		public bool IsHuman => ReferenceHub.IsHuman();

		/// <summary>
		/// Gets if player is alive
		/// </summary>
		public bool IsAlive => ReferenceHub.IsAlive();

		/// <summary>
		/// Gets if player is properly connected to server.
		/// </summary>
		public bool IsReady => ReferenceHub.characterClassManager.InstanceMode != ClientInstanceMode.Unverified && ReferenceHub.nicknameSync.NickSet;

		/// <summary>
		/// Gets if player is dedicated server.
		/// </summary>
		public bool IsServer => ReferenceHub.isLocalPlayer;

		/// <summary>
		/// Gets player network connection.
		/// </summary>
		public NetworkConnection Connection => IsServer ? ReferenceHub.networkIdentity.connectionToServer : ReferenceHub.networkIdentity.connectionToClient;

		/// <summary>
		/// Gets player camera transform.
		/// </summary>
		public Transform Camera => ReferenceHub.PlayerCameraReference;

		/// <summary>
		/// Storage for temporary date for current session.
		/// </summary>
		public DataStorage TemporaryData { get; } = new DataStorage();

		/// <summary>
		/// The manager for player effects.
		/// </summary>
		public EffectsManager EffectsManager { get; }

		/// <summary>
		/// The manager for player damage.
		/// </summary>
		public DamageManager DamageManager { get; }

		/// <summary>
		/// Gets or sets player position.
		/// </summary>
		public Vector3 Position
		{
			get => GameObject.transform.position;
			set => ReferenceHub.TryOverridePosition(value, Vector3.zero);
		}

		/// <summary>
		/// Gets or sets player rotation.
		/// </summary>
		public Vector3 Rotation
		{
			get => GameObject.transform.eulerAngles;
			set => ReferenceHub.TryOverridePosition(Position, value);
		}
		#endregion

		#region Private Variables
		internal PlayerSharedStorage SharedStorage { get; }
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor for player.
		/// </summary>
		/// <param name="component">The game component.</param>
		public Player(IGameComponent component)
		{
			ReferenceHub = (ReferenceHub)component;

			PlayerInfo = new PlayerInfo(this);
			SharedStorage = PlayerSharedStorage.GetStorage(this);

			EffectsManager = new EffectsManager(this);
			DamageManager = new DamageManager(this);

			if (!PlayersIds.ContainsKey(PlayerId))
				PlayersIds.Add(PlayerId, ReferenceHub);

			try
			{
                OnStart();
            }
            catch (Exception ex)
			{
				Log.Error($"Failed executing OnStart in {GetType().Name}, error\n {ex}");
			}
		}
		#endregion

		#region Internal Methods
		internal void OnInternalDestroy()
		{
			PlayerSharedStorage.DestroyStorage(this);
			PlayersIds.Remove(PlayerId);
			if (UserId != null)
				PlayersUserIds.Remove(UserId);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Shows a broadcast to the player.
		/// </summary>
		/// <param name="message">The message to be broadcasted.</param>
		/// <param name="duration">The broadcast duration.</param>
		/// <param name="type">The broadcast type.</param>
		/// <param name="shouldClearPrevious">Clears previous displayed broadcast.</param>
		public void SendBroadcast(string message, ushort duration, BroadcastFlags type = BroadcastFlags.Normal, bool shouldClearPrevious = false)
		{
			if (shouldClearPrevious) ClearBroadcasts();

			Server.Instance.GetComponent<Broadcast>().TargetAddElement(ReferenceHub.characterClassManager.connectionToClient, message, duration, type);
		}

		/// <summary>
		/// Clears displayed broadcast.
		/// </summary>
		public void ClearBroadcasts() => Server.Instance.GetComponent<Broadcast>().TargetClearElements(ReferenceHub.characterClassManager.connectionToClient);

		/// <summary>
		/// Sends a console message to the player's console.
		/// </summary>
		/// <param name="message">The message to be sent.</param>
		/// <param name="color">The message color.</param>
		public void SendConsoleMessage(string message, string color = "green") => ReferenceHub.gameConsoleTransmission.SendToClient(ReferenceHub.characterClassManager.connectionToClient, message, color);

		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="issuer">The player which issued ban.</param>
		/// <param name="reason">The reason of ban.</param>
		/// <param name="duration">The duration of ban in seconds.</param>
		/// <returns>If ban is successful.</returns>
		public bool Ban(IPlayer issuer, string reason, long duration) => Server.BanPlayer(this, issuer, reason, duration);

		/// <summary>
		/// Bans player from server.
		/// </summary>
		/// <param name="reason">The reason of ban.</param>
		/// <param name="duration">The duration of ban in seconds.</param>
		/// <returns>If ban is successful.</returns>
		public bool Ban(string reason, long duration) => Server.BanPlayer(this, Server.Instance, reason, duration);

		/// <summary>
		/// Kicks player from server.
		/// </summary>
		/// <param name="issuer">The player which issued kick.</param>
		/// <param name="reason">The reason of kick.</param>
		public void Kick(IPlayer issuer, string reason) => Server.KickPlayer(this, issuer, reason);

		/// <summary>
		/// Kicks player from server.
		/// </summary>
		/// <param name="reason">The reason of kick.</param>
		public void Kick(string reason) => Server.KickPlayer(this, Server.Instance, reason);

		/// <summary>
		/// Issue a mute to a player, disallowing them from using voicechat.
		/// </summary>
		public void Mute(bool isTemporary = true)
		{
			if (isTemporary)
				VoiceChatMutes.SetFlags(ReferenceHub, VcMuteFlags.GlobalRegular);
			else
				VoiceChatMutes.IssueLocalMute(UserId);
		}

		/// <summary>
		/// Revoke a player's mute, allowing them to use voicechat again.
		/// </summary>
		/// <param name="revokeMute">If set to true, this player's <see cref="UserId"/> will be removed from the mute file.</param>
		public void Unmute(bool revokeMute)
		{
			if (revokeMute)
				VoiceChatMutes.RevokeLocalMute(UserId);
			else
				VoiceChatMutes.SetFlags(ReferenceHub, VcMuteFlags.None);
		}

		/// <summary>
		/// Issue a mute to a player, disallowing them from using intercom.
		/// </summary>
		public void IntercomMute(bool isTemporary = false)
		{
			if (isTemporary)
				VoiceChatMutes.SetFlags(ReferenceHub, VcMuteFlags.GlobalIntercom);
			else
				VoiceChatMutes.IssueLocalMute(UserId, true);
		}

		/// <summary>
		/// Revoke a player's mute, allowing them to use intercom again.
		/// </summary>
		/// <param name="revokeMute">If set to true, this player's <see cref="UserId"/> will be removed from the mute file.</param>
		public void IntercomUnmute(bool revokeMute)
		{
			if (revokeMute)
				VoiceChatMutes.RevokeLocalMute(UserId, true);
			else
				VoiceChatMutes.SetFlags(ReferenceHub, VcMuteFlags.None);
		}

		/// <summary>
		/// Adds ammo of specific item type.
		/// </summary>
		/// <param name="item">The type of ammo.</param>
		/// <param name="amount">The amount of ammo.</param>
		public void AddAmmo(ItemType item, ushort amount) => ReferenceHub.inventory.ServerAddAmmo(item, amount);

		/// <summary>
		/// Sets ammo amount of specific item type.
		/// </summary>
		/// <param name="item">The type of ammo</param>
		/// <param name="amount">The amount of ammo.</param>
		public void SetAmmo(ItemType item, ushort amount) => ReferenceHub.inventory.ServerSetAmmo(item, amount);

		/// <summary>
		/// Gets ammo amount of specific item type.
		/// </summary>
		/// <param name="item">The type of ammo.</param>
		/// <returns>Amount of ammo which player has.</returns>
		public ushort GetAmmo(ItemType item) => ReferenceHub.inventory.GetCurAmmo(item);

		/// <summary>
		/// Drops ammo.
		/// </summary>
		/// <param name="item">The type of ammo.</param>
		/// <param name="amount">The amount of ammo which will be dropped.</param>
		/// <param name="checkMinimals">Will prevent dropping small amounts of ammo.</param>
		/// <returns>If player dropped ammo successfully.</returns>
		public bool DropAmmo(ItemType item, ushort amount, bool checkMinimals = false) => ReferenceHub.inventory.ServerDropAmmo(item, amount, checkMinimals);

		/// <summary>
		/// Drops all items including ammo.
		/// </summary>
		public void DropEverything() => ReferenceHub.inventory.ServerDropEverything();

		/// <summary>
		/// Heals the player.
		/// </summary>
		/// <param name="amount">The amount of health to heal.</param>
		public void Heal(float amount) => ((HealthStat)ReferenceHub.playerStats.StatModules[0]).ServerHeal(amount);

		/// <summary>
		/// Sets player role.
		/// </summary>
		/// <param name="newRole">The <see cref="RoleTypeId"/> which will be set.</param>
		/// <param name="reason">The <see cref="RoleChangeReason"/> of role change.</param>
		public void SetRole(RoleTypeId newRole, RoleChangeReason reason = RoleChangeReason.RemoteAdmin) => ReferenceHub.roleManager.ServerSetRole(newRole, reason);

		/// <summary>
		/// Disconnects player from server.
		/// </summary>
		/// <param name="reason">The reason.</param>
		public void Disconnect(string reason = null) => ServerConsole.Disconnect(GameObject, reason ?? string.Empty);

		/// <summary>
		/// Player receives hint text.
		/// </summary>
		/// <param name="text">The text which will be displayed.</param>
		/// <param name="duration">The duration of text visibility.</param>
		public void ReceiveHint(string text, float duration = 3f) => ReferenceHub.hints.Show(new TextHint(text, new HintParameter[] { new StringHintParameter(text) }, null, duration));

		/// <summary>
		/// Player receives hint text with effects.
		/// </summary>
		/// <param name="text">The text which will be displayed.</param>
		/// <param name="effects">The effects of text.</param>
		/// <param name="duration">The duration of text visibility.</param>
		public void ReceiveHint(string text, HintEffect[] effects, float duration = 3f) => ReferenceHub.hints.Show(new TextHint(text, new HintParameter[] { new StringHintParameter(text) }, effects, duration));

		/// <summary>
		/// Player receives hit marker.
		/// </summary>
		/// <param name="size">The size of hit marker.</param>
		public void ReceiveHitMarker(float size = 1f) => Hitmarker.SendHitmarker(Connection, size);

		/// <summary>
		/// Gets stats module.
		/// </summary>
		/// <typeparam name="T">The type of module.</typeparam>
		/// <returns>The stat module.</returns>
		public T GetStatModule<T>() where T : StatBase => ReferenceHub.playerStats.GetModule<T>();

		/// <summary>
		/// Redirects player connection to target server port.
		/// </summary>
		/// <param name="port">The port of target server.</param>
		public void RedirectToServer(ushort port) => Connection.Send(new RoundRestartMessage(RoundRestartType.RedirectRestart, 0.1f, port, true, false));

		/// <summary>
		/// Tells player to reconnect to server.
		/// </summary>
		/// <param name="delay">The delay when client will reconnect to server.</param>
		/// <param name="isFastRestart">If fast restart is enabled.</param>
		public void Reconnect(float delay = 3f, bool isFastRestart = false) => Connection.Send(new RoundRestartMessage(isFastRestart ? RoundRestartType.FastRestart : RoundRestartType.FullRestart, delay, 0, true, false));

        /// <inheritdoc/>
        public virtual void OnStart() { }

        /// <inheritdoc/>
        public virtual void OnDestroy() { }

        /// <inheritdoc/>
        public virtual void OnUpdate() { }

        /// <inheritdoc/>
        public virtual void OnLateUpdate() { }

        /// <inheritdoc/>
        public virtual void OnFixedUpdate() { }

		#region GetComponents
		/// <inheritdoc/>
		public T GetComponent<T>(bool globalSearch = false) where T : MonoBehaviour
		{
			TryGetComponent(out T comp, globalSearch);
			return comp;
		}

		/// <inheritdoc/>
		public bool TryGetComponent<T>(out T component, bool globalSearch = false) where T : MonoBehaviour
		{
			if (!SharedStorage.StoredComponents.ContainsKey(typeof(T)))
			{
				if (globalSearch)
				{
					component = UnityEngine.Object.FindObjectOfType<T>();
					if (component == null)
						return false;
					SharedStorage.StoredComponents.Add(typeof(T), component);
				}
				else
				{
					if (GameObject.TryGetComponent(out component))
						SharedStorage.StoredComponents.Add(typeof(T), component);
					else
						return false;
				}
			}

			component = (T)SharedStorage.StoredComponents[typeof(T)];
			return true;
		}
		#endregion
		#endregion
	}
}
