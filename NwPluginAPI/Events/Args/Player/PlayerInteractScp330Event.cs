using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerInteractScp330Event : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractScp330;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public int Uses { get; set; }
		[EventArgument]
		public bool PlaySound { get; set; } = true;
		[EventArgument]
		public bool AllowPunishment { get; set; } = true;

		public PlayerInteractScp330Event(ReferenceHub hub, int uses)
		{
			Player = Core.Player.Get(hub);
			Uses = uses;
		}

		PlayerInteractScp330Event() { }
	}
}
