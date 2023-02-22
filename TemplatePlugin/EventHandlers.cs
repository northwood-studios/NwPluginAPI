using Interactables.Interobjects;
﻿using MapGeneration.Distributors;
using PlayerRoles.PlayableScps.Scp079.Cameras;
using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Events;
using PluginAPI.Events.EventArgs.Player;
using PluginAPI.Events.EventArgs.Scp049;
using PluginAPI.Events.EventArgs.Scp079;
using PluginAPI.Events.EventArgs.Scp096;
using PluginAPI.Events.EventArgs.Scp106;
using PluginAPI.Events.EventArgs.Scp173;
using PluginAPI.Events.EventArgs.Scp914;
using PluginAPI.Events.EventArgs.Scp939;
using PluginAPI.Events.EventArgs.Server;
using PluginAPI.Events.EventArgs.Warhead;
using Scp914;

namespace TemplatePlugin
{
	using CommandSystem;
	using Interactables.Interobjects.DoorUtils;
	using InventorySystem.Items;
	using InventorySystem.Items.Pickups;
	using InventorySystem.Items.ThrowableProjectiles;
	using MapGeneration;
	using PlayerRoles.PlayableScps.Scp079;
	using PlayerRoles.PlayableScps.Scp173;
	using PlayerRoles.PlayableScps.Scp939;
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Enums;
	using Respawning;
	using Factory;
	using UnityEngine;

	public class EventHandlers
	{
		[PluginEvent(ServerEventType.WarheadStart)]
		public void OnWarheadStart(StartingEventArgs ev)
		{
			Log.Info(ev.Player == null
				? $"Warhead detonation started (isAutomatic: {(ev.IsAutomatic ? "yes" : "no")}, isResumed: {(ev.IsResumed ? "yes" : "no")})."
				: $"Warhead detonation started by &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) (isResumed: {(ev.IsResumed ? "yes" : "no")}).");
		}

		[PluginEvent(ServerEventType.WarheadStop)]
		public void OnWarheadStop(StoppingEventArgs ev)
		{
			Log.Info(ev.Player == null
				? $"Warhead detonation stopped"
				: $"Warhead detonation stopped by &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r)");
		}

		[PluginEvent(ServerEventType.WarheadDetonation)]
		public void OnWarheadDetonation()
		{
			Log.Info($"Warhead detonated");
		}

		[PluginEvent(ServerEventType.PlayerMuted)]
		public void OnPlayerMuted(MutedEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) muted ( isIntercom: {(ev.IsIntercomMute ? "yes" : "no")} )");
		}

		[PluginEvent(ServerEventType.PlayerUnmuted)]
		public void OnPlayerUnmuted(UnMuteEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) unmuted ( isIntercom: {(ev.IsIntercomMute ? "yes" : "no")} )");
		}

		[PluginEvent(ServerEventType.PlayerCheckReservedSlot)]
		public PlayerCheckReservedSlotCancellationData OnCheckReservedSlot(CheckingReservedSlotsEventArgs ev)
		{
			if (ev.UserId == "Carpincho")
				return PlayerCheckReservedSlotCancellationData.Override(false);

			Log.Info($"Player &6{ev.UserId}&r {(ev.HasReservedSlot ? "has reserved slot" : "dont have reserved slot")}");

			return PlayerCheckReservedSlotCancellationData.LeaveUnchanged();
		}

		[PluginEvent(ServerEventType.RemoteAdminCommand)]
		public void OnRemoteadminCommand(UsingRaCommandEventArgs ev)
		{
			// Please don't use this for creating commands.
			Log.Info($"&7[&1RemoteAdmin&7]&r &6{ev.Sender.LogName}&r used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}");
		}

		[PluginEvent(ServerEventType.PlayerGameConsoleCommand)]
		public void OnPlayerGameconsoleCommand(UsingGameConsoleCommand ev)
		{
			// Don't use this for creating commands.
			Log.Info($"&7[&3GameConsole&7]&r Player &6{ev.Sender.Nickname}&r (&6{ev.Sender.UserId}&r) used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}");
		}

		[PluginEvent(ServerEventType.ConsoleCommand)]
		public void OnConsoleCommand(UseConsoleCommandEventArgs ev)
		{
			Log.Info($"&7[&2Console&7]&r Server used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}");
		}

		[PluginEvent(ServerEventType.TeamRespawnSelected)]
		public void OnTeamSelected(TeamRespawnSelectedEventArgs ev)
		{
			Log.Info($"Next team which will spawn will be &6{ev.NextSpawnableTeam}&r");
		}

		[PluginEvent(ServerEventType.TeamRespawn)]
		public void OnRespawn(TeamRespawningEventArgs ev)
		{
			Log.Info($"Spawned team &6{ev.Team}&r");
		}

		[PluginEvent(ServerEventType.PlayerEnterPocketDimension)]
		public void OnPlayerEnterPocketDimension(EnteringPocketDimensionEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) entered pocked dimension");
		}

		[PluginEvent(ServerEventType.PlayerExitPocketDimension)]
		public void OnPlayerExitPocketDimension(TryEscapingPocketDimensionEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.IsSuccessful ? "escaped" : "died while escaping")} pocket dimension");
		}

		[PluginEvent(ServerEventType.PlayerThrowProjectile)]
		public void OnPlayerThrowProjectile(ThrowingProjectileEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) throws &2{ev.Item.ItemTypeId}&r with force &2{ev.ProjectileSettings.StartVelocity}&r");
		}

		[PluginEvent(ServerEventType.PlayerInteractDoor)]
		public void OnPlayerInteractDoor(InteractingDoorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.CanOpen ? ev.Door.IsOpened ? "closed" : "opened" : "tried opening")} door");
		}

		[PluginEvent(ServerEventType.Scp914Activate)]
		public void OnScp914Activate(ActivatingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) activated SCP-914 with the knob setting at &6{ev.KnobSetting}&r");
		}

		[PluginEvent(ServerEventType.Scp914KnobChange)]
		public void OnScp914KnobChange(ChangingKnobSettingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed knob state of SCP-914 from &6{ev.PreviousKnobSetting}&r to &6{ev.KnobSetting}&r");
		}

		[PluginEvent(ServerEventType.Scp914UpgradeInventory)]
		public void OnScp914UpgradeInventory(UpgradingInventoryItemEventArgs ev)
		{
			Log.Info($"Item &2{ev.Item.Type}&r upgraded in inventory of &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) by SCP-914");
		}

		[PluginEvent(ServerEventType.Scp914UpgradePickup)]
		public void OnScp914UpgradePickup(UpgradingPickupEventArgs ev)
		{
			Log.Info($"SCP-914 upgraded pickup &2{ev.Pickup.Info.ItemId}&r and it is at the exit in the position {ev.OutputPosition}");
		}

		[PluginEvent(ServerEventType.Scp173PlaySound)]
		public void OnScp173PlaySound(PlayingSoundEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 played sound &2{ev.SoundId}&r");
		}

		[PluginEvent(ServerEventType.Scp173BreakneckSpeeds)]
		public void OnScp173BreakneckSpeeds(UsingBreakneckSpeedsEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.IsActivated ? "started" : "stopped")} brekneck speeds as SCP-173");
		}

		[PluginEvent(ServerEventType.Scp173NewObserver)]
		public void OnScp173NewObserver(NewObserverEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 sees new target &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r)");
		}

		[PluginEvent(ServerEventType.Scp173SnapPlayer)]
		public void OnScp173SnapPlayer(SnapPlayerNeckEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 killed &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) by snapping his neck");
		}

		[PluginEvent(ServerEventType.Scp173CreateTantrum)]
		public void OnScp173CreateTantrum(PlacingTantrumEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 created tantrum!");
		}

		[PluginEvent(ServerEventType.Scp939CreateAmnesticCloud)]
		public void OnScp939CreateAmnesticCloud(CreatingAmnesticCloudEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-939 created amnestic cloud!");
		}

		[PluginEvent(ServerEventType.Scp939Lunge)]
		public void OnScp939Lunge(LungeEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) lunge state is &2{ev.LungeState}&r playing as SCP-939!");
		}

		[PluginEvent(ServerEventType.Scp939Attack)]
		public void OnScp939Attack(ScratchingEventArgs ev)
		{
			if (!ReferenceHub.TryGetHubNetID(ev.Target.NetworkId, out ReferenceHub hub)) return;

			MyPlayer targetPlayer = Player.Get<MyPlayer>(hub);

			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-939 attacked &6{targetPlayer.Nickname}&r (&6{targetPlayer.UserId}&r)!");
		}

		[PluginEvent(ServerEventType.Scp079GainExperience)]
		public void OnScp079GainExperience(GainExperienceEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 gained &2{ev.Amount}&r experience by doing &2{ev.Reason}&r!");
		}

		[PluginEvent(ServerEventType.Scp079LevelUpTier)]
		public void OnScp079LevelUpTier(GainLevelEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 leveled up to tier &2{ev.NewLevel}&r!");
		}

		[PluginEvent(ServerEventType.Scp079UseTesla)]
		public void OnScp079UseTesla(UsingTeslaEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 used tesla at &2{ev.Tesla.transform.position}&r!");
		}

		[PluginEvent(ServerEventType.Scp079LockdownRoom)]
		public void OnScp079LockdownRoom(LockingDownRoomEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 locked down room &2{ev.Room.Identifier.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079CancelRoomLockdown)]
		public void OnScp079CancelRoomLockdown(CancelsRoomLockdownEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 cancelled locked down in room &2{ev.Room.Identifier.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079LockDoor)]
		public void OnScp079LockDoor(LockingDownDoorEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 locked door &2{ev.Door.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079UnlockDoor)]
		public void OnScp079UnLockDoor(CancelsDoorLockdownEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 unlocked door &2{ev.Door.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079BlackoutZone)]
		public void OnScp079BlackoutZone(BlackoutZoneEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 enabled blackout in zone &2{ev.Zone}&r!");
		}

		[PluginEvent(ServerEventType.Scp079BlackoutRoom)]
		public void OnScp079BlackoutRoom(BlackoutRoomEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 enabled blackout in room &2{ev.Room.Identifier.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079CameraChanged)]
		public void OnScp079ChangedCamera(ChangingCameraEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 changes camera what is in the room {ev.Camera.Room.name}");
		}

		[PluginEvent(ServerEventType.Scp079Pining)]
		public void OnScp079Ping(PiningEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 is making a ping, ping type: {ev.PingType}");
		}

		[PluginEvent(ServerEventType.Scp049ResurrectBody)]
		public void OnScp049ResurrectBody(ResurrectBodyEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 resurrected body of &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r), ragdoll with class &2{ev.Ragdoll.Info.RoleType}&r!");
		}

		[PluginEvent(ServerEventType.Scp049StartResurrectingBody)]
		public void OnScp049StartResurrectingBody(StartingResurrectionEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 tried resurrecting body of &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r), ragdoll with class &2{ev.Ragdoll.Info.RoleType}&r but it {(ev.CanRevive ? "failed" : "succeded")}!");
		}

		[PluginEvent(ServerEventType.Scp049CallProgeny)]
		public void OnScp049CallProgeny(CallProgenyEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 is using his ability to call the zombies.");
		}

		[PluginEvent(ServerEventType.Scp049MarkingPlayer)]
		public void OnScp049MarksTarget(MarkingTargetEventArgs ev)
		{
			Log.Info(($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 marks a &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) with his ability"));
		}

		[PluginEvent(ServerEventType.Scp049LosingMarkedPlayer)]
		public void OnScp049LoseMarkedTarget(LoseMarkEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 lost his marked target");
		}

		[PluginEvent(ServerEventType.Scp049FailsMarkPlayer)]
		public void OnScp049FailsMarkingTarget(FailsMarkingTargetEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 fails to mark a target");
		}

		[PluginEvent(ServerEventType.Scp049KillMarkedPlayer)]
		public void OnScp049KillMarkedTarget(KillMarkedPlayerEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 killed its marked target, it was &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r)");
		}

		[PluginEvent(ServerEventType.Scp106TeleportPlayer)]
		public void OnScp106TeleportPlayer(KidnappingPlayerEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) teleported player &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) to pocket dimension as SCP-106");
		}

		[PluginEvent(ServerEventType.Scp106Stalking)]
		public void OnScp106Stalking(StalkingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.IsActivating ? "started" : "stopped")} stalking as SCP-106");
		}

		[PluginEvent(ServerEventType.Scp106UsingHunterAtlas)]
		public void OnScp106UseAtlas(TeleportingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing has SCP-106 is teleporting using his hunter atlas ability");
		}

		[PluginEvent(ServerEventType.Scp096AddingTarget)]
		public void OnScp096AddTarget(AddingTargetEventArg ev)
		{
			Log.Info($"Player &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) {(ev.IsForLook ? "look" : "shoot")}  player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) and was added to the SCP-096 target list");
		}

		[PluginEvent(ServerEventType.Scp096Enraging)]
		public void OnScp096Enrage(EnragingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) went into a state of rage for {ev.InitialDuration} seconds");
		}

		[PluginEvent(ServerEventType.Scp096ChangeState)]
		public void OnScp096CalmDown(ChangeStateEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed its state to {ev.RageState} as SCP-096");
		}

		[PluginEvent(ServerEventType.Scp096Charging)]
		public void OnScp096Charge(ChargingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) uses its charging ability as SCP-096");
		}

		[PluginEvent(ServerEventType.Scp096PryingGate)]
		public void OnScp096PryGate(PryingGateEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) breached the gate {ev.GateDoor.Name}");
		}

		[PluginEvent(ServerEventType.Scp096TryNotCry)]
		public void OnScp096TryingNotCry(TryNotCryEventArg ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is trying not to cry");
		}

		[PluginEvent(ServerEventType.Scp096StartCrying)]
		public void OnScp096StartCrying(StartCryingEventArgs ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) cancel his TryToNotCry ability");
		}

		[PluginEvent(ServerEventType.BanIssued)]
		public void OnBanIssued(BanIssuedEventArgs ev)
		{
			Log.Info($"ID {ev.BanDetails.Id} of type {ev.BanType} has been banned by {ev.BanDetails.Issuer}.");
		}

		[PluginEvent(ServerEventType.BanRevoked)]
		public void OnBanRevoked(BanRevokedEventArgs ev)
		{
			Log.Info($"ID {ev.UserId} of type {ev.BanType} has been unbanned.");
		}

		[PluginEvent(ServerEventType.BanUpdated)]
		public void OnBanUpdated(UpdatingBanEventArgs ev)
		{
			Log.Info($"Ban of ID {ev.BanDetails.Id} of type {ev.BanType} has been updated by {ev.BanDetails.Issuer}.");
		}

		[PluginEvent(ServerEventType.RemoteAdminCommandExecuted)]
		public void OnRemoteadminCommandExecuted(FinishExecutingRaCommandEventArgs ev)
		{
			Log.Info($"&7[&1RemoteAdmin&7]&r &6{ev.Sender.LogName}&r used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}. Result: {ev.Result}. Command output: {ev.Response}.");
		}

		[PluginEvent(ServerEventType.PlayerGameConsoleCommandExecuted)]
		public void OnPlayerGameconsoleCommandExecuted(FinishExecutingGameConsoleCommandEventArgs ev)
		{
			Log.Info($"&7[&3GameConsole&7]&r Player &6{ev.Sender.Nickname}&r (&6{ev.Sender.UserId}&r) used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}. Command output: {ev.Response}.");
		}

		[PluginEvent(ServerEventType.ConsoleCommandExecuted)]
		public void OnConsoleCommandExecuted(FinishExecutingConsoleCommand ev)
		{
			Log.Info($"&7[&2Console&7]&r Server used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}. Result: {ev.Result}. Command output: {ev.Response}.");
		}

		[PluginEvent(ServerEventType.PlayerPreCoinFlip)]
		public PlayerPreCoinFlipCancellationData OnPlayerPreCoinFlip(FlippingCoinEventArgs ev)
		{
			if(ev.Player.UserId == "capybara")
				return PlayerPreCoinFlipCancellationData.PreventFlip();

			Log.Info($"&rPlayer &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is flipping the coin.");

			return PlayerPreCoinFlipCancellationData.LeaveUnchanged();
		}

		[PluginEvent(ServerEventType.PlayerCoinFlip)]
		public void OnPlayerCoinFlip(FlippedCoinEventArgs ev)
		{
			Log.Info($"&rPlayer &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) flipped the coin. Flip result: {(ev.IsTails ? "tails" : "heads")}.");
		}

		[PluginEvent(ServerEventType.PlayerInteractGenerator)]
		public void OnPlayerInteractGenerator(InteractingGeneratorEventArgs ev)
		{
			Log.Info($"&rPlayer &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) interact with a generator in the position &2{ev.Generator.Position}&r");
		}

		[PluginEvent(ServerEventType.RoundEndConditionsCheck)]
		public void OnRoundEndConditionsCheck(CheckingRoundEndConditionsEventArgs ev)
		{
			Log.Info("&rRound end conditions are being checked.");
		}

		[PluginEvent(ServerEventType.Scp914PickupUpgraded)]
		public void OnScp914PickupUpgraded(UpgradedPickupEventArgs ev)
		{
			Log.Info($"&rItem pickup with ItemID {ev.Pickup.Info.ItemId} has been upgraded in SCP 914.");
		}

		[PluginEvent(ServerEventType.Scp914InventoryItemUpgraded)]
		public void OnScp914InventoryItemUpgraded(UpgradedInventoryItemEventArgs ev)
		{
			Log.Info($"&rItem in inventory of player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) with ItemID {ev.Item.Type} has been upgraded in SCP 914.");
		}

		[PluginEvent(ServerEventType.Scp914ProcessPlayer)]
		public void OnScp914ProcessPlayer(ProcessingPlayerEventArgs ev)
		{
			Log.Info($"&rSCP-914 process &6{ev.Player.Nickname}&r with KnobSetting {ev.KnobSetting} and will exit in the {ev.OutPosition} position.");
		}
	}
}
