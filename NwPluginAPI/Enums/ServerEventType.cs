namespace PluginAPI.Enums
{
	using Core.Interfaces;
	using PlayerRoles;
	using PlayerRoles.PlayableScps.Scp173;
	using PlayerRoles.PlayableScps.Scp079;
	using PlayerRoles.PlayableScps.Scp939;
	using AdminToys;
	using PlayerStatsSystem;
	using Core.Items;
	using InventorySystem.Items;
	using InventorySystem.Items.Usables;
	using InventorySystem.Items.Firearms;
	using InventorySystem.Items.Pickups;
	using InventorySystem.Items.ThrowableProjectiles;
	using Respawning;
	using UnityEngine;
	using MapGeneration;
	using Interactables.Interobjects.DoorUtils;

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
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Locker"/> locker, <see cref="byte"/> colliderId, <see cref="bool"/> canAccess.
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
		/// Parameters: <see cref="IPlayer"/> player, <see cref="string"/> command, <see cref="string[]"/> arguments.
		/// </remarks>
		PlayerRemoteAdminCommand = 67,

		/// <summary>
		/// Event executed when using game console command.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="string"/> command, <see cref="string[]"/> arguments.
		/// </remarks>
		PlayerGameConsoleCommand = 68,

		/// <summary>
		/// Event executed when using console command.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="string"/> command, <see cref="string[]"/> arguments.
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

		/// <summary>
		/// Event executed when SCP-106 tries to start/stop stalk mode.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="bool"/> activate.
		/// </remarks>
		Scp106Stalking = 72,

		/// <summary>
		/// Event executed when player tries enter pocket dimension.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player.
		/// </remarks>
		PlayerEnterPocketDimension = 74,

		/// <summary>
		/// Event executed when player tries to escape from pocket dimension.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="bool"/> isSuccessful.
		/// </remarks>
		PlayerExitPocketDimension = 75,

		/// <summary>
		/// Event executed when player tries to throw projectile like grenades.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="ThrowableItem"/> item, <see cref="float"/> forceAmount, <see cref="float"/> upwardsFactor, <see cref="Vector3"/> torque, <see cref="Vector3"/> velocity.
		/// </remarks>
		PlayerThrowProjectile = 76,

		/// <summary>
		/// Event executed when player tries to activate SCP 914.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player.
		/// </remarks>
		Scp914Activate = 77,

		/// <summary>
		/// Event executed when player tries to change SCP 914 knob.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player.
		/// </remarks>
		Scp914KnobChange = 78,

		/// <summary>
		/// Event executed when SCP 914 upgrades player inventory.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="ItemBase"/> item.
		/// </remarks>
		Scp914UpgradeInventory = 79,

		/// <summary>
		/// Event executed when SCP 914 upgrades pickup.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="ItemPickupBase"/> item.
		/// </remarks>
		Scp914UpgradePickup = 80,

		/// <summary>
		/// Event executed when SCP-106 tries to teleport player.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target.
		/// </remarks>
		Scp106TeleportPlayer = 81,

		/// <summary>
		/// Event executed when SCP-173 tries to play sound.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="Scp173AudioPlayer.Scp173SoundId"/> soundId.
		/// </remarks>
		Scp173PlaySound = 82,

		/// <summary>
		/// Event executed when SCP-173 tries to create tantrum.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player.
		/// </remarks>
		Scp173CreateTantrum = 83,

		/// <summary>
		/// Event executed when SCP-173 tries to start/stop brackneck speeds.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player <see cref="bool"/> activate. 
		/// </remarks>
		Scp173BreakneckSpeeds = 84,

		/// <summary>
		/// Event executed when SCP-173 is seen by player.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player <see cref="IPlayer"/> target. 
		/// </remarks>
		Scp173NewObserver = 85,

		/// <summary>
		/// Event executed when SCP-173 tries to snap player neck.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player <see cref="IPlayer"/> target. 
		/// </remarks>
		Scp173SnapPlayer = 100,

		/// <summary>
		/// Event executed when SCP-939 tries to create amnestic cloud.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player. 
		/// </remarks>
		Scp939CreateAmnesticCloud = 86,

		/// <summary>
		/// Event executed when SCP-939 tries to lunge.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="Scp939LungeState"/> state. 
		/// </remarks>
		Scp939Lunge = 87,

		/// <summary>
		/// Event executed when SCP-939 tries to attack something.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="IDestructible"/> target. 
		/// </remarks>
		Scp939Attack = 88,

		/// <summary>
		/// Event executed when SCP-079 gains experience.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="int"/> amount, <see cref="Scp079HudTranslation"/> reason. 
		/// </remarks>
		Scp079GainExperience = 89,

		/// <summary>
		/// Event executed when SCP-079 level ups to new tier.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="int"/> tier. 
		/// </remarks>
		Scp079LevelUpTier = 90,

		/// <summary>
		/// Event executed when SCP-079 tries to use tesla.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="TeslaGate"/> tesla. 
		/// </remarks>
		Scp079UseTesla = 91,

		/// <summary>
		/// Event executed when SCP-079 lockdowns room.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="RoomIdentifier"/> room. 
		/// </remarks>
		Scp079LockdownRoom = 92,

		/// <summary>
		/// Event executed when SCP-079 cancels room lockdown.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="RoomIdentifier"/> room. 
		/// </remarks>
		Scp079CancelRoomLockdown = 101,

		/// <summary>
		/// Event executed when SCP-079 locks door.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="DoorVariant"/> door. 
		/// </remarks>
		Scp079LockDoor = 93,

		/// <summary>
		/// Event executed when SCP-079 unlocks door.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="DoorVariant"/> door. 
		/// </remarks>
		Scp079UnlockDoor = 94,

		/// <summary>
		/// Event executed when SCP-079 blackouts zone.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="FacilityZone"/> zone. 
		/// </remarks>
		Scp079BlackoutZone = 95,

		/// <summary>
		/// Event executed when SCP-079 blackouts room.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="RoomIdentifier"/> room. 
		/// </remarks>
		Scp079BlackoutRoom = 96,

		/// <summary>
		/// Event executed when SCP-049 resurrects body.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="Ragdoll"/> body. 
		/// </remarks>
		Scp049ResurrectBody = 97,

		/// <summary>
		/// Event executed when SCP-049 starts resurrecting body.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="Ragdoll"/> body, <see cref="bool"/> canResurrect. 
		/// </remarks>
		Scp049StartResurrectingBody = 98,

		/// <summary>
		/// Event executed when player tries to interact with door.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="DoorVariant"/> door, <see cref="bool"/> canOpen. 
		/// </remarks>
		PlayerInteractDoor = 99,
	}
}
