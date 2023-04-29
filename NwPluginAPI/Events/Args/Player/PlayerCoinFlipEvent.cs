using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerCoinFlipEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCoinFlip;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public bool IsTails { get; }

		public PlayerCoinFlipEvent(ReferenceHub hub, bool isTails)
		{
			Player = Player.Get(hub);
			IsTails = isTails;
		}

		PlayerCoinFlipEvent() { }
	}
}
