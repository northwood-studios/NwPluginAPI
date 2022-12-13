namespace TemplatePlugin.Factory
{
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Core.Interfaces;
	using PluginAPI.Enums;
	using PluginAPI.Events;

	public class MyPlayer : Player
    {
        public MyPlayer(IGameComponent component) : base(component)
        {
			EventManager.RegisterEvents(MainClass.Singleton, this);
        }

		public string TestParam { get; set; }

        public string Test => "TestValue";

		[PluginEvent(ServerEventType.PlayerRemoteAdminCommand)]
		public void OnRaCommand(MyPlayer plr, string cmd, string[] args)
		{
			if (plr != this) return;

			Log.Info($" [&4MyPlayer&r] Player {plr.Nickname} executed command {cmd}");
		}

		public override void OnDestroy()
		{
			EventManager.UnregisterEvents(MainClass.Singleton, this);
		}
	}
}
