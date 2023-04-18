using Interactables.Interobjects;
﻿using MapGeneration.Distributors;
using PlayerRoles.PlayableScps.Scp079.Cameras;
using PlayerRoles.PlayableScps.Scp096;
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
	using PluginAPI.Events;

	public class EventHandlers
	{
		[PluginEvent]
		public void OnWarheadStart(WarheadStartEvent ev)
		{
			if (ev.Player == null)
				Log.Info($"Warhead detonation started (isAutomatic: {(ev.IsAutomatic ? "yes" : "no")}, isResumed: {(ev.IsResumed ? "yes" : "no")}).");
			else
				Log.Info($"Warhead detonation started by &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) (isResumed: {(ev.IsResumed ? "yes" : "no")}).");
		}

		[PluginEvent]
		public void OnWarheadStop(WarheadStopEvent ev)
		{
			if (ev.Player == null)
				Log.Info($"Warhead detonation stopped");
			else
				Log.Info($"Warhead detonation stopped by &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r)");
		}

		[PluginEvent]
		public void OnWarheadDetonation(WarheadDetonationEvent ev)
		{
			Log.Info($"Warhead detonated");
		}

		[PluginEvent]
		public void OnPlayerMuted(PlayerMutedEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) muted ( isIntercom: {(ev.IsIntercom ? "yes" : "no")} )");
		}

		[PluginEvent]
		public void OnPlayerUnmuted(PlayerUnmutedEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) unmuted ( isIntercom: {(ev.IsIntercom ? "yes" : "no")} )");
		}

		[PluginEvent]
		public void OnCheckReservedSlot(PlayerCheckReservedSlotEvent ev)
		{
			Log.Info($"Player &6{ev.Userid}&r {(ev.HasReservedSlot ? "has reserved slot" : "dont have reserved slot")}");
		}

		[PluginEvent]
		public void OnRemoteadminCommand(RemoteAdminCommandEvent ev)
		{
			Log.Info($"&7[&1RemoteAdmin&7]&r &6{ev.Sender.LogName}&r used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}");
		}

		[PluginEvent]
		public void OnPlayerGameconsoleCommand(PlayerGameConsoleCommandEvent ev)
		{
			Log.Info($"&7[&3GameConsole&7]&r Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}");
		}

		[PluginEvent]
		public void OnConsoleCommand(ConsoleCommandEvent ev)
		{
			Log.Info($"&7[&2Console&7]&r Server used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}");
		}

		[PluginEvent]
		public void OnTeamSelected(TeamRespawnSelectedEvent ev)
		{
			Log.Info($"Next team which will spawn will be &6{ev.Team}&r");
		}

		[PluginEvent]
		public void OnRespawn(TeamRespawnEvent ev)
		{
			Log.Info($"Spawned team &6{ev.Team}&r");
		}

		[PluginEvent]
		public void OnPlayerEnterPocketDimension(PlayerEnterPocketDimensionEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) entered pocked dimension");
		}

		[PluginEvent]
		public void OnPlayerExitPocketDimension(PlayerExitPocketDimensionEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.IsSuccessful ? "escaped" : "died while escaping")} pocket dimension");
		}

		[PluginEvent]
		public void OnPlayerThrowProjectile(PlayerThrowProjectileEvent ev)
		{
			Log.Info($"Player &6{ev.Thrower.Nickname}&r (&6{ev.Thrower.UserId}&r) throws &2{ev.Item.ItemTypeId}&r with force &2{ev.ProjectileSettings.StartVelocity}&r");
		}

		[PluginEvent]
		public void OnPlayerInteractDoor(PlayerInteractDoorEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.CanOpen ? ev.Door.TargetState ? "closed" : "opened" : "tried opening")} door");
		}

		[PluginEvent]
		public void OnScp914Activate(Scp914ActivateEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) activated SCP-914 with the knob setting at &6{ev.KnobSetting}&r");
		}

		[PluginEvent]
		public void OnScp914KnobChange(Scp914KnobChangeEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed knob state of SCP-914 from &6{ev.PreviousKnobSetting}&r to &6{ev.KnobSetting}&r");
		}

		[PluginEvent]
		public void OnScp914UpgradeInventory(Scp914UpgradeInventoryEvent ev)
		{
			Log.Info($"Item &2{ev.Item.ItemTypeId}&r upgraded in inventory of &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) by SCP-914");
		}

		[PluginEvent]
		public void OnScp914UpgradePickup(Scp914UpgradePickupEvent ev)
		{
			Log.Info($"SCP-914 upgraded pickup &2{ev.Item.Info.ItemId}&r and it is at the exit in the position {ev.OutputPosition}");
		}

		[PluginEvent]
		public void OnScp106Stalking(Scp106StalkingEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.Activated ? "started" : "stopped")} stalking as SCP-106");
		}

		[PluginEvent]
		public void OnScp173PlaySound(Scp173PlaySoundEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 played sound &2{ev.SoundId}&r");
		}

		[PluginEvent]
		public void OnScp173BreakneckSpeeds(Scp173BreakneckSpeedsEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) {(ev.Activate ? "started" : "stopped")} brekneck speeds as SCP-173");
		}

		[PluginEvent]
		public void OnScp173NewObserver(Scp173NewObserverEvent ev)
		{
			if (ev.Player.RoleBase is Scp173Role scp173)
			{
				scp173.SubroutineModule.TryGetSubroutine(out Scp173ObserversTracker tracker);

				if (!tracker.Observers.Contains(ev.Target.ReferenceHub))
					Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 sees new target &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r)");
			}
		}

		[PluginEvent]
		public void OnScp173SnapPlayer(Scp173SnapPlayerEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 killed &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) by snapping his neck");
		}

		[PluginEvent]
		public void OnScp173CreateTantrum(Scp173CreateTantrumEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-173 created tantrum!");
		}

		[PluginEvent]
		public void OnScp939CreateAmnesticCloud(Scp939CreateAmnesticCloudEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-939 created amnestic cloud!");
		}

		[PluginEvent]
		public void OnScp939Lunge(Scp939LungeEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) lunge state is &2{ev.State}&r playing as SCP-939!");
		}

		[PluginEvent]
		public void OnScp939Attack(Scp939AttackEvent ev)
		{
			if (!ReferenceHub.TryGetHubNetID(ev.Target.NetworkId, out ReferenceHub hub)) return;

			MyPlayer targetPlayer = Player.Get<MyPlayer>(hub);

			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-939 attacked &6{targetPlayer.Nickname}&r (&6{targetPlayer.UserId}&r)!");
		}

		[PluginEvent]
		public void OnScp079GainExperience(Scp079GainExperienceEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 gained &2{ev.Amount}&r experience by doing &2{ev.Reason}&r!");
		}

		[PluginEvent]
		public void OnScp079LevelUpTier(Scp079LevelUpTierEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 leveled up to tier &2{ev.Tier}&r!");
		}

		[PluginEvent]
		public void OnScp079UseTesla(Scp079UseTeslaEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 used tesla at &2{ev.Tesla.transform.position}&r!");
		}

		[PluginEvent]
		public void OnScp079LockdownRoom(Scp079LockdownRoomEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 locked down room &2{ev.Room.Name}&r!");
		}

		[PluginEvent]
		public void OnScp079CancelRoomLockdown(Scp079CancelRoomLockdownEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 cancelled locked down in room &2{ev.Room.Name}&r!");
		}

		[PluginEvent]
		public void OnScp079LockDoor(Scp079LockDoorEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 locked door &2{ev.Door.name}&r!");
		}

		[PluginEvent]
		public void OnScp079UnLockDoor(Scp079UnlockDoorEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 unlocked door &2{ev.Door.name}&r!");
		}

		[PluginEvent]
		public void OnScp079BlackoutZone(Scp079BlackoutZoneEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 enabled blackout in zone &2{ev.Zone}&r!");
		}

		[PluginEvent]
		public void OnScp079BlackoutRoom(Scp079BlackoutRoomEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 enabled blackout in room &2{ev.Room.Name}&r!");
		}

		[PluginEvent]
		public void OnScp049ResurrectBody(Scp049ResurrectBodyEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 resurrected body of &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r), ragdoll with class &2{ev.Body.Info.RoleType}&r!");
		}

		[PluginEvent]
		public void OnScp079ChangedCamera(Scp079CameraChangedEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-079 changes camera");
		}

		[PluginEvent]
		public void OnScp049StartResurrectingBody(Scp049StartResurrectingBodyEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) playing as SCP-049 tried resurrecting body of &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r), ragdoll with class &2{ev.Body.Info.RoleType}&r but it {(ev.CanResurrct ? "failed" : "succeded")}!");
		}

		[PluginEvent]
		public void OnScp106TeleportPlayer(Scp106TeleportPlayerEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) teleported player &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) to pocket dimension as SCP-106");
		}

		[PluginEvent]
		public void OnScp096AddTarget(Scp096AddingTargetEvent ev)
		{
			Log.Info($"Player &6{ev.Target.Nickname}&r (&6{ev.Target.UserId}&r) {(ev.IsForLook ? "look" : "shoot")}  player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) and was added to the SCP-096 target list");
		}

		[PluginEvent]
		public void OnScp096Enrage(Scp096EnragingEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) went into a state of rage for {ev.InitialDuration} seconds");
		}

		[PluginEvent]
		public void OnScp096CalmDown(Scp096ChangeStateEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) changed its state to {ev.RageState} as SCP-096");
		}

		[PluginEvent]
		public void OnScp096Charge(Scp096ChargingEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) uses its charging ability as SCP-096");
		}

		[PluginEvent]
		public void OnScp096PryGate(Scp096PryingGateEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) breached the gate {ev.GateDoor.name}");
		}

		[PluginEvent]
		public void OnScp096TryingNotCry(Scp096TryNotCryEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) is trying not to cry");
		}

		[PluginEvent]
		public void OnScp096StartCrying(Scp096StartCryingEvent ev)
		{
			Log.Info($"Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) cancel his TryToNotCry ability");
		}

		[PluginEvent]
		public void OnBanIssued(BanIssuedEvent ev)
		{
			Log.Info($"ID {ev.BanDetails.Id} of type {ev.BanType} has been banned by {ev.BanDetails.Issuer}.");
		}

		[PluginEvent]
		public void OnBanRevoked(BanRevokedEvent ev)
		{
			Log.Info($"ID {ev.Id} of type {ev.BanType} has been unbanned.");
		}

		[PluginEvent]
		public void OnBanUpdated(BanUpdatedEvent ev)
		{
			Log.Info($"Ban of ID {ev.BanDetails.Id} of type {ev.BanType} has been updated by {ev.BanDetails.Issuer}.");
		}

		[PluginEvent]
		public void OnRemoteadminCommandExecuted(RemoteAdminCommandExecutedEvent ev)
		{
			Log.Info($"&7[&1RemoteAdmin&7]&r &6{ev.Sender.LogName}&r used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}. Result: {ev.Result}. Command output: {ev.Response}.");
		}

		[PluginEvent]
		public void OnPlayerGameconsoleCommandExecuted(PlayerGameConsoleCommandExecutedEvent ev)
		{
			Log.Info($"&7[&3GameConsole&7]&r Player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}. Command output: {ev.Response}.");
		}

		[PluginEvent]
		public void OnConsoleCommandExecuted(ConsoleCommandExecutedEvent ev)
		{
			Log.Info($"&7[&2Console&7]&r Server used command &6{ev.Command}&r{(ev.Arguments.Length != 0 ? $" with arguments &6{string.Join(", ", ev.Arguments)}&r" : string.Empty)}. Result: {ev.Result}. Command output: {ev.Response}.");
		}

		[PluginEvent]
		public PlayerPreCoinFlipCancellationData OnPlayerPreCoinFlip(PlayerPreCoinFlipEvent ev)
		{
			Log.Info($"&rPlayer &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) flipped the coin (PreCoinFlip event).");
			return PlayerPreCoinFlipCancellationData.LeaveUnchanged();
		}

		[PluginEvent]
		public void OnPlayerCoinFlip(PlayerCoinFlipEvent ev)
		{
			Log.Info($"&rPlayer &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) flipped the coin. Flip result: {(ev.IsTails ? "tails" : "heads")}.");
		}

		[PluginEvent]
		public void OnPlayerInteractGenerator(PlayerInteractGeneratorEvent ev)
		{
			Log.Info($"&rPlayer &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) interact with a generator in the position &2{ev.Generator.transform.position}&r");
		}

		[PluginEvent]
		public void OnRoundEndConditionsCheck(RoundEndConditionsCheckEvent ev)
		{
			Log.Info("&rRound end conditions are being checked.");
		}

		[PluginEvent]
		public void OnScp914PickupUpgraded(Scp914PickupUpgradedEvent ev)
		{
			Log.Info($"&rItem pickup with ItemID {ev.Item.Info.ItemId} has been upgraded in SCP 914.");
		}

		[PluginEvent]
		public void OnScp914InventoryItemUpgraded(Scp914InventoryItemUpgradedEvent ev)
		{
			Log.Info($"&rItem in inventory of player &6{ev.Player.Nickname}&r (&6{ev.Player.UserId}&r) with ItemID {ev.Item.ItemTypeId} has been upgraded in SCP 914.");
		}

		[PluginEvent]
		public void OnScp914ProcessPlayer(Scp914ProcessPlayerEvent ev)
		{
			Log.Info($"&rSCP-914 process &6{ev.Player.Nickname}&r with KnobSetting {ev.KnobSetting} and will exit in the {ev.OutPosition} position.");
		}
	}
}
