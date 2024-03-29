using InventorySystem.Items.Pickups;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerPickupScp330Event : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerPickupScp330;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ItemPickupBase Item { get; }

		public PlayerPickupScp330Event(ReferenceHub hub, ItemPickupBase item)
		{
			Player = Player.Get(hub);
			Item = item;
		}

		PlayerPickupScp330Event() { }
	}
}
