using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
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
