using LiteNetLib;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerPreauthEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerPreauth;
		[EventArgument]
		public string UserId { get; }
		[EventArgument]
		public string IpAddress { get; }
		[EventArgument]
		public long Expiration { get; }
		[EventArgument]
		public CentralAuthPreauthFlags CentralFlags { get; }
		[EventArgument]
		public string Region { get; }
		[EventArgument]
		public byte[] Signature { get; }
		[EventArgument]
		public ConnectionRequest ConnectionRequest { get; }
		[EventArgument]
		public int ReaderStartPosition { get; }

		public PlayerPreauthEvent(string userId, string ipAddress, long expiration, CentralAuthPreauthFlags centralFlags, string region, byte[] signature, ConnectionRequest connectionRequest, int readerStartPosition)
		{
			UserId = userId;
			IpAddress = ipAddress;
			Expiration = expiration;
			CentralFlags = centralFlags;
			Region = region;
			Signature = signature;
			ConnectionRequest = connectionRequest;
			ReaderStartPosition = readerStartPosition;
		}

		PlayerPreauthEvent() { }
	}
}
