using System;
using LiteNetLib.Utils;

namespace PluginAPI.Events
{
	public interface IEventCancellation
	{
		/// <summary>
		/// Determines whether event is cancelled.
		/// </summary>
		bool IsCancelled { get; }
	}

	/// <summary>
	/// Preauth Event Cancellation Data
	/// </summary>
	public readonly struct PreauthCancellationData : IEventCancellation
	{
		public bool IsCancelled { get; }

		private readonly bool _handledManually;
		
		private readonly NetDataWriter _customWriter;
		private readonly RejectionReason _reason;
		private readonly bool _isForced;
		private readonly byte _seconds;
		private readonly long _expiration;
		private readonly string _customReason;
		private readonly ushort _port;

		/// <summary>
		/// Delays the connection.
		/// </summary>
		/// <param name="seconds">The delay in seconds.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>Event cancellation data</returns>
		public static PreauthCancellationData RejectDelay(byte seconds, bool isForced)
		{
			if (seconds < 1 || seconds > 25)
				throw new Exception("Delay duration must be between 1 and 25 seconds.");

			return new PreauthCancellationData(RejectionReason.Delay, isForced, seconds: seconds);
		}

		/// <summary>
		/// Rejects the player and redirects them to another server port.
		/// </summary>
		/// <param name="port">The new server port.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>Event cancellation data</returns>
		public static PreauthCancellationData RejectRedirect(ushort port, bool isForced) => new PreauthCancellationData(RejectionReason.Redirect, isForced, port: port);

		/// <summary>
		/// Rejects a player who's trying to authenticate.
		/// </summary>
		/// <param name="banReason">The ban reason.</param>
		/// <param name="expiration">The ban expiration time.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>Event cancellation data</returns>
		public static PreauthCancellationData RejectBanned(string banReason, DateTime expiration, bool isForced) =>
			RejectBanned(banReason, expiration.Ticks, isForced);

		/// <summary>
		/// Rejects a player who's trying to authenticate.
		/// </summary>
		/// <param name="banReason">The ban reason.</param>
		/// <param name="expiration">The ban expiration time in .NET Ticks.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>Event cancellation data</returns>
		// ReSharper disable once MemberCanBePrivate.Global
		public static PreauthCancellationData RejectBanned(string banReason, long expiration, bool isForced)
		{
			if (banReason.Length > 400)
				throw new ArgumentOutOfRangeException(nameof(banReason), "Reason can't be longer than 400 characters.");
			
			return new PreauthCancellationData(RejectionReason.Banned, isForced, banReason, expiration: expiration);
		}

		/// <summary>
		/// Rejects a player who's trying to authenticate.
		/// </summary>
		/// <param name="customReason">Custom rejection reason.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>Event cancellation data</returns>
		public static PreauthCancellationData Reject(string customReason, bool isForced)
		{
			if (string.IsNullOrEmpty(customReason) || customReason.Length > 400)
				throw new ArgumentOutOfRangeException(nameof(customReason), "Reason can't be null, empty or longer than 400 characters.");
			
			return new PreauthCancellationData(RejectionReason.Custom, isForced, customReason: customReason);
		}

		/// <summary>
		/// Rejects a player who's trying to authenticate.
		/// </summary>
		/// <param name="reason">Rejection reason.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>Event cancellation data</returns>
		public static PreauthCancellationData Reject(RejectionReason reason, bool isForced)
		{
			switch (reason)
			{
				case RejectionReason.Banned:
				case RejectionReason.Delay:
				case RejectionReason.Redirect:
				case RejectionReason.Custom:
					throw new Exception("Specified reason requires extra parameters. Please use the appropriate method.");
				
				default:
					return new PreauthCancellationData(reason, isForced);
			}
		}
		
		/// <summary>
		/// Rejects a player who's trying to authenticate.
		/// </summary>
		/// <param name="writer">The <see cref="NetDataWriter"/> instance.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>Event cancellation data</returns>
		public static PreauthCancellationData Reject(NetDataWriter writer, bool isForced) => new PreauthCancellationData(RejectionReason.NotSpecified, isForced, writer: writer);

		/// <summary>
		/// Accepts the connection.
		/// </summary>
		/// <returns>Event cancellation data</returns>
		public static PreauthCancellationData Accept() =>
			new PreauthCancellationData(RejectionReason.NotSpecified, false, isCancelled: false);
		
		public static PreauthCancellationData HandledManually() => new PreauthCancellationData(RejectionReason.NotSpecified, false, handledManually: true);
		
		private PreauthCancellationData(RejectionReason rejectionReason, bool isForced, string customReason = null,
			long expiration = 0, byte seconds = 0, ushort port = 0, NetDataWriter writer = null, bool isCancelled = true, bool handledManually = false)
		{
			IsCancelled = isCancelled;

			_customWriter = null;
			_reason = rejectionReason;
			_isForced = isForced;
			_customReason = customReason;
			_expiration = expiration;
			_seconds = seconds;
			_port = port;
			_customWriter = writer;
			_handledManually = handledManually;
		}
		
		/// <summary>
		/// Generates network writer for the rejection packet.
		/// </summary>
		/// <param name="forced">Determines whether the rejection is forced.</param>
		/// <returns>Network writer</returns>
		public NetDataWriter GenerateWriter(out bool forced)
		{
			forced = _isForced;
			
			if (!IsCancelled || _handledManually)
				return null;

			if (_reason == RejectionReason.NotSpecified && _customWriter != null)
				return _customWriter;
			
			var writer = new NetDataWriter();
			writer.Put((byte)_reason);
			
			switch (_reason)
			{
				case RejectionReason.Banned:
					writer.Put(_expiration);
					writer.Put(_customReason);
					break;

				case RejectionReason.Custom:
					writer.Put(_customReason);
					break;

				case RejectionReason.Delay:
					writer.Put(_seconds);
					break;

				case RejectionReason.Redirect:
					writer.Put(_port);
					break;
			}

			return writer;
		}
	}

	/// <summary>
	/// Preauth Event Cancellation Data
	/// </summary>
	public readonly struct PlayerCheckReservedSlotCancellationData : IEventCancellation
	{
		public bool IsCancelled { get; }

		// ReSharper disable once MemberCanBePrivate.Global
		public readonly bool HasReservedSlot;

		private PlayerCheckReservedSlotCancellationData(bool isCancelled, bool hasReservedSlot)
		{
			IsCancelled = isCancelled;
			HasReservedSlot = hasReservedSlot;
		}

		/// <summary>
		/// Doesn't override the reserved slot check.
		/// </summary>
		/// <returns>Event cancellation data</returns>
		public static PlayerCheckReservedSlotCancellationData LeaveUnchanged() =>
			new PlayerCheckReservedSlotCancellationData(false, false);

		/// <summary>
		/// Overrides reserved slot check.
		/// </summary>
		/// <param name="hasReservedSlot">Indicates whether the player has a reserved slot or not.</param>
		/// <returns>Event cancellation data</returns>
		public static PlayerCheckReservedSlotCancellationData Override(bool hasReservedSlot) =>
			new PlayerCheckReservedSlotCancellationData(true, hasReservedSlot);
	}
}