using LiteNetLib;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.PlayerPreauth"/>.
	/// </summary>
	public class PreAuthenticatingEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="PreAuthenticatingEventArgs"/>.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="ipAddress"></param>
		/// <param name="expiration"></param>
		/// <param name="flags"></param>
		/// <param name="country"></param>
		/// <param name="signature"></param>
		/// <param name="request"></param>
		/// <param name="readerStartPosition"></param>
		public PreAuthenticatingEventArgs(string userId, string ipAddress, long expiration,
			CentralAuthPreauthFlags flags, string country, byte[] signature, LiteNetLib.ConnectionRequest request,
			int readerStartPosition)
		{
			UserId = userId;
			IpAddress = ipAddress;
			Expiration = expiration;
			Flags = flags;
			Country = country;
			Signature = signature;
			Request = request;
			ReaderStartPosition = readerStartPosition;
		}

		/// <summary>
		/// Gets the player user id.
		/// </summary>
		public string UserId { get; }

		/// <summary>
		/// Gets the player IP address.
		/// </summary>
		public string IpAddress { get; }

		/// <summary>
		/// Gets request expiration.
		/// </summary>
		public long Expiration { get; }

		/// <summary>
		/// Gets <see cref="CentralAuthPreauthFlags"/>.
		/// </summary>
		public CentralAuthPreauthFlags Flags { get; }

		/// <summary>
		/// Gets player country.
		/// </summary>
		public string Country { get; }

		/// <summary>
		/// Gets request signature.
		/// </summary>
		public byte[] Signature { get; }

		/// <summary>
		/// Gets the connection request.
		/// </summary>
		public ConnectionRequest Request { get; }

		/// <summary>
		/// Gets the reader start point for reading the preauth.
		/// </summary>
		public int ReaderStartPosition { get; }
	}
}