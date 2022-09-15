namespace TemplatePlugin.Factory
{
	using PluginAPI.Core;
	using PluginAPI.Core.Interfaces;

	public class MyPlayer : Player
    {
        public MyPlayer(IGameComponent component) : base(component)
        {
        }

		public string TestParam { get; set; }

        public string Test => "TestValue";
    }
}
