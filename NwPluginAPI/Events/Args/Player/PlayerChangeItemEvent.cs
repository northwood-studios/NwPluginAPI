using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerChangeItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerChangeItem;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public ushort OldItem { get; }
		[EventArgument]
		public ushort NewItem { get; set; }

		public PlayerChangeItemEvent(ReferenceHub hub, ushort oldItem, ushort newItem)
		{
			Player = Player.Get(hub);
			OldItem = oldItem;
			NewItem = newItem;
		}

		PlayerChangeItemEvent() { }
	}
}
