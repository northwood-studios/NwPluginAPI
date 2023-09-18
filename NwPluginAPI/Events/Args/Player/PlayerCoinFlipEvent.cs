using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerCoinFlipEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCoinFlip;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public bool IsTails { get; }

		public PlayerCoinFlipEvent(ReferenceHub hub, bool isTails)
		{
			Player = Core.Player.Get(hub);
			IsTails = isTails;
		}

		PlayerCoinFlipEvent() { }
	}
}
