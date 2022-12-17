namespace TemplatePlugin
{
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
	using TemplatePlugin.Factory;
	using UnityEngine;

	public class EventHandlers
	{
		[PluginEvent(ServerEventType.WarheadStart)]
		public void OnWarheadStart(bool isAutomatic, MyPlayer player)
		{
			if (player == null)
				Log.Info($"Warhead detonation started ( isAutomatic: {(isAutomatic ? "yes" : "no")} )");
			else
				Log.Info($"Warhead detonation started by &6{player.Nickname}&r (&6{player.UserId}&r)");
		}

		[PluginEvent(ServerEventType.WarheadStop)]
		public void OnWarheadStop(MyPlayer player)
		{
			if (player == null)
				Log.Info($"Warhead detonation stopped");
			else
				Log.Info($"Warhead detonation stopped by &6{player.Nickname}&r (&6{player.UserId}&r)");
		}

		[PluginEvent(ServerEventType.WarheadDetonation)]
		public void OnWarheadDetonation()
		{
			Log.Info($"Warhead detonated");
		}

		[PluginEvent(ServerEventType.PlayerMuted)]
		public void OnPlayerMuted(MyPlayer player, bool isIntercom)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) muted ( isIntercom: {(isIntercom ? "yes" : "no")} )");
		}

		[PluginEvent(ServerEventType.PlayerUnmuted)]
		public void OnPlayerUnmuted(MyPlayer player, bool isIntercom)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) unmuted ( isIntercom: {(isIntercom ? "yes" : "no")} )");
		}

		[PluginEvent(ServerEventType.PlayerCheckReservedSlot)]
		public void OnCheckReservedSlot(string userid, bool hasReservedSlot)
		{
			Log.Info($"Player &6{userid}&r {(hasReservedSlot ? "has reserved slot" : "dont have reserved slot")}");
		}

		[PluginEvent(ServerEventType.PlayerRemoteAdminCommand)]
		public void OnPlayerRemoteadminCommand(MyPlayer player, string command, string[] arguments)
		{
			Log.Info($"&7[&1RemoteAdmin&7]&r Player &6{player.Nickname}&r (&6{player.UserId}&r) used command &6{command}&r{(arguments.Length != 0 ? $" with arguments &6{string.Join(", ", arguments)}&r" : string.Empty)}");
		}

		[PluginEvent(ServerEventType.PlayerGameConsoleCommand)]
		public void OnPlayerGameconsoleCommand(MyPlayer player, string command, string[] arguments)
		{
			Log.Info($"&7[&3GameConsole&7]&r Player &6{player.Nickname}&r (&6{player.UserId}&r) used command &6{command}&r{(arguments.Length != 0 ? $" with arguments &6{string.Join(", ", arguments)}&r" : string.Empty)}");
		}

		[PluginEvent(ServerEventType.ConsoleCommand)]
		public void OnConsoleCommand(string command, string[] arguments)
		{
			Log.Info($"&7[&2Console&7]&r Server used command &6{command}&r{(arguments.Length != 0 ? $" with arguments &6{string.Join(", ", arguments)}&r" : string.Empty)}");
		}

		[PluginEvent(ServerEventType.TeamRespawnSelected)]
		public void OnTeamSelected(SpawnableTeamType team)
		{
			Log.Info($"Next team which will spawn will be &6{team}&r");
		}

		[PluginEvent(ServerEventType.TeamRespawn)]
		public void OnRespawn(SpawnableTeamType team)
		{
			Log.Info($"Spawned team &6{team}&r");
		}

		[PluginEvent(ServerEventType.PlayerEnterPocketDimension)]
		public void OnPlayerEnterPocketDimension(MyPlayer player)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) entered pocked dimension");
		}

		[PluginEvent(ServerEventType.PlayerExitPocketDimension)]
		public void OnPlayerExitPocketDimension(MyPlayer player, bool isSuccsefull)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) {(isSuccsefull ? "escaped" : "died while escaping")} pocket dimension");
		}

		[PluginEvent(ServerEventType.PlayerThrowProjectile)]
		public void OnPlayerThrowProjectile(MyPlayer player, ThrowableItem item, float forceAmount, float upwardsFactor, Vector3 torque, Vector3 velocity)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) throws &2{item.ItemTypeId}&r with force &2{forceAmount}&r");
		}

		[PluginEvent(ServerEventType.PlayerInteractDoor)]
		public void OnPlayerInteractDoor(MyPlayer player, DoorVariant door, bool canOpen)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) {(canOpen ? door.TargetState ? "closed" : "opened" : "tried opening")} door");
		}

		[PluginEvent(ServerEventType.Scp914Activate)]
		public void OnScp914Activate(MyPlayer player)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) activated SCP-914");
		}

		[PluginEvent(ServerEventType.Scp914KnobChange)]
		public void OnScp914KnobChange(MyPlayer player)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) changed knob state of SCP-914 ");
		}

		[PluginEvent(ServerEventType.Scp914UpgradeInventory)]
		public void OnScp914UpgradeInventory(MyPlayer player, ItemBase item)
		{
			Log.Info($"Item &2{item.ItemTypeId}&r upgraded in inventory of &6{player.Nickname}&r (&6{player.UserId}&r) by SCP-914");
		}

		[PluginEvent(ServerEventType.Scp914UpgradePickup)]
		public void OnScp914UpgradePickup(ItemPickupBase item)
		{
			Log.Info($"SCP-914 upgraded pickup &2{item.Info.ItemId}&r!");
		}

		[PluginEvent(ServerEventType.Scp106Stalking)]
		public void OnScp106Stalking(MyPlayer player, bool activate)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) {(activate ? "started" : "stopped")} stalking as SCP-106");
		}

		[PluginEvent(ServerEventType.Scp173PlaySound)]
		public void OnScp173PlaySound(MyPlayer player, Scp173AudioPlayer.Scp173SoundId soundId)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-173 played sound &2{soundId}&r");
		}

		[PluginEvent(ServerEventType.Scp173BreakneckSpeeds)]
		public void OnScp173BreakneckSpeeds(MyPlayer player, bool activate)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) {(activate ? "started" : "stopped")} brekneck speeds as SCP-173");
		}

		[PluginEvent(ServerEventType.Scp173NewObserver)]
		public void OnScp173NewObserver(MyPlayer player, MyPlayer target)
		{
			//Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-173 sees new target &6{target.Nickname}&r (&6{target.UserId}&r)");
		}

		[PluginEvent(ServerEventType.Scp173SnapPlayer)]
		public void OnScp173SnapPlayer(MyPlayer player, MyPlayer target)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-173 killed &6{target.Nickname}&r (&6{target.UserId}&r) by snapping his neck");
		}

		[PluginEvent(ServerEventType.Scp173CreateTantrum)]
		public void OnScp173CreateTantrum(MyPlayer player)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-173 created tantrum!");
		}

		[PluginEvent(ServerEventType.Scp939CreateAmnesticCloud)]
		public void OnScp939CreateAmnesticCloud(MyPlayer player)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-939 created amnestic cloud!");
		}

		[PluginEvent(ServerEventType.Scp939Lunge)]
		public void OnScp939Lunge(MyPlayer player, Scp939LungeState state)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) lunge state is &2{state}&r playing as SCP-939!");
		}

		[PluginEvent(ServerEventType.Scp939Attack)]
		public void OnScp939Attack(MyPlayer player, IDestructible target)
		{
			if (!ReferenceHub.TryGetHubNetID(target.NetworkId, out ReferenceHub hub)) return;

			MyPlayer targetPlayer = Player.Get<MyPlayer>(hub);

			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-939 attacked &6{targetPlayer.Nickname}&r (&6{targetPlayer.UserId}&r)!");
		}

		[PluginEvent(ServerEventType.Scp079GainExperience)]
		public void OnScp079GainExperience(MyPlayer player, int amount, Scp079HudTranslation reason)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 gained &2{amount}&r experience by doing &2{reason}&r!");
		}

		[PluginEvent(ServerEventType.Scp079LevelUpTier)]
		public void OnScp079LevelUpTier(MyPlayer player, int tier)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 leveled up to tier &2{tier}&r!");
		}

		[PluginEvent(ServerEventType.Scp079UseTesla)]
		public void OnScp079UseTesla(MyPlayer player, TeslaGate tesla)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 used tesla at &2{tesla.transform.position}&r!");
		}

		[PluginEvent(ServerEventType.Scp079LockdownRoom)]
		public void OnScp079LockdownRoom(MyPlayer player, RoomIdentifier room)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 locked down room &2{room.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079CancelRoomLockdown)]
		public void OnScp079CancelRoomLockdown(MyPlayer player, RoomIdentifier room)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 cancelled locked down in room &2{room.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079LockDoor)]
		public void OnScp079LockDoor(MyPlayer player, DoorVariant door)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 locked door &2{door.name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079UnlockDoor)]
		public void OnScp079UnLockDoor(MyPlayer player, DoorVariant door)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 unlocked door &2{door.name}&r!");
		}

		[PluginEvent(ServerEventType.Scp079BlackoutZone)]
		public void OnScp079BlackoutZone(MyPlayer player, FacilityZone zone)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 enabled blackout in zone &2{zone}&r!");
		}

		[PluginEvent(ServerEventType.Scp079BlackoutRoom)]
		public void OnScp079BlackoutRoom(MyPlayer player, RoomIdentifier room)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-079 enabled blackout in room &2{room.Name}&r!");
		}

		[PluginEvent(ServerEventType.Scp049ResurrectBody)]
		public void OnScp049ResurrectBody(MyPlayer player, MyPlayer target, BasicRagdoll body)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-049 resurrected body of &6{target.Nickname}&r (&6{target.UserId}&r), ragdoll with class &2{body.Info.RoleType}&r!");
		}

		[PluginEvent(ServerEventType.Scp049StartResurrectingBody)]
		public void OnScp049StartResurrectingBody(MyPlayer player, MyPlayer target, BasicRagdoll body, bool canResurrect)
		{
			//Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) playing as SCP-049 tried resurrecting body of &6{target.Nickname}&r (&6{target.UserId}&r), ragdoll with class &2{body.Info.RoleType}&r but it {(canResurrect ? "failed" : "succeded")}!");
		}

		[PluginEvent(ServerEventType.Scp106TeleportPlayer)]
		public void OnScp106TeleportPlayer(MyPlayer player, MyPlayer target)
		{
			Log.Info($"Player &6{player.Nickname}&r (&6{player.UserId}&r) teleported player &6{target.Nickname}&r (&6{target.UserId}&r) to pocket dimension as SCP-106");
		}

		[PluginEvent(ServerEventType.BanIssued)]
		public void OnBanIssued(BanDetails banDetails, BanHandler.BanType banType)
		{
			Log.Info($"ID {banDetails.Id} of type {banType} has been banned by {banDetails.Issuer}.");
		}

		[PluginEvent(ServerEventType.BanRevoked)]
		public void OnBanRevoked(string id, BanHandler.BanType banType)
		{
			Log.Info($"ID {id} of type {banType} has been unbanned.");
		}

		[PluginEvent(ServerEventType.BanUpdated)]
		public void OnBanUpdated(BanDetails banDetails, BanHandler.BanType banType)
		{
			Log.Info($"Ban of ID {banDetails.Id} of type {banType} has been updated by {banDetails.Issuer}.");
		}

		[PluginEvent(ServerEventType.PlayerRemoteAdminCommandExecuted)]
		public void OnPlayerRemoteadminCommandExecuted(MyPlayer player, string command, string[] arguments, bool result, string response)
		{
			Log.Info($"&7[&1RemoteAdmin&7]&r Player &6{player.Nickname}&r (&6{player.UserId}&r) used command &6{command}&r{(arguments.Length != 0 ? $" with arguments &6{string.Join(", ", arguments)}&r" : string.Empty)}. Result: {result}. Command output: {response}.");
		}

		[PluginEvent(ServerEventType.PlayerGameConsoleCommandExecuted)]
		public void OnPlayerGameconsoleCommandExecuted(MyPlayer player, string command, string[] arguments, string response)
		{
			Log.Info($"&7[&3GameConsole&7]&r Player &6{player.Nickname}&r (&6{player.UserId}&r) used command &6{command}&r{(arguments.Length != 0 ? $" with arguments &6{string.Join(", ", arguments)}&r" : string.Empty)}. Command output: {response}.");
		}

		[PluginEvent(ServerEventType.ConsoleCommandExecuted)]
		public void OnConsoleCommandExecuted(string command, string[] arguments, bool result, string response)
		{
			Log.Info($"&7[&2Console&7]&r Server used command &6{command}&r{(arguments.Length != 0 ? $" with arguments &6{string.Join(", ", arguments)}&r" : string.Empty)}. Result: {result}. Command output: {response}.");
		}
	}
}
