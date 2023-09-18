using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerCheckReservedSlotEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerCheckReservedSlot;
		[EventArgument]
		public string Userid { get; }
		[EventArgument]
		public bool HasReservedSlot { get; }

		public PlayerCheckReservedSlotEvent(string userId, bool hasReservedSlot)
		{
			Userid = userId;
			HasReservedSlot = hasReservedSlot;
		}

		PlayerCheckReservedSlotEvent() { }
	}
}
