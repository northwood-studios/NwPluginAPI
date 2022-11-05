namespace TemplatePlugin
{
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Enums;

	public class EventHandlers
	{
		[PluginEvent(ServerEventType.WaitingForPlayers)]
		public void OnWaitingForPlayers()
		{
			Log.Info(" [&4EventHandler&r] Waiting for players..");
		}
	}
}
