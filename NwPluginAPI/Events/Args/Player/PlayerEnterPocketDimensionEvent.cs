using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerEnterPocketDimensionEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerEnterPocketDimension;
		[EventArgument]
		public Core.Player Player { get; }

		public PlayerEnterPocketDimensionEvent(ReferenceHub hub)
		{
			Player = Core.Player.Get(hub);
		}

		PlayerEnterPocketDimensionEvent() { }
	}
}
