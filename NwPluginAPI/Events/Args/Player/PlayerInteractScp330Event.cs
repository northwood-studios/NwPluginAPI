using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerInteractScp330Event : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractScp330;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public int MaxCandiesPerLife { get; set; }
		[EventArgument]
		public bool PlaySound { get; set; }

		public PlayerInteractScp330Event(ReferenceHub hub, int maxCandiesPerLife, bool playSound)
		{
			Player = Player.Get(hub);
			MaxCandiesPerLife = maxCandiesPerLife;
			PlaySound = playSound;
		}

		PlayerInteractScp330Event() { }
	}
}
