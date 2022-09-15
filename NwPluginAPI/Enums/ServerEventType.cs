namespace PluginAPI.Enums
{
	using PluginAPI.Core.Interfaces;
	using PlayerRoles;
	using AdminToys;
	using PlayerStatsSystem;
	using CustomPlayerEffects;
	using PluginAPI.Core.Items;
	using InventorySystem.Items.Usables;
	using InventorySystem.Items.Firearms;
	using InventorySystem.Items.Pickups;

	public enum ServerEventType
	{
        /// <summary>
        /// Event executed when player is verified.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerJoined,

        /// <summary>
        /// Event executed when player object is destroyed.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerLeft,

        /// <summary>
        /// Event executed when player dies.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> attacker, <see cref="DamageHandlerBase"/> damageHandler.
        /// </remarks>
        PlayerDeath,

        /// <summary>
        /// Event executed when decontamination in LCZ starts.
        /// </summary>
        LczDecontaminationStart,

        /// <summary>
        /// Event executed when information about decontamination is annoucement.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="int"/> announcement type.
        /// </remarks>
        LczDecontaminationAnnouncement,

        /// <summary>
        /// Event executed when map generates.
        /// </summary>
        MapGenerated,

        /// <summary>
        /// Event executed when grenade explodes.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="ItemPickupBase"/> pickup.
        /// </remarks>
        GrenadeExploded,

        /// <summary>
        /// Event executed when item is spawned while generation of map.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="ItemType"/> item.
        /// </remarks>
        ItemSpawned,

        /// <summary>
        /// Event executed when generator activates.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="Generator"/> generator.
        /// </remarks>
        GeneratorActivated,

        /// <summary>
        /// Event executed when blood is placed.
        /// </summary>
        PlaceBlood,

        /// <summary>
        /// Event executed when bullet hole is placed.
        /// </summary>
        PlaceBulletHole,

        /// <summary>
        /// Event executed when player activated generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerActivateGenerator,

        /// <summary>
        /// Event executed when player aims weapon
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> weapon, <see cref="bool"/> isAiming.
        /// </remarks>
        PlayerAimWeapon,

        /// <summary>
        /// Event executed when player gets banned.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> issuer, ref <see cref="string"/> reason, ref <see cref="long"/> duration.
        /// </remarks>
        PlayerBanned,

        /// <summary>
        /// Event executed when player cancels using item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="UsableItem"/> item.
        /// </remarks>
        PlayerCancelUsingItem,

        /// <summary>
        /// Event executed when player changes current item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ushort"/> oldItem, <see cref="ushort"/> newItem.
        /// </remarks>
        PlayerChangeItem,

        /// <summary>
        /// Event executed when player changes range in radio.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="byte"> range.
        /// </remarks>
        PlayerChangeRadioRange,

        /// <summary>
        /// Event executed when player changes spectating player.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> oldTarget, <see cref="IPlayer"/> newTarget.
        /// </remarks>
        PlayerChangeSpectator,

        /// <summary>
        /// Event executed when player closes generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerCloseGenerator,

        /// <summary>
        /// Event executed when player damages shooting target.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ShootingTarget"/> target, <see cref="DamageHandlerBase"/> damageHandler, <see cref="float"/> damageAmount.
        /// </remarks>
        PlayerDamagedShootingTarget,

        /// <summary>
        /// Event executed when player damages window.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="BreakableWindow"/> window, <see cref="DamageHandlerBase"/> damageHandler, <see cref="float"/> damageAmount.
        /// </remarks>
        PlayerDamagedWindow,

        /// <summary>
        /// Event executed when player deactivates generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerDeactivatedGenerator,

        /// <summary>
        /// Event executed when player drops ammo.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemType"/> type. <see cref="int"/> amount.
        /// </remarks>
        PlayerDropAmmo,

        /// <summary>
        /// Event executed when player drops item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerDropItem,

        /// <summary>
        /// Event executed when player dryfires weapon.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> weapon.
        /// </remarks>
        PlayerDryfireWeapon,

        /// <summary>
        /// Event executed when player escapes.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="RoleTypeId"/> newClass.
        /// </remarks>
        PlayerEscape,

        /// <summary>
        /// Event executed when player handcuffs other player.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target.
        /// </remarks>
        PlayerHandcuff,

        /// <summary>
        /// Event executed when player removes handcuffs from other player.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target.
        /// </remarks>
        PlayerRemoveHandcuffs,

        /// <summary>
        /// Event executed when player damages someone.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="DamageHandlerBase"/> damageHandler.
        /// </remarks>
        PlayerDamage,

        /// <summary>
        /// Event executed when player interacts with elevator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractElevator,

        /// <summary>
        /// Event executed when player interacts with locker.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractLocker,

        /// <summary>
        /// Event executed when player interacts with SCP330.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractScp330,

        /// <summary>
        /// Event executed when player interacts with shooting target.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerInteractShootingTarget,

        /// <summary>
        /// Event executed when player gets kicked from server.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerKicked,

        /// <summary>
        /// Event executed when player makes noise.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player.
        /// </remarks>
        PlayerMakeNoise,

        /// <summary>
        /// Event executed when player opens generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerOpenGenerator,

        /// <summary>
        /// Event executed when player pickups ammo.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerPickupAmmo,

        /// <summary>
        /// Event executed when player pickups armor.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerPickupArmor,

        /// <summary>
        /// Event executed when player pickups SCP330.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerPickupScp330,

        /// <summary>
        /// Event executed when player preauths.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="string"/> userid, <see cref="string"/> ipAddress, <see cref="long"/> expiration, <see cref="CentralAuthPreauthFlags"/> flags, <see cref="string"/> country, <see cref="byte[]"/> signature.
        /// </remarks>
        PlayerPreauth,

        /// <summary>
        /// Event executed when player receives effect.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="PlayerEffect"/> effect.
        /// </remarks>
        PlayerReceiveEffect,

        /// <summary>
        /// Event executed when player reloads weapon.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Firearm"/> weapon.
        /// </remarks>
        PlayerReloadWeapon,

        /// <summary>
        /// Event executed when player changes role.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="PlayerRoleBase"/> oldRole, <see cref="PlayerRoleBase"/> newRole, <see cref="RoleChangeReason"/> reason.
        /// </remarks>
        PlayerChangeRole,

        /// <summary>
        /// Event executed when player searches pickup.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
        /// </remarks>
        PlayerSearchPickup,

		/// <summary>
		/// Event executed when player searched pickup.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="ItemPickupBase"/> item.
		/// </remarks>
		PlayerSearchedPickup,

		/// <summary>
		/// Event executed when player shots weapon.
		/// </summary>
		/// <remarks>
		/// Parameters: <see cref="IPlayer"/> player, <see cref="Firearm"/> item.
		/// </remarks>
		PlayerShotWeapon,

        /// <summary>
        /// Event executed when player spawns.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="RoleTypeId"/> role.
        /// </remarks>
        PlayerSpawn,

        /// <summary>
        /// Event executed when ragdoll spawns.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IRagdollRole"/> ragdoll, <see cref="DamageHandlerBase"/> damageHandler.
        /// </remarks>
        RagdollSpawn,

        /// <summary>
        /// Event executed when player throws item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerThrowItem,

        /// <summary>
        /// Event executed when player toggles flashlight.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item, <see cref="bool"/> isToggled.
        /// </remarks>
        PlayerToggleFlashlight,

        /// <summary>
        /// Event executed when player unloads weapon.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> weapon.
        /// </remarks>
        PlayerUnloadWeapon,

        /// <summary>
        /// Event executed when player unlocks generator.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Generator"/> generator.
        /// </remarks>
        PlayerUnlockGenerator,

        /// <summary>
        /// Event executed when player used item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerUsedItem,

        /// <summary>
        /// Event executed when player uses hotkey.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="ActionName"/> hotkey.
        /// </remarks>
        PlayerUseHotkey,

        /// <summary>
        /// Event executed when player starts using item.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="Item"/> item.
        /// </remarks>
        PlayerUseItem,

        /// <summary>
        /// Event executed when player reports someone for breaking server rules.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="string"/> reason.
        /// </remarks>
        PlayerReport,

        /// <summary>
        /// Event executed when player reports someone for cheating.
        /// </summary>
        /// <remarks>
        /// Parameters: <see cref="IPlayer"/> player, <see cref="IPlayer"/> target, <see cref="string"/> reason.
        /// </remarks>
        PlayerCheaterReport,

        /// <summary>
        /// Event executed when round ended.
        /// </summary>
        RoundEnd,

        /// <summary>
        /// Event executed when round restarts.
        /// </summary>
        RoundRestart,

		/// <summary>
		/// Event executed when round starts.
		/// </summary>
		RoundStart,

		/// <summary>
		/// Event executed when server waits for players.
		/// </summary>
		WaitingForPlayers,
    }
}
