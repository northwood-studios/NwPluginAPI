namespace TemplatePlugin
{
	using AdminToys;
	using CustomPlayerEffects;
	using InventorySystem.Items;
	using InventorySystem.Items.Firearms;
	using InventorySystem.Items.Radio;
	using InventorySystem.Items.Usables;
	using LiteNetLib;
	using MapGeneration.Distributors;
	using PlayerRoles;
	using PlayerStatsSystem;
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Enums;
	using PluginAPI.Events;
	using System;
	using System.Collections.Generic;
	using TemplatePlugin.Configs;
	using TemplatePlugin.Factory;
	using ItemPickupBase = InventorySystem.Items.Pickups.ItemPickupBase;

	public class MainClass
    {
		public static MainClass Singleton { get; private set; }

		[PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("Template Plugin", "1.0.0", "Just a template plugin.", "Northwood")]
        void LoadPlugin()
        {
			Singleton = this;
            Log.Info("Loaded plugin, register events...");
            EventManager.RegisterEvents(this);
			EventManager.RegisterEvents<EventHandlers>(this);
            Log.Info($"Registered events, config &2&b{PluginConfig.IntValue}&B&r, register factory...");
            FactoryManager.RegisterPlayerFactory(this, new MyPlayerFactory());
            Log.Info("Registered player factory!");

			var handler = PluginHandler.Get(this);

			Log.Info(handler.PluginName);
			Log.Info(handler.PluginFilePath);
			Log.Info(handler.PluginDirectoryPath);

			List<string> modules = new List<string>()
			{
				"something1",
			};

			foreach(var module in modules)
			{
				if (!PluginConfig.DictionaryValue.ContainsKey(module))
				{
					PluginConfig.DictionaryValue.Add(module, "yes");
					handler.SaveConfig(this, nameof(PluginConfig));
				}
			}

			PluginConfig.StringValue = "test Value";
			handler.SaveConfig(this, nameof(PluginConfig));

			AnotherConfig.TestList = new List<string>() { "Template0" };
			handler.SaveConfig(this, nameof(AnotherConfig));
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        void OnPlayerJoin(MyPlayer player)
        {
            Log.Info($"Player &6{player.UserId}&r joined this server with &1{player.Test}&4");

            foreach(var plr in Player.GetPlayers())
            {
                Log.Info($"Player online &6{plr.Nickname}&r, role &6{plr.Role}&r");
            }
        }

        [PluginEvent(ServerEventType.PlayerLeft)]
        void OnPlayerLeave(MyPlayer player)
        {
            Log.Info($"Player &6{player.UserId}&r left this server with of &1{player.Test}&4");
        }

        [PluginEvent(ServerEventType.PlayerDeath)]
        void OnPlayerDied(MyPlayer player, MyPlayer attacker, DamageHandlerBase damageHandler)
        {
            if (attacker == null)
                Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) died, cause {damageHandler}");
            else
                Log.Info($"Player &6{attacker.Nickname}&r (&6{attacker.UserId}&r) killed &6{player.Nickname}&r (&6{player.UserId}&r), cause {damageHandler}");
        }

		[PluginEvent(ServerEventType.LczDecontaminationStart)]
        void OnLczDecontaminationStarts()
        {
            Log.Info("Started LCZ decontamination.");
        }

        [PluginEvent(ServerEventType.LczDecontaminationAnnouncement)]
        void OnAnnounceLczDecontamination(int id)
        {
            Log.Info($"LCZ Annoucement &6{id}&r.");
        }

        [PluginEvent(ServerEventType.MapGenerated)]
        void OnMapGenerated()
        {
            Log.Info("Map generated.");
        }

        [PluginEvent(ServerEventType.GrenadeExploded)]
        void OnGrenadeExploded(ItemPickupBase item)
        {
            Log.Info($"Grenade &6{item.NetworkInfo.ItemId}&r thrown by &6{item.PreviousOwner.Nickname}&r exploded at &6{item.NetworkInfo.RelativePosition.ToString()}&r");
        }

        [PluginEvent(ServerEventType.ItemSpawned)]
        void OnItemSpawned(ItemType item)
        {
            Log.Info($"Item &6{item}&r spawned on map");
        }

        [PluginEvent(ServerEventType.GeneratorActivated)]
        void OnGeneratorActivated(Scp079Generator gen)
        {
            Log.Info($"Generator activated");
        }

        [PluginEvent(ServerEventType.PlaceBlood)]
        void OnPlaceBlood()
        {
            Log.Info($"Blood placed on map");
        }

        [PluginEvent(ServerEventType.PlaceBulletHole)]
        void OnPlaceBulletHole()
        {
            Log.Info($"Bullet hole placed on map");
        }

        [PluginEvent(ServerEventType.PlayerActivateGenerator)]
        void OnPlayerActivateGenerator(MyPlayer plr, Scp079Generator gen)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) activated generator with remaining time &6{gen.RemainingTime}&r");
        }

        [PluginEvent(ServerEventType.PlayerAimWeapon)]
        void OnPlayerAimsWeapon(MyPlayer plr, Firearm gun, bool isAiming)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) is {(isAiming ? "aiming" : "not aiming")} gun &6{gun.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerBanned)]
        void OnPlayerBanned(MyPlayer plr, MyPlayer issuer, string reason, long duration)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) got banned by &6{issuer.Nickname}&r (&6{issuer.UserId}&r) with reason &6{reason}&r for duration &6{duration}&r seconds");
        }

        [PluginEvent(ServerEventType.PlayerCancelUsingItem)]
        void OnPlayerCancelsUsingItem(MyPlayer plr, UsableItem item)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) cancelled using item &6{item.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerChangeItem)]
        void OnPlayerChangesItem(MyPlayer plr, ushort oldItem, ushort newItem)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) change current item &6{oldItem}&r to &6{newItem}&r");
        }

        [PluginEvent(ServerEventType.PlayerChangeRadioRange)]
        void OnPlayerChangesRadioRange(MyPlayer plr, RadioItem item, byte range)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed radio range to &6{range}&r");
        }

        [PluginEvent(ServerEventType.PlayerChangeSpectator)]
        void OnPlayerChangesSpectatedPlayer(MyPlayer plr, MyPlayer oldTarget, MyPlayer newTarget)
        {
            if (oldTarget == null && newTarget != null)
            {
                Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) is now spectating &6{newTarget.Nickname}&r (&6{newTarget.UserId}&r)");

            }
            else if (oldTarget != null && newTarget != null)
            {
                Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed spectated player &6{oldTarget.Nickname}&r (&6{oldTarget.UserId}&r) &6{newTarget.Nickname}&r (&6{newTarget.UserId}&r)");
            }
        }

        [PluginEvent(ServerEventType.PlayerCloseGenerator)]
        void OnPlayerClosesGenerator(MyPlayer plr, Scp079Generator gen)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) closed generator");
        }

        [PluginEvent(ServerEventType.PlayerDamagedShootingTarget)]
        void OnPlayerDamagedShootingTarget(MyPlayer plr, ShootingTarget target, DamageHandlerBase dmgHandler, float amount)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) hit shooting target with damage amount &6{amount}&r");
        }

        [PluginEvent(ServerEventType.PlayerDamagedWindow)]
        void OnPlayerDamagedWindow(MyPlayer plr, BreakableWindow window, DamageHandlerBase dmgHandler, float amount)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) damaged window with damage amount &6{amount}&r");
        }

        [PluginEvent(ServerEventType.PlayerDeactivatedGenerator)]
        void OnPlayerDeactivatedGenerator(MyPlayer plr, Scp079Generator gen)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) deactivated a generator.");
        }

        [PluginEvent(ServerEventType.PlayerDropAmmo)]
        void OnPlayerDroppedAmmo(MyPlayer plr, ItemType ammoType, int amount)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) dropped &6{amount}&r ammo of type &6{ammoType}&r.");
        }

        [PluginEvent(ServerEventType.PlayerDropItem)]
        void OnPlayerDroppedItem(MyPlayer plr, ItemBase item)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) dropped item &6{item.ItemTypeId}&r.");
        }

        [PluginEvent(ServerEventType.PlayerDryfireWeapon)]
        void OnPlayerDryfireWeapon(MyPlayer plr, Firearm item)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) dryfired weapon &6{item.ItemTypeId}&r.");
        }

        [PluginEvent(ServerEventType.PlayerEscape)]
        void OnPlayerEscaped(MyPlayer plr, RoleTypeId role)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) escaped as &6{plr.Role}&r and new role is &6{role}&r.");
        }

        [PluginEvent(ServerEventType.PlayerHandcuff)]
        void OnPlayerHandcuffed(MyPlayer plr, MyPlayer target)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) handcuffed &6{target.Nickname}&r (&6{target.UserId}&r).");
        }

        [PluginEvent(ServerEventType.PlayerRemoveHandcuffs)]
        void OnPlayerUncuffed(MyPlayer plr, MyPlayer target)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) uncuffed &6{target.Nickname}&r (&6{target.UserId}&r).");
        }

        [PluginEvent(ServerEventType.PlayerDamage)]
        void OnPlayerDamage(MyPlayer player, MyPlayer attacker, DamageHandlerBase damageHandler)
        {
            if (attacker == null)
                Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) got damaged, cause {damageHandler}.");
            else
                Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) received damage from &6{attacker.Nickname}&r (&6{attacker.UserId}&r), cause {damageHandler}.");
        }

        [PluginEvent(ServerEventType.PlayerKicked)]
        void OnPlayerKicked(MyPlayer plr, MyPlayer issuer, string reason)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) kicked from server by &6{issuer.Nickname}&r (&6{issuer.UserId}&r) with reason &6{reason}&r.");
        }

        [PluginEvent(ServerEventType.PlayerOpenGenerator)]
        void OnPlayerOpenedGenerator(MyPlayer plr, Scp079Generator gen)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) opened generator.");
        }


        [PluginEvent(ServerEventType.PlayerPickupAmmo)]
        void OnPlayerPickupAmmo(MyPlayer plr, ItemPickupBase pickup)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) pickup ammo {pickup.Info.ItemId}.");
        }

        [PluginEvent(ServerEventType.PlayerPickupArmor)]
        void OnPlayerPickupArmor(MyPlayer plr, ItemPickupBase pickup)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) pickup armor {pickup.Info.ItemId}.");
        }

        [PluginEvent(ServerEventType.PlayerPickupScp330)]
        void OnPlayerPickupScp330(MyPlayer plr, ItemPickupBase pickup)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) pickup scp330 {pickup.Info.ItemId}.");
        }

        [PluginEvent(ServerEventType.PlayerPreauth)]
        void OnPreauth(string userid, string ipAddress, long expiration, CentralAuthPreauthFlags flags, string country, byte[] signature, ConnectionRequest req, Int32 index)
        {
            Log.Info($"Player &6{userid}&r (&6{ipAddress}&r) preauthenticated from country &6{country}&r with central flags &6{flags}&r");
		}

        [PluginEvent(ServerEventType.PlayerReceiveEffect)]
        void OnReceiveEffect(MyPlayer plr, StatusEffectBase effect, float duration)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) received effect &6{effect}&r.");
        }

        [PluginEvent(ServerEventType.PlayerReloadWeapon)]
        void OnReloadWeapon(MyPlayer plr, Firearm gun)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) reloaded weapon &6{gun.ItemTypeId}&r.");
        }

        [PluginEvent(ServerEventType.PlayerChangeRole)]
        void OnChangeRole(MyPlayer plr, PlayerRoleBase oldRole, RoleTypeId newRole, RoleChangeReason reason)
        {
			if (oldRole == null)
			{
				Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed role to &6{newRole}&r with reason &6{reason}&r");
			}
			else
			{
				Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) changed role from &6{oldRole.RoleName}&r to &6{newRole}&r with reason &6{reason}&r");
			}
		}

        [PluginEvent(ServerEventType.PlayerSearchPickup)]
        void OnSearchPickup(MyPlayer plr, ItemPickupBase pickup)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) started searching pickup &6{pickup.NetworkInfo.ItemId}&r");
        }

		[PluginEvent(ServerEventType.PlayerSearchedPickup)]
		void OnSearchedPickup(MyPlayer plr, ItemPickupBase pickup)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) searched pickup &6{pickup.NetworkInfo.ItemId}&r");
		}


		[PluginEvent(ServerEventType.PlayerShotWeapon)]
        void OnShotWeapon(MyPlayer plr, Firearm gun)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) shot &6{gun.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerSpawn)]
        void OnSpawn(MyPlayer plr, RoleTypeId role)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) spawned as &6{role}&r");
        }

        [PluginEvent(ServerEventType.PlayerThrowItem)]
        void OnThrowItem(MyPlayer plr, ItemBase item)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) thrown item &6{item.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerToggleFlashlight)]
        void OnToggleFlashlight(MyPlayer plr, ItemBase item, bool isToggled)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) toggled {(isToggled ? "on" : "off")} flashlight on &6{item.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerUnloadWeapon)]
        void OnUnloadWeapon(MyPlayer plr, Firearm gun)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) unloads &6{gun.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerUnlockGenerator)]
        void OnUnlockGenerator(MyPlayer plr, Scp079Generator generator)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) unlocked generator");
        }

        [PluginEvent(ServerEventType.PlayerUsedItem)]
        void OnPlayerUsedItem(MyPlayer plr, ItemBase item)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) used item &6{item.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerUseHotkey)]
        void OnPlaeyrUsedHotkey(MyPlayer plr, ActionName action)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) used hotkey &6{action}&r");
        }

        [PluginEvent(ServerEventType.PlayerUseItem)]
        void OnPlayerStartedUsingItem(MyPlayer plr, UsableItem item)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) started using item &6{item.ItemTypeId}&r");
        }

        [PluginEvent(ServerEventType.PlayerCheaterReport)]
        void OnCheaterReport(MyPlayer plr, MyPlayer target, string reason)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) reported player &6{target.Nickname}&r (&6{target.UserId}&r) for cheating with reason &6{reason}&r");
        }

        [PluginEvent(ServerEventType.PlayerReport)]
        void OnReport(MyPlayer plr, MyPlayer target, string reason)
        {
            Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) reported player &6{target.Nickname}&r (&6{target.UserId}&r) for breaking server rules with reason &6{reason}&r");
        }

		[PluginEvent(ServerEventType.PlayerInteractShootingTarget)]
		void OnInteractWithShootingTarget(MyPlayer plr)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) interacted with shooting target.");
		}

		[PluginEvent(ServerEventType.PlayerInteractLocker)]
		void OnInteractWithLocker(MyPlayer plr, Locker locker, byte colliderId, bool canAccess)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) {(canAccess ? "interacted" : "failed to interact")} with locker and chamberId &2{colliderId}&r.");
		}

		[PluginEvent(ServerEventType.PlayerInteractElevator)]
		void OnInteractWithElevator(MyPlayer plr)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) interacted with elevator.");
		}

		[PluginEvent(ServerEventType.PlayerInteractScp330)]
		void OnInteractWithScp330(MyPlayer plr)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) interacted with SCP330.");
		}

		[PluginEvent(ServerEventType.RagdollSpawn)]
		void OnRagdollSpawn(MyPlayer plr, IRagdollRole ragdoll, DamageHandlerBase damageHandler)
		{
			Log.Info($"Player &6{plr.Nickname}&r (&6{plr.UserId}&r) spawned ragdoll &6{ragdoll.Ragdoll}&r, reason &6{damageHandler}&r");
		}

        [PluginEvent(ServerEventType.RoundEnd)]
        void OnRoundEnded(RoundSummary.LeadingTeam leadingTeam)
        {
            Log.Info($"Round ended. {leadingTeam.ToString()} won!");
        }

        [PluginEvent(ServerEventType.RoundRestart)]
        void OnRestart()
        {
            Log.Info($"Round restarting");
        }

		[PluginEvent(ServerEventType.RoundStart)]
		void OnRoundStart()
		{
			Log.Info($"Round started");
		}


		[PluginEvent(ServerEventType.WaitingForPlayers)]
        void WaitingForPlayers()
        {
            Log.Info($"Waiting for players...");
        }

        [PluginConfig]
        public MainConfig PluginConfig;

		[PluginConfig("configs/another-config.yml")]
		public AnotherConfig AnotherConfig;
    }
}
