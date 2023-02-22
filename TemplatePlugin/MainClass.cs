using Footprinting;
using Interactables.Interobjects;
using InventorySystem.Items.ThrowableProjectiles;
using MapGeneration;
using PlayerRoles.Voice;
using PluginAPI.Events.EventArgs.Map;
using PluginAPI.Events.EventArgs.Player;
using PluginAPI.Events.EventArgs.Scp330;
using PluginAPI.Events.EventArgs.Server;
using UnityEngine;

namespace TemplatePlugin
{
	using CommandSystem;
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

			foreach (var module in modules)
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
		void OnPlayerJoin(JoinedEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.UserId}&r joined this server");

			foreach (var plr in Player.GetPlayers())
			{
				Log.Info($"Player online &6{plr.Nickname}&r, role &6{plr.Role}&r");
			}
		}

		[PluginEvent(ServerEventType.PlayerLeft)]
		void OnPlayerLeave(LeftEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.UserId}&r left this server");
		}

		[PluginEvent(ServerEventType.PlayerDying)]
		bool OnPlayerDying(DyingEventArgs ev)
		{
			var condition = false;

			if (condition is true)
			{
				// The event is canceled and the player does not die
				return false;
			}
			else
			{
				Log.Info(ev.Attacker == null
					? $"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is dying, cause {(ev.DamageHandler as AttackerDamageHandler)?.ServerLogsText}"
					: $"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is dying by &6{ev.Attacker.Nickname}&r (&6{ev.Attacker.UserId}&r), cause {(ev.DamageHandler as AttackerDamageHandler)?.ServerLogsText}");
				// The event runs normally
				return true;
			}
		}

		[PluginEvent(ServerEventType.PlayerDeath)]
		void OnPlayerDied(DiedEventArgs ev)
		{
			if (ev.Attacker == null)
				Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) died, cause {(ev.Damage as AttackerDamageHandler)?.ServerLogsText}");
			else
				Log.Info($"Player &6{ev.Attacker.Nickname}&r (&6{ev.Attacker.UserId}&r) killed &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r), cause {(ev.Damage as AttackerDamageHandler)?.ServerLogsText}");
		}

		[PluginEvent(ServerEventType.LczDecontaminationStart)]
		void OnLczDecontaminationStarts()
		{
			Log.Info("Started LCZ decontamination.");
		}

		[PluginEvent(ServerEventType.LczDecontaminationAnnouncement)]
		void OnAnnounceLczDecontamination(AnnouncingDecontaminationEventArgs ev)
		{
			Log.Info($"LCZ Annoucement &6{ev.AnnounceType}&r.");
		}

		[PluginEvent(ServerEventType.MapGenerated)]
		void OnMapGenerated(MapGeneratedEventArgs ev)
		{
			Log.Info($"Map generated, seed: {ev.Seed}");
		}

		[PluginEvent(ServerEventType.GrenadeExploded)]
		void OnGrenadeExploded(ExplodingGrenadeEventArgs ev)
		{
			Log.Info($"Grenade &6{ev.Grenade.NetworkInfo.ItemId}&r thrown by &6{ev.Grenade.PreviousOwner.Nickname}&r exploded at &6{ev.Grenade.NetworkInfo.RelativePosition.Position}&r");
		}

		[PluginEvent(ServerEventType.ItemSpawned)]
		void OnItemSpawned(SpawningItemEventArgs ev)
		{
			Log.Info($"Item &6{ev.Item}&r spawned on map on position {ev.Position}");
		}

		[PluginEvent(ServerEventType.GeneratorActivated)]
		void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
		{
			Log.Info($"Generator on room {ev.Generator.Room.Identifier.Name} activated");
		}

		[PluginEvent(ServerEventType.PlaceBlood)]
		void OnPlaceBlood(PlacingBloodEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r blood placed on map position &6{ev.Position}&r");
		}

		[PluginEvent(ServerEventType.PlaceBulletHole)]
		void OnPlaceBulletHole(PlacingBulletHoleEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r bullet hole has been placed on map. Position &6{ev.Position}&r.");
		}

		[PluginEvent(ServerEventType.PlayerActivateGenerator)]
		void OnPlayerActivateGenerator(ActivatingGeneratorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) activated generator with remaining time &6{ev.Generator.RemainingTime}&r");
		}

		[PluginEvent(ServerEventType.PlayerAimWeapon)]
		void OnPlayerAimsWeapon(AimingWeaponEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is {(ev.IsAiming ? "aiming" : "not aiming")} gun &6{ev.Weapon.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerBanned)]
		void OnPlayerBanned(BanningEventArgs ev)
		{
			Log.Info($"Player &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) got banned by &6{ev.Issuer.Nickname}&r with reason &6{ev.Reason}&r for duration &6{ev.Duration}&r seconds");
		}

		[PluginEvent(ServerEventType.PlayerCancelUsingItem)]
		void OnPlayerCancelsUsingItem(CancellingItemUseEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) cancelled using item &6{ev.Item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerChangeItem)]
		void OnPlayerChangesItem(ChangingItemEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) change current item &6{ev.OldItem}&r to &6{ev.NewItem}&r");
		}

		[PluginEvent(ServerEventType.PlayerChangeRadioRange)]
		void OnPlayerChangesRadioRange(ChangingRadioRangeEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed radio range to &6{ev.NewRange}&r");
		}

		[PluginEvent(ServerEventType.PlayerRadioToggle)]
		void OnPlayerRadioToggle(ToggledRadioEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) toggled the radio state to &6{ev.NewState}&r");
		}

		[PluginEvent(ServerEventType.PlayerUsingRadio)]
		void OnPlayerUsingRadio(UsingRadioBatteryEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is using a radio and its draining &6{ev.Drain}&r of the battery");
		}

		[PluginEvent(ServerEventType.CassieAnnouncesScpTermination)]
		void OnCassieAnnouncScpTermination(AnnouncingScpTerminationEventArgs ev)
		{
			Log.Info($"Cassie announce a SCP termination of player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r), CASSIE announcement is &6{ev.Announcement}&r");
		}

		[PluginEvent(ServerEventType.PlayerGetGroup)]
		void OnPlayerChangeGroup(GettingGroupEventArgs ev)
		{
			Log.Info($"User group of {ev.UserId} is &6{ev.Group?.BadgeText ?? "(null)"}&r");
		}

		[PluginEvent(ServerEventType.PlayerUsingIntercom)]
		void OnPlayerUsingIntercom(UsingIntercomEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is using Intercom");
		}

		[PluginEvent(ServerEventType.PlayerChangeSpectator)]
		void OnPlayerChangesSpectatedPlayer(ChangingSpectatedPlayerEventArgs ev)
		{
			if (ev.OldTarget == null && ev.NewTarget != null)
			{
				Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is now spectating &6{ev.NewTarget.Nickname}&r (&6{ev.NewTarget.UserId}&r)");

			}
			else if (ev.OldTarget != null && ev.NewTarget != null)
			{
				Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed spectated player &6{ev.OldTarget.Nickname}&r (&6{ev.OldTarget.UserId}&r) to &6{ev.NewTarget.Nickname}&r (&6{ev.NewTarget.UserId}&r)");
			}
		}

		[PluginEvent(ServerEventType.PlayerCloseGenerator)]
		void OnPlayerClosesGenerator(ClosingGeneratorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) closed generator");
		}

		[PluginEvent(ServerEventType.PlayerDamagedShootingTarget)]
		void OnPlayerDamagedShootingTarget(DamagingShootingTargetEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) hit shooting target with damage amount &6{ev.Amount}&r");
		}

		[PluginEvent(ServerEventType.PlayerDamagedWindow)]
		void OnPlayerDamagedWindow(DamagingWindowEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) damaged window with damage amount &6{ev.Amount}&r");
		}

		[PluginEvent(ServerEventType.PlayerDeactivatedGenerator)]
		void OnPlayerDeactivatedGenerator(DeactivatingGeneratorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) deactivated a generator.");
		}

		[PluginEvent(ServerEventType.PlayerDropAmmo)]
		void OnPlayerDroppedAmmo(DroppingAmmoEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) dropped &6{ev.Amount}&r ammo of type &6{ev.AmmoType}&r.");
		}

		[PluginEvent(ServerEventType.PlayerDropItem)]
		void OnPlayerDroppedItem(DroppingItemEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) dropped item &6{ev.Item.Type}&r.");
		}

		[PluginEvent(ServerEventType.PlayerDryfireWeapon)]
		void OnPlayerDryfireWeapon(DryWeaponEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) dryfired weapon &6{ev.Weapon.ItemTypeId}&r.");
		}

		[PluginEvent(ServerEventType.PlayerEscape)]
		void OnPlayerEscaped(EscapingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) escaped as &6{ev.Player.Role}&r and new role is &6{ev.NewRole}&r.");
		}

		[PluginEvent(ServerEventType.PlayerHandcuff)]
		void OnPlayerHandcuffed(HandcuffingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) handcuffed &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r).");
		}

		[PluginEvent(ServerEventType.PlayerRemoveHandcuffs)]
		void OnPlayerUncuffed(RemovingHandcuffsEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) uncuffed &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r).");
		}

		[PluginEvent(ServerEventType.PlayerDamage)]
		void OnPlayerDamage(DamagingPlayerEventArgs ev)
		{
			if (ev.Attacker == null)
				Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) got damaged, cause {ev.DamageHandler}.");
			else
				Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) received damage from &6{ev.Attacker.Nickname}&r (&6{ev.Attacker.UserId}&r), cause {ev.DamageHandler}.");
		}

		[PluginEvent(ServerEventType.PlayerKicked)]
		void OnPlayerKicked(KickingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) kicked from server by &6{ev.Issuer.Nickname}&r with reason &6{ev.Reason}&r.");
		}

		[PluginEvent(ServerEventType.PlayerOpenGenerator)]
		void OnPlayerOpenedGenerator(OpeningGeneratorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) opened generator.");
		}


		[PluginEvent(ServerEventType.PlayerPickupAmmo)]
		void OnPlayerPickupAmmo(PickingUpAmmoEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) pickup ammo {ev.AmmoPickup.Info.ItemId}.");
		}

		[PluginEvent(ServerEventType.PlayerPickupArmor)]
		void OnPlayerPickupArmor(PickingUpArmorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) pickup armor {ev.Armor.Info.ItemId}.");
		}

		[PluginEvent(ServerEventType.PlayerPickupScp330)]
		void OnPlayerPickupScp330(PickingUpScp330EventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) pickup scp330 {ev.Candy.ItemTypeId}.");
		}

		[PluginEvent(ServerEventType.PlayerPreauth)]
		void OnPreauth(PreAuthenticatingEventArgs ev)
		{
			Log.Info($"Player &6{ev.UserId}&r (&6{ev.IpAddress}&r) preauthenticated from country &6{ev.Country}&r with central flags &6{ev.Flags}&r");
		}

		[PluginEvent(ServerEventType.PlayerReceiveEffect)]
		void OnReceiveEffect(ReceivingEffectEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) received effect &6{ev.Effect}&r with an intensity of &6{ev.Intensity}&r.");
		}

		[PluginEvent(ServerEventType.PlayerReloadWeapon)]
		void OnReloadWeapon(ReloadingWeaponEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) reloaded weapon &6{ev.Firearm.ItemTypeId}&r.");
		}

		[PluginEvent(ServerEventType.PlayerChangeRole)]
		void OnChangeRole(ChangingRoleEventArgs ev)
		{
			Log.Info(ev.OldRole == null
				? $"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed role to &6{ev.NewRole}&r with reason &6{ev.Reason}&r"
				: $"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed role from &6{ev.OldRole.RoleName}&r to &6{ev.NewRole}&r with reason &6{ev.Reason}&r");
		}

		[PluginEvent(ServerEventType.PlayerSearchPickup)]
		void OnSearchPickup(SearchingPickupEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) started searching pickup &6{ev.Pickup.NetworkInfo.ItemId}&r");
		}

		[PluginEvent(ServerEventType.PlayerSearchedPickup)]
		void OnSearchedPickup(SearchedPickupEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) searched pickup &6{ev.Pickup.NetworkInfo.ItemId}&r");
		}

		[PluginEvent(ServerEventType.PlayerShotWeapon)]
		void OnShotWeapon(ShootingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) shot &6{ev.Firearm.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerSpawn)]
		void OnSpawn(SpawningEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) spawned as &6{ev.RoleType}&r");
		}

		[PluginEvent(ServerEventType.PlayerThrowItem)]
		void OnThrowItem(ThrowingItemEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) thrown item &6{ev.Item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerToggleFlashlight)]
		void OnToggleFlashlight(TogglingFlashlightEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) toggled {(ev.NewState ? "on" : "off")} flashlight on &6{ev.Flashlight.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerUnloadWeapon)]
		void OnUnloadWeapon(UnloadingWeaponEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) unloads &6{ev.Firearm.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerUnlockGenerator)]
		void OnUnlockGenerator(UnlockingGeneratorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) unlocked generator");
		}

		[PluginEvent(ServerEventType.PlayerUsedItem)]
		void OnPlayerUsedItem(UsedItemEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) used item &6{ev.Item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerUseHotkey)]
		void OnPlaeyrUsedHotkey(UsingHotkeyEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) used hotkey &6{ev.Hotkey}&r");
		}

		[PluginEvent(ServerEventType.PlayerUseItem)]
		void OnPlayerStartedUsingItem(UsingItemEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) started using item &6{ev.Item.ItemTypeId}&r");
		}

		[PluginEvent(ServerEventType.PlayerCheaterReport)]
		void OnCheaterReport(ReportingCheaterEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) reported player &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) for cheating with reason &6{ev.Reason}&r");
		}

		[PluginEvent(ServerEventType.PlayerReport)]
		void OnReport(ReportingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) reported player &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) for breaking server rules with reason &6{ev.Reason}&r");
		}

		[PluginEvent(ServerEventType.PlayerInteractShootingTarget)]
		void OnInteractWithShootingTarget(InteractingShootingTargetEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) interacted with shooting target in the position {ev.ShootingTarget.transform.position}");
		}

		[PluginEvent(ServerEventType.PlayerInteractLocker)]
		void OnInteractWithLocker(InteractingLockerEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.CanOpen ? "interacted" : "failed to interact")} with locker and chamber is in the position {ev.Chamber.transform.position}.");
		}

		[PluginEvent(ServerEventType.PlayerInteractElevator)]
		void OnInteractWithElevator(InteractingElevatorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) interacted with elevator in position &6{ev.Elevator.transform.position}&r with the destination in &6{ev.Elevator.CurrentDestination.transform.position}&r");
		}

		[PluginEvent(ServerEventType.PlayerInteractScp330)]
		void OnInteractWithScp330(InteractingScp330EventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) interacted with SCP330.");
		}

		[PluginEvent(ServerEventType.RagdollSpawn)]
		void OnRagdollSpawn(SpawningRagdollEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) spawned ragdoll &6{ev.Ragdoll}&r, reason &6{ev.DamageHandler}&r");
		}

		[PluginEvent(ServerEventType.RoundEnd)]
		void OnRoundEnded(EndingRoundEventArgs ev)
		{
			Log.Info($"Round ended. {ev.LeadingTeam} won!");
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

		[PluginConfig] public MainConfig PluginConfig;

		[PluginConfig("configs/another-config.yml")]
		public AnotherConfig AnotherConfig;
	}
}
