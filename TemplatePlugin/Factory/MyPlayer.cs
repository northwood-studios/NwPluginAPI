namespace TemplatePlugin.Factory
{
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using PluginAPI.Core.Interfaces;
	using PluginAPI.Events;

	public class MyPlayer : Player
    {
        public MyPlayer(IGameComponent component) : base(component)
        {
			EventManager.RegisterEvents(MainClass.Singleton, this);
        }

		public string TestParam { get; set; }

        public string Test => "TestValue";

		[PluginEvent(PluginAPI.Enums.ServerEventType.ConsoleCommand)]
		public void OnConsole(string cmd, string[] args)
		{
			Log.Info($"{cmd}");
		}

		public override void OnDestroy()
		{
			EventManager.UnregisterEvents(MainClass.Singleton, this);
		}
	}
}
