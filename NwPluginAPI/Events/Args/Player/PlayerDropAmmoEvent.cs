using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerDropAmmoEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerDropAmmo;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemType Item { get; }
		[EventArgument]
		public int Amount { get; set; }

		public PlayerDropAmmoEvent(ReferenceHub hub, ItemType item, int amount)
		{
			Player = Player.Get(hub);
			Item = item;
			Amount = amount;
		}

		PlayerDropAmmoEvent() { }
	}
}
