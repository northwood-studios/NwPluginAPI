using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerPreCoinFlipEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerPreCoinFlip;
		[EventArgument]
		public Core.Player Player { get; }

		public PlayerPreCoinFlipEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		PlayerPreCoinFlipEvent() { }
	}
}
