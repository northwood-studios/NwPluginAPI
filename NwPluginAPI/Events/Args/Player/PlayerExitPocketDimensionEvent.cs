using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerExitPocketDimensionEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerExitPocketDimension;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public bool IsSuccessful { get; set; }

		public PlayerExitPocketDimensionEvent(ReferenceHub hub, bool isSuccessful)
		{
			Player = Core.Player.Get(hub);
			IsSuccessful = isSuccessful;
		}

		PlayerExitPocketDimensionEvent() { }
	}
}
