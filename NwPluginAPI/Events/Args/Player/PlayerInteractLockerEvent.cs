using MapGeneration.Distributors;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerInteractLockerEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerInteractLocker;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Locker Locker { get; }
		[EventArgument]
		public LockerChamber Chamber { get; }
		[EventArgument]
		public bool CanOpen { get; set; }

		public PlayerInteractLockerEvent(ReferenceHub hub, Locker locker, LockerChamber chamber, bool canOpen)
		{
			Player = Player.Get(hub);
			Locker = locker;
			Chamber = chamber;
			CanOpen = canOpen;
		}

		PlayerInteractLockerEvent() { }
	}
}
