using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerPreCoinFlipEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerPreCoinFlip;
		[EventArgument]
		public Player Player { get; }

		public PlayerPreCoinFlipEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		PlayerPreCoinFlipEvent() { }
	}
}
