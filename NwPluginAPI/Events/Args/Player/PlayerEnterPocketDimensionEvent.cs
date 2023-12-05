using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerEnterPocketDimensionEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerEnterPocketDimension;
		[EventArgument]
		public Player Player { get; }

		public PlayerEnterPocketDimensionEvent(ReferenceHub hub)
		{
			Player = Player.Get(hub);
		}

		PlayerEnterPocketDimensionEvent() { }
	}
}
