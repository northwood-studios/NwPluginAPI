using CommandSystem;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerKickedEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerKicked;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public ICommandSender Issuer { get; }
		[EventArgument]
		public string Reason { get; set; }

		public PlayerKickedEvent(ReferenceHub hub, ICommandSender issuer, string reason)
		{
			Player = Core.Player.Get(hub);
			Issuer = issuer;
			Reason = reason;
		}

		PlayerKickedEvent() { }
	}
}
