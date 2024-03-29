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
		public int Uses { get; set; }
		[EventArgument]
		public bool PlaySound { get; set; } = true;
		[EventArgument]
		public bool AllowPunishment { get; set; } = true;

		public PlayerInteractScp330Event(ReferenceHub hub, int uses)
		{
			Player = Player.Get(hub);
			Uses = uses;
		}

		PlayerInteractScp330Event() { }
	}
}
