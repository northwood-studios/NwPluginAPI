namespace PluginAPI.Enums
{
	using Core.Interfaces;
	using PlayerRoles;
	using AdminToys;
	using PlayerStatsSystem;
	using Core.Items;
	using InventorySystem.Items.Usables;
	using InventorySystem.Items.Firearms;
	using InventorySystem.Items.Pickups;
	using Respawning;

	/// <summary>
	/// Represents server event types.
	/// </summary>
	public enum ServerEventType : int
	{
        /// <summary>
        /// Executed when player is verified.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerJoined = 0,

        /// <summary>
        /// Executed when player object is destroyed.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerLeft = 1,

        /// <summary>
        /// Executed when player dies.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> attacker, <see cref="DamageHandlerBase"/> damageHandler.
        /// </remarks>
        PlayerDeath = 2,

        /// <summary>
        /// Executed when decontamination in LCZ starts.
        /// </summary>
        LczDecontaminationStart = 3,

        /// <summary>
        /// Executed when information about decontamination is annoucement.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="int"/> announcement type.
        /// </remarks>
        LczDecontaminationAnnouncement = 4,

        /// <summary>
        /// Executed when map generates.
        /// </summary>
        MapGenerated = 5,

        /// <summary>
        /// Executed when grenade explodes.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="ItemPickupBase"/> pickup.
        /// </remarks>
        GrenadeExploded = 6,

        /// <summary>
        /// Executed when item is spawned while generation of map.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="ItemType"/> item.
        /// </remarks>
        ItemSpawned = 7,

        /// <summary>
        /// Executed when generator activates.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="Generator"/> generator.
        /// </remarks>
        GeneratorActivated = 8,

        /// <summary>
        /// Executed when blood is placed.
        /// </summary>
        PlaceBlood = 9,

        /// <summary>
        /// Executed when bullet hole is placed.
        /// </summary>
        PlaceBulletHole = 10,

        /// <summary>
        /// Executed when player activated generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerActivateGenerator = 11,

        /// <summary>
        /// Executed when player aims weapon
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> weapon, <see cref="bool"/> isAiming.
        /// </remarks>
        PlayerAimWeapon = 12,

        /// <summary>
        /// Executed when player gets banned.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> issuer, ref <see cref="string"/> reason, ref <see cref="long"/> duration.
        /// </remarks>
        PlayerBanned = 13,

        /// <summary>
        /// Executed when player cancels using item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="UsableItem"/> item.
        /// </remarks>
        PlayerCancelUsingItem = 14,

        /// <summary>
        /// Executed when player changes current item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ushort"/> oldItem, <see cref="ushort"/> newItem.
        /// </remarks>
        PlayerChangeItem = 15,

        /// <summary>
        /// Executed when player changes range in radio.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="byte"> range.
        /// </remarks>
        PlayerChangeRadioRange = 16,

        /// <summary>
        /// Executed when player changes spectating player.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> oldTarget, <see cref="IPlayer"/> newTarget.
        /// </remarks>
        PlayerChangeSpectator = 17,

        /// <summary>
        /// Executed when player closes generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerCloseGenerator = 18,

        /// <summary>
        /// Executed when player damages shooting target.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ShootingTarget"/> target, <see cref="DamageHandlerBase"/> damageHandler, <see cref="float"/> damageAmount.
        /// </remarks>
        PlayerDamagedShootingTarget = 19,

        /// <summary>
        /// Executed when player damages window.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="BreakableWindow"/> window, <see cref="DamageHandlerBase"/> damageHandler, <see cref="float"/> damageAmount.
        /// </remarks>
        PlayerDamagedWindow = 20,

        /// <summary>
        /// Executed when player deactivates generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerDeactivatedGenerator = 21,

        /// <summary>
        /// Executed when player drops ammo.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemType"/> type. <see cref="int"/> amount.
        /// </remarks>
        PlayerDropAmmo = 22,

        /// <summary>
        /// Executed when player drops item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerDropItem = 23,

        /// <summary>
        /// Executed when player dryfires weapon.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> weapon.
        /// </remarks>
        PlayerDryfireWeapon = 24,

        /// <summary>
        /// Executed when player escapes.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="RoleTypeId"/> newClass.
        /// </remarks>
        PlayerEscape = 25,

        /// <summary>
        /// Executed when player handcuffs other player.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target.
        /// </remarks>
        PlayerHandcuff = 26,

        /// <summary>
        /// Executed when player removes handcuffs from other player.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target.
        /// </remarks>
        PlayerRemoveHandcuffs = 27,

        /// <summary>
        /// Executed when player damages someone.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="DamageHandlerBase"/> damageHandler.
        /// </remarks>
        PlayerDamage = 28,

        /// <summary>
        /// Executed when player interacts with elevator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractElevator = 29,

        /// <summary>
        /// Executed when player interacts with locker.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractLocker = 30,

        /// <summary>
        /// Executed when player interacts with SCP330.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractScp330 = 31,

        /// <summary>
        /// Executed when player interacts with shooting target.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractShootingTarget = 32,

        /// <summary>
        /// Executed when player gets kicked from server.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerKicked = 33,

        /// <summary>
        /// Executed when player makes noise.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerMakeNoise = 34,

        /// <summary>
        /// Executed when player opens generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerOpenGenerator = 35,

        /// <summary>
        /// Executed when player pickups ammo.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerPickupAmmo = 36,

        /// <summary>
        /// Executed when player pickups armor.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerPickupArmor = 37,

        /// <summary>
        /// Executed when player pickups SCP330.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerPickupScp330 = 38,

        /// <summary>
        /// Executed when player preauths.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="string"/> userid, <see cref="string"/> ipAddress, <see cref="long"/> expiration, <see cref="CentralAuthPreauthFlags"/> flags, <see cref="string"/> country, <see cref="byte[]"/> signature.
        /// </remarks>
        PlayerPreauth = 39,

        /// <summary>
        /// Executed when player receives effect.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="PlayerEffect"/> effect.
        /// </remarks>
        PlayerReceiveEffect = 40,

        /// <summary>
        /// Executed when player reloads weapon.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Firearm"/> weapon.
        /// </remarks>
        PlayerReloadWeapon = 41,

        /// <summary>
        /// Executed when player changes role.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="PlayerRoleBase"/> oldRole, <see cref="RoleTypeId"/> newRole, <see cref="RoleChangeReason"/> reason.
        /// </remarks>
        PlayerChangeRole = 42,

        /// <summary>
        /// Executed when player searches pickup.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerSearchPickup = 43,

		/// <summary>
		/// Executed when player searched pickup.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
		/// </remarks>
		PlayerSearchedPickup = 44,

		/// <summary>
		/// Executed when player shots weapon.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="Firearm"/> item.
		/// </remarks>
		PlayerShotWeapon = 45,

        /// <summary>
        /// Executed when player spawns.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="RoleTypeId"/> role.
        /// </remarks>
        PlayerSpawn = 46,

        /// <summary>
        /// Executed when ragdoll spawns.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IRagdollRole"/> ragdoll, <see cref="DamageHandlerBase"/> damageHandler.
        /// </remarks>
        RagdollSpawn = 47,

        /// <summary>
        /// Executed when player throws item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerThrowItem = 48,

        /// <summary>
        /// Executed when player toggles flashlight.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item, <see cref="bool"/> isToggled.
        /// </remarks>
        PlayerToggleFlashlight = 49,

        /// <summary>
        /// Executed when player unloads weapon.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> weapon.
        /// </remarks>
        PlayerUnloadWeapon = 50,

        /// <summary>
        /// Executed when player unlocks generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerUnlockGenerator = 51,

        /// <summary>
        /// Executed when player used item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerUsedItem = 52,

        /// <summary>
        /// Executed when player uses hotkey.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ActionName"/> hotkey.
        /// </remarks>
        PlayerUseHotkey = 53,

        /// <summary>
        /// Executed when player starts using item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerUseItem = 54,

        /// <summary>
        /// Executed when player reports someone for breaking server rules.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="string"/> reason.
        /// </remarks>
        PlayerReport = 55,

        /// <summary>
        /// Executed when player reports someone for cheating.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="string"/> reason.
        /// </remarks>
        PlayerCheaterReport = 56,

        /// <summary>
        /// Executed when round ended.
        /// </summary>
        RoundEnd = 57,

        /// <summary>
        /// Executed when round restarts.
        /// </summary>
        RoundRestart = 58,

		/// <summary>
		/// Executed when round starts.
		/// </summary>
		RoundStart = 59,

		/// <summary>
		/// Executed when server waits for players.
		/// </summary>
		WaitingForPlayers = 60,

		/// <summary>
		/// Event executed when warhead is started.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="bool"/> isAutomatic, <see cref="IPlayer"/> player.
		/// </remarks>
		WarheadStart = 61,

		/// <summary>
		/// Event executed when warhead is stopped.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player.
		/// </remarks>
		WarheadStop = 62,

		/// <summary>
		/// Event executed when warhead detonates.
		/// </summary>
		WarheadDetonation = 63,

		/// <summary>
		/// Event executed when player is muted.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="bool"/> isIntercom.
		/// </remarks>
		PlayerMuted = 64,

		/// <summary>
		/// Event executed when player is unmuted.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="bool"/> isIntercom.
		/// </remarks>
		PlayerUnmuted = 65,

		/// <summary>
		/// Event executed when joining to server for reserved slot verification.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="string"/> userId, <see cref="bool"/> hasReservedSlot.
		/// </remarks>
		PlayerCheckReservedSlot = 66,

		/// <summary>
		/// Event executed when using remoteadmin command.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="string"/> command, <see cref="bool"/> arguments.
		/// </remarks>
		PlayerRemoteAdminCommand = 67,

		/// <summary>
		/// Event executed when using game console command.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="string"/> command, <see cref="bool"/> arguments.
		/// </remarks>
		PlayerGameConsoleCommand = 68,

		/// <summary>
		/// Event executed when using console command.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="string"/> command, <see cref="bool"/> arguments.
		/// </remarks>
		ConsoleCommand = 69,

		/// <summary>
		/// Event executed when selecting next team to spawn.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="SpawnableTeamType"/> team.
		/// </remarks>
		/// 
		TeamRespawnSelected = 70,

		/// <summary>
		/// Event executed when spawning next team.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="SpawnableTeamType"/> team.
		/// </remarks>
		TeamRespawn = 71,
	}
}
