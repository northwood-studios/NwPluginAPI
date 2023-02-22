using Footprinting;
using PlayerRoles.PlayableScps.Scp079.Cameras;
using PlayerRoles.PlayableScps.Scp096;
using PlayerRoles.Voice;
using PluginAPI.Events.EventArgs.Scp096;

namespace PluginAPI.Events
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using AdminToys;
	using CustomPlayerEffects;
	using InventorySystem.Items;
	using InventorySystem.Items.Firearms;
	using InventorySystem.Items.Radio;
	using InventorySystem.Items.Usables;
	using MapGeneration.Distributors;
	using PlayerRoles;
	using PlayerStatsSystem;
	using Core;
	using Core.Attributes;
	using Core.Factories;
	using Core.Interfaces;
	using Enums;
	using ItemPickupBase = InventorySystem.Items.Pickups.ItemPickupBase;
	using Respawning;
	using Loader;
	using InventorySystem.Items.ThrowableProjectiles;
	using PlayerRoles.PlayableScps.Scp173;
	using PlayerRoles.PlayableScps.Scp079;
	using MapGeneration;
	using Interactables.Interobjects.DoorUtils;
	using UnityEngine;
	using PlayerRoles.PlayableScps.Scp939;
	using CommandSystem;
	using LiteNetLib;
	using Scp914;
	using Interactables.Interobjects;

	/// <summary>
	/// Manages plugin events.
	/// </summary>
	public static class EventManager
	{
		/// <summary>
		/// Contains all registered event handlers.
		/// </summary>
		private static readonly Dictionary<Type, object> EventHandlers = new Dictionary<Type, object>();

		/// <summary>
		/// Contains all events and their parameters.
		/// </summary>
		public static readonly Dictionary<ServerEventType, Event> Events = new Dictionary<ServerEventType, Event>()
		{
			{
				ServerEventType.PlayerJoined, new Event(
					new EventParameter(typeof(EventArgs.Player.JoinedEventArgs), nameof(EventArgs.Player.JoinedEventArgs)))
			},
			{
				ServerEventType.PlayerLeft, new Event(
					new EventParameter(typeof(EventArgs.Player.LeftEventArgs), nameof(EventArgs.Player.LeftEventArgs)))
			},
			{
				ServerEventType.PlayerDying, new Event(
					new EventParameter(typeof(EventArgs.Player.DyingEventArgs), nameof(EventArgs.Player.DyingEventArgs)))
			},
			{
				ServerEventType.LczDecontaminationStart, new Event()
			},
			{
				ServerEventType.LczDecontaminationAnnouncement, new Event(
					new EventParameter(typeof(EventArgs.Map.AnnouncingDecontaminationEventArgs), nameof(EventArgs.Map.AnnouncingDecontaminationEventArgs)))
			},
			{
				ServerEventType.MapGenerated, new Event(
					new EventParameter(typeof(EventArgs.Server.MapGeneratedEventArgs), nameof(EventArgs.Server.MapGeneratedEventArgs)))
			},
			{
				ServerEventType.GrenadeExploded, new Event(
					new EventParameter(typeof(EventArgs.Map.ExplodingGrenadeEventArgs), nameof(EventArgs.Map.ExplodingGrenadeEventArgs)))
			},
			{
				ServerEventType.ItemSpawned, new Event(
					new EventParameter(typeof(EventArgs.Map.SpawningItemEventArgs), nameof(EventArgs.Map.SpawningItemEventArgs)))
			},
			{
				ServerEventType.GeneratorActivated, new Event(
					new EventParameter(typeof(EventArgs.Map.GeneratorActivatedEventArgs), nameof(EventArgs.Map.GeneratorActivatedEventArgs)))
			},
			{
				ServerEventType.PlaceBlood, new Event(
					new EventParameter(typeof(EventArgs.Map.PlacingBloodEventArgs), nameof(EventArgs.Map.PlacingBloodEventArgs)))
			},
			{
				ServerEventType.PlaceBulletHole, new Event(
					new EventParameter(typeof(EventArgs.Map.PlacingBulletHoleEventArgs), nameof(EventArgs.Map.PlacingBulletHoleEventArgs)))
			},
			{
				ServerEventType.PlayerActivateGenerator, new Event(
					new EventParameter(typeof(EventArgs.Player.ActivatingGeneratorEventArgs), nameof(EventArgs.Player.ActivatingGeneratorEventArgs)))
			},
			{
				ServerEventType.PlayerAimWeapon, new Event(
					new EventParameter(typeof(EventArgs.Player.AimingWeaponEventArgs), nameof(EventArgs.Player.AimingWeaponEventArgs)))
			},
			{
				ServerEventType.PlayerBanned, new Event(
					new EventParameter(typeof(EventArgs.Player.BanningEventArgs), nameof(EventArgs.Player.BanningEventArgs)))
			},
			{
				ServerEventType.PlayerCancelUsingItem, new Event(
					new EventParameter(typeof(EventArgs.Player.CancellingItemUseEventArgs), nameof(EventArgs.Player.CancellingItemUseEventArgs)))
			},
			{
				ServerEventType.PlayerChangeItem, new Event(
					new EventParameter(typeof(EventArgs.Player.ChangingItemEventArgs), nameof(EventArgs.Player.ChangingItemEventArgs)))
			},
			{
				ServerEventType.PlayerChangeRadioRange, new Event(
					new EventParameter(typeof(EventArgs.Player.ChangingRadioRangeEventArgs), nameof(EventArgs.Player.ChangingRadioRangeEventArgs)))
			},
			{
				ServerEventType.PlayerChangeSpectator, new Event(
					new EventParameter(typeof(EventArgs.Player.ChangingSpectatedPlayerEventArgs), nameof(EventArgs.Player.ChangingSpectatedPlayerEventArgs)))
			},
			{
				ServerEventType.PlayerCloseGenerator, new Event(
					new EventParameter(typeof(EventArgs.Player.ClosingGeneratorEventArgs), nameof(EventArgs.Player.ClosingGeneratorEventArgs)))
			},
			{
				ServerEventType.PlayerDamagedShootingTarget, new Event(
					new EventParameter(typeof(EventArgs.Player.DamagingShootingTargetEventArgs), nameof(EventArgs.Player.DamagingShootingTargetEventArgs)))
			},
			{
				ServerEventType.PlayerDamagedWindow, new Event(
					new EventParameter(typeof(EventArgs.Player.DamagingWindowEventArgs), nameof(EventArgs.Player.DamagingWindowEventArgs)))
			},
			{
				ServerEventType.PlayerDeactivatedGenerator, new Event(
					new EventParameter(typeof(EventArgs.Player.DeactivatingGeneratorEventArgs), nameof(EventArgs.Player.DeactivatingGeneratorEventArgs)))
			},
			{
				ServerEventType.PlayerDropAmmo, new Event(
					new EventParameter(typeof(EventArgs.Player.DroppingAmmoEventArgs), nameof(EventArgs.Player.DroppingAmmoEventArgs)))
			},
			{
				ServerEventType.PlayerDropItem, new Event(
					new EventParameter(typeof(EventArgs.Player.DroppingItemEventArgs), nameof(EventArgs.Player.DroppingItemEventArgs)))
			},
			{
				ServerEventType.PlayerDryfireWeapon, new Event(
					new EventParameter(typeof(EventArgs.Player.DryWeaponEventArgs), nameof(EventArgs.Player.DryWeaponEventArgs)))
			},
			{
				ServerEventType.PlayerEscape, new Event(
					new EventParameter(typeof(EventArgs.Player.EscapingEventArgs), nameof(EventArgs.Player.EscapingEventArgs)))
			},
			{
				ServerEventType.PlayerHandcuff, new Event(
					new EventParameter(typeof(EventArgs.Player.HandcuffingEventArgs), nameof(EventArgs.Player.HandcuffingEventArgs)))
			},
			{
				ServerEventType.PlayerRemoveHandcuffs, new Event(
					new EventParameter(typeof(EventArgs.Player.RemovingHandcuffsEventArgs), nameof(EventArgs.Player.RemovingHandcuffsEventArgs)))
			},
			{
				ServerEventType.PlayerDamage, new Event(
					new EventParameter(typeof(EventArgs.Player.DamagingPlayerEventArgs), nameof(EventArgs.Player.DamagingPlayerEventArgs)))
			},
			{
				ServerEventType.PlayerInteractElevator, new Event(
					new EventParameter(typeof(EventArgs.Player.InteractingElevatorEventArgs), nameof(EventArgs.Player.InteractingElevatorEventArgs)))
			},
			{
				ServerEventType.PlayerInteractLocker, new Event(
					new EventParameter(typeof(EventArgs.Player.InteractingLockerEventArgs), nameof(EventArgs.Player.InteractingLockerEventArgs)))
			},
			{
				ServerEventType.PlayerInteractScp330, new Event(
					new EventParameter(typeof(EventArgs.Scp330.InteractingScp330EventArgs), nameof(EventArgs.Scp330.InteractingScp330EventArgs)))
			},
			{
				ServerEventType.PlayerInteractShootingTarget, new Event(
					new EventParameter(typeof(EventArgs.Player.InteractingShootingTargetEventArgs), nameof(EventArgs.Player.InteractingShootingTargetEventArgs)))
			},
			{
				ServerEventType.PlayerKicked, new Event(
					new EventParameter(typeof(EventArgs.Player.KickingEventArgs), nameof(EventArgs.Player.KickingEventArgs)))
			},
			{
				ServerEventType.PlayerMakeNoise, new Event(
					new EventParameter(typeof(EventArgs.Player.MakingNoiseEventArgs), nameof(EventArgs.Player.MakingNoiseEventArgs)))
			},
			{
				ServerEventType.PlayerOpenGenerator, new Event(
					new EventParameter(typeof(EventArgs.Player.OpeningGeneratorEventArgs), nameof(EventArgs.Player.OpeningGeneratorEventArgs)))
			},
			{
				ServerEventType.PlayerPickupAmmo, new Event(
					new EventParameter(typeof(EventArgs.Player.PickingUpAmmoEventArgs), nameof(EventArgs.Player.PickingUpAmmoEventArgs)))
			},
			{
				ServerEventType.PlayerPickupArmor, new Event(
					new EventParameter(typeof(EventArgs.Player.PickingUpArmorEventArgs), nameof(EventArgs.Player.PickingUpArmorEventArgs)))
			},
			{
				ServerEventType.PlayerPickupScp330, new Event(
					new EventParameter(typeof(EventArgs.Scp330.PickingUpScp330EventArgs), nameof(EventArgs.Scp330.PickingUpScp330EventArgs)))
			},
			{
				ServerEventType.PlayerPreauth, new Event(
					new EventParameter(typeof(EventArgs.Player.PreAuthenticatingEventArgs), nameof(EventArgs.Player.PreAuthenticatingEventArgs)))
			},
			{
				ServerEventType.PlayerReceiveEffect, new Event(
					new EventParameter(typeof(EventArgs.Player.ReceivingEffectEventArgs), nameof(EventArgs.Player.ReceivingEffectEventArgs)))
			},
			{
				ServerEventType.PlayerReloadWeapon, new Event(
					new EventParameter(typeof(EventArgs.Player.ReloadingWeaponEventArgs), nameof(EventArgs.Player.ReloadingWeaponEventArgs)))
			},
			{
				ServerEventType.PlayerChangeRole, new Event(
					new EventParameter(typeof(EventArgs.Player.ChangingRoleEventArgs), nameof(EventArgs.Player.ChangingRoleEventArgs)))
			},
			{
				ServerEventType.PlayerSearchPickup, new Event(
					new EventParameter(typeof(EventArgs.Player.SearchingPickupEventArgs), nameof(EventArgs.Player.SearchingPickupEventArgs)))
			},
			{
				ServerEventType.PlayerSearchedPickup, new Event(
					new EventParameter(typeof(EventArgs.Player.SearchedPickupEventArgs), nameof(EventArgs.Player.SearchedPickupEventArgs)))
			},
			{
				ServerEventType.PlayerShotWeapon, new Event(
					new EventParameter(typeof(EventArgs.Player.ShootingEventArgs), nameof(EventArgs.Player.ShootingEventArgs)))
			},
			{
				ServerEventType.PlayerSpawn, new Event(
					new EventParameter(typeof(EventArgs.Player.SpawningEventArgs), nameof(EventArgs.Player.SpawningEventArgs)))
			},
			{
				ServerEventType.RagdollSpawn, new Event(
					new EventParameter(typeof(EventArgs.Player.SpawningRagdollEventArgs), nameof(EventArgs.Player.SpawningRagdollEventArgs)))
			},
			{
				ServerEventType.PlayerThrowItem, new Event(
					new EventParameter(typeof(EventArgs.Player.ThrowingItemEventArgs), nameof(EventArgs.Player.ThrowingItemEventArgs)))
			},
			{
				ServerEventType.PlayerToggleFlashlight, new Event(
					new EventParameter(typeof(EventArgs.Player.TogglingFlashlightEventArgs), nameof(EventArgs.Player.TogglingFlashlightEventArgs)))
			},
			{
				ServerEventType.PlayerUnloadWeapon, new Event(
					new EventParameter(typeof(EventArgs.Player.UnloadingWeaponEventArgs), nameof(EventArgs.Player.UnloadingWeaponEventArgs)))
			},
			{
				ServerEventType.PlayerUnlockGenerator, new Event(
					new EventParameter(typeof(EventArgs.Player.UnlockingGeneratorEventArgs), nameof(EventArgs.Player.UnlockingGeneratorEventArgs)))
			},
			{
				ServerEventType.PlayerUsedItem, new Event(
					new EventParameter(typeof(EventArgs.Player.UsedItemEventArgs), nameof(EventArgs.Player.UsedItemEventArgs)))
			},
			{
				ServerEventType.PlayerUseHotkey, new Event(
					new EventParameter(typeof(EventArgs.Player.UsingHotkeyEventArgs), nameof(EventArgs.Player.UsingHotkeyEventArgs)))
			},
			{
				ServerEventType.PlayerUseItem, new Event(
					new EventParameter(typeof(EventArgs.Player.UsingItemEventArgs), nameof(EventArgs.Player.UsingItemEventArgs)))
			},
			{
				ServerEventType.PlayerReport, new Event(
					new EventParameter(typeof(EventArgs.Player.ReportingEventArgs), nameof(EventArgs.Player.ReportingEventArgs)))
			},
			{
				ServerEventType.PlayerCheaterReport, new Event(
					new EventParameter(typeof(EventArgs.Server.ReportingCheaterEventArgs), nameof(EventArgs.Server.ReportingCheaterEventArgs)))
			},
			{
				ServerEventType.RoundEnd, new Event(
					new EventParameter(typeof(EventArgs.Server.EndingRoundEventArgs), nameof(EventArgs.Server.EndingRoundEventArgs)))
			},
			{
				ServerEventType.RoundRestart, new Event()

			},
			{
				ServerEventType.RoundStart, new Event()

			},
			{
				ServerEventType.WaitingForPlayers, new Event()
			},
			{
				ServerEventType.WarheadStart, new Event(
					new EventParameter(typeof(EventArgs.Warhead.StartingEventArgs), nameof(EventArgs.Warhead.StartingEventArgs)))
			},
			{
				ServerEventType.WarheadStop, new Event(
					new EventParameter(typeof(EventArgs.Warhead.StoppingEventArgs), nameof(EventArgs.Warhead.StoppingEventArgs)))
			},
			{
				ServerEventType.WarheadDetonation, new Event()

			},
			{
				ServerEventType.PlayerMuted, new Event(
					new EventParameter(typeof(EventArgs.Player.MutedEventArgs), nameof(EventArgs.Player.MutedEventArgs)))
			},
			{
				ServerEventType.PlayerUnmuted, new Event(
					new EventParameter(typeof(EventArgs.Player.UnMuteEventArgs), nameof(EventArgs.Player.UnMuteEventArgs)))
			},
			{
				ServerEventType.PlayerCheckReservedSlot, new Event(
					new EventParameter(typeof(EventArgs.Player.CheckingReservedSlotsEventArgs), nameof(EventArgs.Player.CheckingReservedSlotsEventArgs)))
			},
			{
				ServerEventType.RemoteAdminCommand, new Event(
					new EventParameter(typeof(EventArgs.Player.UsingRaCommandEventArgs), nameof(EventArgs.Player.UsingRaCommandEventArgs)))
			},
			{
				ServerEventType.PlayerGameConsoleCommand, new Event(
					new EventParameter(typeof(EventArgs.Player.UsingGameConsoleCommand), nameof(EventArgs.Player.UsingGameConsoleCommand)))
			},
			{
				ServerEventType.ConsoleCommand, new Event(
					new EventParameter(typeof(EventArgs.Server.UseConsoleCommandEventArgs), nameof(EventArgs.Server.UseConsoleCommandEventArgs)))
			},
			{
				ServerEventType.TeamRespawn, new Event(
					new EventParameter(typeof(EventArgs.Server.TeamRespawningEventArgs), nameof(EventArgs.Server.TeamRespawningEventArgs)))
			},
			{
				ServerEventType.TeamRespawnSelected, new Event(
					new EventParameter(typeof(EventArgs.Server.TeamRespawnSelectedEventArgs), nameof(EventArgs.Server.TeamRespawnSelectedEventArgs)))
			},
			{
				ServerEventType.Scp106Stalking, new Event(
					new EventParameter(typeof(EventArgs.Scp106.StalkingEventArgs), nameof(EventArgs.Scp106.StalkingEventArgs)))
			},
			{
				ServerEventType.PlayerEnterPocketDimension, new Event(
					new EventParameter(typeof(EventArgs.Player.EnteringPocketDimensionEventArgs), nameof(EventArgs.Player.EnteringPocketDimensionEventArgs)))
			},
			{
				ServerEventType.PlayerExitPocketDimension, new Event(
					new EventParameter(typeof(EventArgs.Player.TryEscapingPocketDimensionEventArgs), nameof(EventArgs.Player.TryEscapingPocketDimensionEventArgs)))
			},
			{
				ServerEventType.PlayerThrowProjectile, new Event(
					new EventParameter(typeof(EventArgs.Player.ThrowingProjectileEventArgs), nameof(EventArgs.Player.ThrowingProjectileEventArgs)))
			},
			{
				ServerEventType.Scp914Activate, new Event(
					new EventParameter(typeof(EventArgs.Scp914.ActivatingEventArgs), nameof(EventArgs.Scp914.ActivatingEventArgs)))
			},
			{
				ServerEventType.Scp914KnobChange, new Event(
					new EventParameter(typeof(EventArgs.Scp914.ChangingKnobSettingEventArgs), nameof(EventArgs.Scp914.ChangingKnobSettingEventArgs)))
			},
			{
				ServerEventType.Scp914UpgradeInventory, new Event(
					new EventParameter(typeof(EventArgs.Scp914.UpgradingInventoryItemEventArgs), nameof(EventArgs.Scp914.UpgradingInventoryItemEventArgs)))
			},
			{
				ServerEventType.Scp914UpgradePickup, new Event(
					new EventParameter(typeof(EventArgs.Scp914.UpgradingPickupEventArgs), nameof(EventArgs.Scp914.UpgradingPickupEventArgs)))
			},
			{
				ServerEventType.Scp106TeleportPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp106.KidnappingPlayerEventArgs), nameof(EventArgs.Scp106.KidnappingPlayerEventArgs)))
			},
			{
				ServerEventType.Scp173PlaySound, new Event(
					new EventParameter(typeof(EventArgs.Scp173.PlayingSoundEventArgs), nameof(EventArgs.Scp173.PlayingSoundEventArgs)))
			},
			{
				ServerEventType.Scp173CreateTantrum, new Event(
					new EventParameter(typeof(EventArgs.Scp173.PlacingTantrumEventArgs), nameof(EventArgs.Scp173.PlacingTantrumEventArgs)))
			},
			{
				ServerEventType.Scp173BreakneckSpeeds, new Event(
					new EventParameter(typeof(EventArgs.Scp173.UsingBreakneckSpeedsEventArgs), nameof(EventArgs.Scp173.UsingBreakneckSpeedsEventArgs)))
			},
			{
				ServerEventType.Scp173NewObserver, new Event(
					new EventParameter(typeof(EventArgs.Scp173.NewObserverEventArgs), nameof(EventArgs.Scp173.NewObserverEventArgs)))
			},
			{
				ServerEventType.Scp173SnapPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp173.SnapPlayerNeckEventArgs), nameof(EventArgs.Scp173.SnapPlayerNeckEventArgs)))
			},
			{
				ServerEventType.Scp939CreateAmnesticCloud, new Event(
					new EventParameter(typeof(EventArgs.Scp939.CreatingAmnesticCloudEventArgs), nameof(EventArgs.Scp939.CreatingAmnesticCloudEventArgs)))
			},
			{
				ServerEventType.Scp939Lunge, new Event(
					new EventParameter(typeof(EventArgs.Scp939.LungeEventArgs), nameof(EventArgs.Scp939.LungeEventArgs)))
			},
			{
				ServerEventType.Scp939Attack, new Event(
					new EventParameter(typeof(EventArgs.Scp939.ScratchingEventArgs), nameof(EventArgs.Scp939.ScratchingEventArgs)))
			},
			{
				ServerEventType.Scp079GainExperience, new Event(
					new EventParameter(typeof(EventArgs.Scp079.GainExperienceEventArgs), nameof(EventArgs.Scp079.GainExperienceEventArgs)))
			},
			{
				ServerEventType.Scp079LevelUpTier, new Event(
					new EventParameter(typeof(EventArgs.Scp079.GainLevelEventArgs), nameof(EventArgs.Scp079.GainLevelEventArgs)))
			},
			{
				ServerEventType.Scp079UseTesla, new Event(
					new EventParameter(typeof(EventArgs.Scp079.UsingTeslaEventArgs), nameof(EventArgs.Scp079.UsingTeslaEventArgs)))
			},
			{
				ServerEventType.Scp079LockdownRoom, new Event(
					new EventParameter(typeof(EventArgs.Scp079.LockingDownRoomEventArgs), nameof(EventArgs.Scp079.LockingDownRoomEventArgs)))
			},
			{
				ServerEventType.Scp079CancelRoomLockdown, new Event(
					new EventParameter(typeof(EventArgs.Scp079.CancelsRoomLockdownEventArgs), nameof(EventArgs.Scp079.CancelsRoomLockdownEventArgs)))
			},
			{
				ServerEventType.Scp079LockDoor, new Event(
					new EventParameter(typeof(EventArgs.Scp079.LockingDownDoorEventArgs), nameof(EventArgs.Scp079.LockingDownDoorEventArgs)))
			},
			{
				ServerEventType.Scp079UnlockDoor, new Event(
					new EventParameter(typeof(EventArgs.Scp079.CancelsDoorLockdownEventArgs), nameof(EventArgs.Scp079.CancelsDoorLockdownEventArgs)))
			},
			{
				ServerEventType.Scp079BlackoutZone, new Event(
					new EventParameter(typeof(EventArgs.Scp079.BlackoutZoneEventArgs), nameof(EventArgs.Scp079.BlackoutZoneEventArgs)))
			},
			{
				ServerEventType.Scp079BlackoutRoom, new Event(
					new EventParameter(typeof(EventArgs.Scp079.BlackoutRoomEventArgs), nameof(EventArgs.Scp079.BlackoutRoomEventArgs)))
			},
			{
				ServerEventType.Scp049ResurrectBody, new Event(
					new EventParameter(typeof(EventArgs.Scp049.ResurrectBodyEventArgs), nameof(EventArgs.Scp049.ResurrectBodyEventArgs)))
			},
			{
				ServerEventType.Scp049StartResurrectingBody, new Event(
					new EventParameter(typeof(EventArgs.Scp049.StartingResurrectionEventArgs), nameof(EventArgs.Scp049.StartingResurrectionEventArgs)))
			},
			{
				ServerEventType.PlayerInteractDoor, new Event(
					new EventParameter(typeof(EventArgs.Player.InteractingDoorEventArgs), nameof(EventArgs.Player.InteractingDoorEventArgs)))
			},
			{
				ServerEventType.BanIssued, new Event(
					new EventParameter(typeof(EventArgs.Server.BanIssuedEventArgs), nameof(EventArgs.Server.BanIssuedEventArgs)))
			},
			{
				ServerEventType.BanRevoked, new Event(
					new EventParameter(typeof(EventArgs.Server.BanRevokedEventArgs), nameof(EventArgs.Server.BanRevokedEventArgs)))
			},
			{
				ServerEventType.RemoteAdminCommandExecuted, new Event(
					new EventParameter(typeof(EventArgs.Player.FinishExecutingRaCommandEventArgs), nameof(EventArgs.Player.FinishExecutingRaCommandEventArgs)))
			},
			{
				ServerEventType.PlayerGameConsoleCommandExecuted, new Event(
					new EventParameter(typeof(EventArgs.Player.FinishExecutingGameConsoleCommandEventArgs), nameof(EventArgs.Player.FinishExecutingGameConsoleCommandEventArgs)))
			},
			{
				ServerEventType.ConsoleCommandExecuted, new Event(
					new EventParameter(typeof(EventArgs.Server.FinishExecutingConsoleCommand), nameof(EventArgs.Server.FinishExecutingConsoleCommand)))
			},
			{
				ServerEventType.BanUpdated, new Event(
					new EventParameter(typeof(EventArgs.Server.UpdatingBanEventArgs), nameof(EventArgs.Server.UpdatingBanEventArgs)))
			},
			{
				ServerEventType.PlayerPreCoinFlip, new Event(
					new EventParameter(typeof(EventArgs.Player.FlippingCoinEventArgs), nameof(EventArgs.Player.FlippingCoinEventArgs)))
			},
			{
				ServerEventType.PlayerCoinFlip, new Event(
					new EventParameter(typeof(EventArgs.Player.FlippedCoinEventArgs), nameof(EventArgs.Player.FlippedCoinEventArgs)))
			},
			{
				ServerEventType.PlayerInteractGenerator, new Event(
					new EventParameter(typeof(EventArgs.Player.InteractingGeneratorEventArgs), nameof(EventArgs.Player.InteractingGeneratorEventArgs)))
			},
			{
				ServerEventType.RoundEndConditionsCheck, new Event(
					new EventParameter(typeof(EventArgs.Server.CheckingRoundEndConditionsEventArgs), nameof(EventArgs.Server.CheckingRoundEndConditionsEventArgs)))
			},
			{
				ServerEventType.Scp914PickupUpgraded, new Event(
					new EventParameter(typeof(EventArgs.Scp914.UpgradedPickupEventArgs), nameof(EventArgs.Scp914.UpgradedPickupEventArgs)))
			},
			{
				ServerEventType.Scp914InventoryItemUpgraded, new Event(
					new EventParameter(typeof(EventArgs.Scp914.UpgradedInventoryItemEventArgs), nameof(EventArgs.Scp914.UpgradedInventoryItemEventArgs)))
			},
			{
				ServerEventType.Scp914ProcessPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp914.ProcessingPlayerEventArgs), nameof(EventArgs.Scp914.ProcessingPlayerEventArgs)))
			},
			{
				ServerEventType.Scp079CameraChanged, new Event(
					new EventParameter(typeof(EventArgs.Scp079.ChangingCameraEventArgs), nameof(EventArgs.Scp079.ChangingCameraEventArgs)))
			},
			{
				ServerEventType.Scp096AddingTarget, new Event(
					new EventParameter(typeof(EventArgs.Scp096.AddingTargetEventArg), nameof(EventArgs.Scp096.AddingTargetEventArg)))
			},
			{
				ServerEventType.Scp096Enraging, new Event(
					new EventParameter(typeof(EventArgs.Scp096.EnragingEventArgs), nameof(EventArgs.Scp096.EnragingEventArgs)))
			},
			{
				ServerEventType.Scp096ChangeState, new Event(
					new EventParameter(typeof(EventArgs.Scp096.ChangeStateEventArgs), nameof(EventArgs.Scp096.ChangeStateEventArgs)))
			},
			{
				ServerEventType.Scp096Charging, new Event(
					new EventParameter(typeof(EventArgs.Scp096.ChargingEventArgs), nameof(EventArgs.Scp096.ChargingEventArgs)))
			},
			{
				ServerEventType.Scp096PryingGate, new Event(
					new EventParameter(typeof(EventArgs.Scp096.PryingGateEventArgs), nameof(EventArgs.Scp096.PryingGateEventArgs)))
			},
			{
				ServerEventType.Scp096TryNotCry, new Event(
					new EventParameter(typeof(EventArgs.Scp096.TryNotCryEventArg), nameof(EventArgs.Scp096.TryNotCryEventArg)))
			},
			{
				ServerEventType.Scp096StartCrying, new Event(
					new EventParameter(typeof(EventArgs.Scp096.StartCryingEventArgs), nameof(EventArgs.Scp096.StartCryingEventArgs)))
			},
			{
				ServerEventType.PlayerUsingRadio, new Event(
					new EventParameter(typeof(EventArgs.Player.UsingRadioBatteryEventArgs), nameof(EventArgs.Player.UsingRadioBatteryEventArgs)))
			},
			{
				ServerEventType.CassieAnnouncesScpTermination, new Event(
					new EventParameter(typeof(EventArgs.Map.AnnouncingScpTerminationEventArgs), nameof(EventArgs.Map.AnnouncingScpTerminationEventArgs)))
			},
			{
				ServerEventType.PlayerGetGroup, new Event(
					new EventParameter(typeof(EventArgs.Player.GettingGroupEventArgs), nameof(EventArgs.Player.GettingGroupEventArgs)))
			},
			{
				ServerEventType.PlayerUsingIntercom, new Event(
					new EventParameter(typeof(EventArgs.Player.UsingIntercomEventArgs), nameof(EventArgs.Player.UsingIntercomEventArgs)))
			},
			{
				ServerEventType.PlayerDeath, new Event(
					new EventParameter(typeof(EventArgs.Player.DiedEventArgs), nameof(EventArgs.Player.DiedEventArgs)))
			},
			{
				ServerEventType.PlayerRadioToggle, new Event(
					new EventParameter(typeof(EventArgs.Player.ToggledRadioEventArgs), nameof(EventArgs.Player.ToggledRadioEventArgs)))
			},
			{
				ServerEventType.Scp0492ConsumedCorpse, new Event(
					new EventParameter(typeof(EventArgs.Scp0492.ConsumeCorpseEventArgs), nameof(EventArgs.Scp0492.ConsumeCorpseEventArgs)))
			},
			{
				ServerEventType.Scp106UsingHunterAtlas, new Event(
					new EventParameter(typeof(EventArgs.Scp106.TeleportingEventArgs), nameof(EventArgs.Scp106.TeleportingEventArgs)))
			},
			{
				ServerEventType.Scp096SlapPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp096.SlapPlayerEventArgs), nameof(EventArgs.Scp096.SlapPlayerEventArgs)))
			},
			{
				ServerEventType.Scp079Pining, new Event(
					new EventParameter(typeof(EventArgs.Scp079.PiningEventArgs), nameof(EventArgs.Scp079.PiningEventArgs)))
			},
			{
				ServerEventType.Scp049CallProgeny, new Event(
					new EventParameter(typeof(EventArgs.Scp049.CallProgenyEventArgs), nameof(EventArgs.Scp049.CallProgenyEventArgs)))
			},
			{
				ServerEventType.Scp049FailsMarkPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp049.FailsMarkingTargetEventArgs), nameof(EventArgs.Scp049.FailsMarkingTargetEventArgs)))
			},
			{
				ServerEventType.Scp049KillMarkedPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp049.KillMarkedPlayerEventArgs), nameof(EventArgs.Scp049.KillMarkedPlayerEventArgs)))
			},
			{
				ServerEventType.Scp049LosingMarkedPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp049.LoseMarkEventArgs), nameof(EventArgs.Scp049.LoseMarkEventArgs)))
			},
			{
				ServerEventType.Scp049MarkingPlayer, new Event(
					new EventParameter(typeof(EventArgs.Scp049.KillMarkedPlayerEventArgs), nameof(EventArgs.Scp049.KillMarkedPlayerEventArgs)))
			}
		};

		private static bool ValidateEvent(Type[] parameters, Type[] requiredParameters)
		{
			if (parameters.Length != requiredParameters.Length)
				return false;

			for (int x = 0; x < requiredParameters.Length; x++)
			{
				if (requiredParameters[x].IsInterface)
				{
					if (!requiredParameters[x].IsAssignableFrom(parameters[x]))
						return false;
				}
				else if (requiredParameters[x] != parameters[x])
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Registers all events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterAllEvents(object plugin)
		{
			Type pluginType = plugin.GetType();

			if (!AssemblyLoader.PluginToAssembly.TryGetValue(plugin, out Assembly assembly)) return;

			foreach (var type in assembly.GetTypes().Where(x => x.IsClass))
			{
				bool foundEvents = false;
				foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
				{
					foreach (var attribute in method.GetCustomAttributes<Attribute>())
					{
						switch (attribute)
						{
							case PluginEvent _:
								foundEvents = true;
								break;
						}
					}
				}

				if (foundEvents)
				{
					if (!EventHandlers.TryGetValue(type, out object handler))
					{
						handler = Activator.CreateInstance(type);
						EventHandlers.Add(type, handler);
					}

					RegisterEvents(plugin, handler);
				}
			}
		}

		/// <summary>
		/// Registers all events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void UnregisterAllEvents(object plugin)
		{
			Type pluginType = plugin.GetType();

			foreach (var handler in Events
				         .SelectMany(x =>
					         x.Value.Invokers.Where(y => y.Key == pluginType))
				         .SelectMany(x =>
					         x.Value.Select(y => y.Target))
				         .Distinct())
			{
				UnregisterEvents(pluginType, handler);
			}
		}

		/// <summary>
		/// Registers events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterEvents(object plugin)
		{
			Type type = plugin.GetType();
			RegisterEvents(type, plugin);
		}

		/// <summary>
		/// Unregisters events in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void UnregisterEvents(object plugin)
		{
			Type type = plugin.GetType();
			UnregisterEvents(type, plugin);
		}

		/// <summary>
		/// Registers events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterEvents<T>(object plugin) where T : class
		{
			if (!EventHandlers.TryGetValue(typeof(T), out object handler))
			{
				handler = Activator.CreateInstance(typeof(T));
				EventHandlers.Add(typeof(T), handler);
			}

			RegisterEvents(plugin.GetType(), handler);
		}

		/// <summary>
		/// Unregisters events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void UnregisterEvents<T>(object plugin) where T : class
		{
			if (!EventHandlers.TryGetValue(typeof(T), out object handler)) return;

			UnregisterEvents(plugin.GetType(), handler);
		}

		/// <summary>
		/// Registers events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		public static void RegisterEvents(object plugin, object eventHandler) => RegisterEvents(plugin.GetType(), eventHandler);

		/// <summary>
		/// Unregisters events in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		public static void UnregisterEvents(object plugin, object eventHandler) => UnregisterEvents(plugin.GetType(), eventHandler);


		/// <summary>
		/// Registers events in plugin.
		/// </summary>>
		/// <param name="plugin">Object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		static void RegisterEvents(Type plugin, object eventHandler)
		{
			foreach (var method in eventHandler.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				foreach (var attribute in method.GetCustomAttributes<Attribute>())
				{
					switch (attribute)
					{
						case PluginEvent pluginEvent:

							if (!Events.TryGetValue(pluginEvent.EventType, out Event ev))
							{
								Log.Error($"Event &6{pluginEvent.EventType}&r is not registered in manager! ( create issue on github )");
								continue;
							}

							var eventParameters = method.GetParameters().Select(p => p.ParameterType).ToArray();

							if (!ValidateEvent(eventParameters, ev.Parameters.Select(x => x.BaseType).ToArray()))
							{
								Log.Error($"Event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r contains wrong parameters\n - &6{(string.Join(", ", eventParameters.Select(p => p.Name)))}\n - Required:\n - &6{(string.Join(", ", ev.Parameters.Select(p => p.BaseType.Name)))}.");
								continue;
							}

							ev.RegisterInvoker(plugin, eventHandler, method);

							Log.Debug($"Registered event &6{method.Name}&r (&6{pluginEvent.EventType}&r) in plugin &6{plugin.FullName}&r!", Log.DebugMode);
							break;
					}
				}
			}
		}

		/// <summary>
		/// Unregisters events in plugin.
		/// </summary>>
		/// <param name="plugin">Object of plugin.</param>
		/// <param name="eventHandler">The event handler.</param>
		static void UnregisterEvents(Type plugin, object eventHandler)
		{
			foreach (var ev in Events)
			{
				foreach (var invoker in ev.Value.Invokers)
				{
					foreach (var location in invoker.Value.ToArray())
					{
						if (location.Target != eventHandler) continue;

						invoker.Value.Remove(location);
						Log.Debug($"Unregistered event &6{location.Method.Name}&r (&6{ev.Key}&r) in plugin &6{plugin.FullName}&r!", Log.DebugMode);
					}
				}
			}
		}

		internal static PlayerFactory GetPlayerFactory(EventInvokeLocation ev)
		{
			if (!FactoryManager.PlayerFactories.TryGetValue(ev.Plugin, out PlayerFactory pFactory))
				pFactory = FactoryManager.PlayerFactories[typeof(EventManager)];

			return pFactory;
		}

		/// <summary>
		/// Executes event.
		/// </summary>
		/// <param name="type">The type of event</param>
		/// <param name="args">The arguments of event.</param>
		/// <returns>If false event is cancelled.</returns>
		public static bool ExecuteEvent(ServerEventType type, params object[] args) => ExecuteEvent<bool>(type, args);

		/// <summary>
		/// Executes event.
		/// </summary>
		/// <param name="type">The type of event</param>
		/// <param name="args">The arguments of event.</param>
		/// <returns>Event cancellation data.</returns>
		// ReSharper disable once MemberCanBePrivate.Global
		public static T ExecuteEvent<T>(ServerEventType type, params object[] args) where T : struct
		{
			if (!Events.TryGetValue(type, out Event ev))
			{
				Log.Error($"Event &6{type}&r is not registered in manager! ( create issue on github )");
				return default;
			}

			bool isBool = typeof(T) == typeof(bool);
			bool cancelled = false;

			T cancellation;

			if (isBool)
			{
				cancellation = (T)(object)true;
			}
			else cancellation = default;


			foreach (var plugin in ev.Invokers.Values)
			{
				foreach (var invoker in plugin)
				{
					object result;
					try
					{
						result = invoker.Invoke(ev.RegenerateParameters(invoker, args));
					}
					catch (Exception ex)
					{
						Log.Error($"Failed executing event &6{invoker.Method.Name}&r (&6{type}&r) in plugin &6{invoker.Plugin.FullName}&r\n{ex}");
						continue;
					}

					if (cancelled || result is null)
						continue;

					if (isBool)
					{
						if (result is bool b && b)
							continue;

						cancellation = (T)result;
						cancelled = true;
					}
					else if (result is T r)
					{
						if (!(r is IEventCancellation ecd) || !ecd.IsCancelled)
							continue;

						cancellation = r;
						cancelled = true;
					}
					else
					{
						Log.Error($"Plugin &6{invoker.Plugin.FullName}&r passed invalid data type for event &6{invoker.Method.Name}&r.");
					}
				}
			}

			return cancellation;
		}
	}
}
