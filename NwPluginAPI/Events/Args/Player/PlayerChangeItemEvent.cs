using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerChangeItemEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerChangeItem;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ushort OldItem { get; }
		[EventArgument]
		public ushort NewItem { get; set; }

		public PlayerChangeItemEvent(ReferenceHub hub, ushort oldItem, ushort newItem)
		{
			Player = Core.Player.Get(hub);
			OldItem = oldItem;
			NewItem = newItem;
		}

		PlayerChangeItemEvent() { }
	}
}
