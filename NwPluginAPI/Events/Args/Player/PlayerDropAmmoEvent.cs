using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerDropAmmoEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDropAmmo;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ItemType Item { get; }
		[EventArgument]
		public int Amount { get; set; }

		public PlayerDropAmmoEvent(ReferenceHub hub, ItemType item, int amount)
		{
			Player = Core.Player.Get(hub);
			Item = item;
			Amount = amount;
		}

		PlayerDropAmmoEvent() { }
	}
}
