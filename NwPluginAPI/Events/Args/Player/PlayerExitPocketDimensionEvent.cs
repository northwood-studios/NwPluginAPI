using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerExitPocketDimensionEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerExitPocketDimension;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public bool IsSuccessful { get; set; }

		public PlayerExitPocketDimensionEvent(ReferenceHub hub, bool isSuccessful)
		{
			Player = Player.Get(hub);
			IsSuccessful = isSuccessful;
		}

		PlayerExitPocketDimensionEvent() { }
	}
}
