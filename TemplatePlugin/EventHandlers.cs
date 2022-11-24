namespace TemplatePlugin
{
	using CommandSystem;
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Enums;
	using Respawning;
	using TemplatePlugin.Factory;

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
	}
}
