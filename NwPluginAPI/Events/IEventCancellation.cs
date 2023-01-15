using System;
using LiteNetLib.Utils;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace PluginAPI.Events
{
	/// <summary>
	/// Defines a cancellable event param.
	/// </summary>
	public interface IEventCancellation
	{
		/// <summary>
		/// Determines whether event is cancelled.
		/// </summary>
		bool IsCancelled { get; }
	}

	/// <summary>
	/// Represents PlayerPreauth event cancellation data.
	/// </summary>
	public readonly struct PreauthCancellationData : IEventCancellation
	{
		/// <inheritdoc />
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
		/// <param name="isForced">Indicates whether or not the player has to be rejected forcefully.</param>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
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
		/// <param name="isForced">Indicates whether or not the player has to be rejected forcefully.</param>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
		public static PreauthCancellationData RejectRedirect(ushort port, bool isForced) => new PreauthCancellationData(RejectionReason.Redirect, isForced, port: port);

		/// <summary>
		/// Rejects a player who's trying to authenticate.
		/// </summary>
		/// <param name="banReason">The ban reason.</param>
		/// <param name="expiration">The ban expiration time.</param>
		/// <param name="isForced">Indicates whether or not the player has to be rejected forcefully.</param>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
		public static PreauthCancellationData RejectBanned(string banReason, DateTime expiration, bool isForced) =>
			RejectBanned(banReason, expiration.Ticks, isForced);

		/// <summary>
		/// Rejects a player who's trying to authenticate.
		/// </summary>
		/// <param name="banReason">The ban reason.</param>
		/// <param name="expiration">The ban expiration time in .NET Ticks.</param>
		/// <param name="isForced">Indicates whether or not the player has to be rejected forcefully.</param>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
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
		/// <param name="customReason">The custom rejection reason.</param>
		/// <param name="isForced">Indicates whether the player has to be rejected forcefully or not.</param>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
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
		/// <param name="isForced">Indicates whether or not the player has to be rejected forcefully.</param>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
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
		/// <param name="isForced">Indicates whether or not the player has to be rejected forcefully or not.</param>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
		public static PreauthCancellationData Reject(NetDataWriter writer, bool isForced) => new PreauthCancellationData(RejectionReason.NotSpecified, isForced, writer: writer);

		/// <summary>
		/// Accepts the connection.
		/// </summary>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
		public static PreauthCancellationData Accept() =>
			new PreauthCancellationData(RejectionReason.NotSpecified, false, isCancelled: false);

		/// <summary>
		/// Handles the connection manually.
		/// </summary>
		/// <returns>The <see cref="PreauthCancellationData"/>.</returns>
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
		/// Generates a network writer for the rejection packet.
		/// </summary>
		/// <param name="forced">Indicates whether or not the rejection is forced.</param>
		/// <returns>The generated network writer.</returns>
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
	/// Represents PlayerCheckReservedSlot event cancellation data.
	/// </summary>
	public readonly struct PlayerCheckReservedSlotCancellationData : IEventCancellation
	{
		/// <inheritdoc />
		public bool IsCancelled { get; }

		/// <summary>
		/// Determines whether the player should be allowed to join unconditionally.
		/// </summary>
		public readonly bool BypassReservedSlotsLimit;

		// ReSharper disable once MemberCanBePrivate.Global
		public readonly bool HasReservedSlot;

		private PlayerCheckReservedSlotCancellationData(bool isCancelled, bool hasReservedSlot, bool bypassReservedSlotsLimit)
		{
			IsCancelled = isCancelled;
			HasReservedSlot = hasReservedSlot;
			BypassReservedSlotsLimit = bypassReservedSlotsLimit;
		}

		/// <summary>
		/// Doesn't override the reserved slot check.
		/// </summary>
		/// <returns>The <see cref="PlayerCheckReservedSlotCancellationData"/>.</returns>
		public static PlayerCheckReservedSlotCancellationData LeaveUnchanged() =>
			new PlayerCheckReservedSlotCancellationData(false, false, false);

		/// <summary>
		/// Overrides a reserved slot check.
		/// </summary>
		/// <param name="hasReservedSlot">Indicating whether or not the player has a reserved slot.</param>
		/// <returns>The <see cref="PlayerCheckReservedSlotCancellationData"/>.</returns>
		public static PlayerCheckReservedSlotCancellationData Override(bool hasReservedSlot) =>
			new PlayerCheckReservedSlotCancellationData(true, hasReservedSlot, false);

		/// <summary>
		/// Bypasses the check of free reserved slots on the server and allows the connection unconditionally.
		/// </summary>
		/// <returns></returns>
		public static PlayerCheckReservedSlotCancellationData BypassCheck() => new PlayerCheckReservedSlotCancellationData(true, true, true);
	}

	/// <summary>
	/// Represents PlayerPreCoinFlip event cancellation data.
	/// </summary>
	public readonly struct PlayerPreCoinFlipCancellationData : IEventCancellation
	{
		/// <inheritdoc />
		public bool IsCancelled => Cancellation != CoinFlipCancellation.None;

		public CoinFlipCancellation Cancellation { get; }

		private PlayerPreCoinFlipCancellationData(CoinFlipCancellation cancellation) => Cancellation = cancellation;

		/// <summary>
		/// Doesn't override the coin flip result.
		/// </summary>
		/// <returns>The <see cref="PlayerPreCoinFlipCancellationData"/>.</returns>
		public static PlayerPreCoinFlipCancellationData LeaveUnchanged() =>
			new PlayerPreCoinFlipCancellationData(CoinFlipCancellation.None);

		/// <returns></returns>
		/// /// <summary>
		/// Overrides the flip result.
		/// </summary>
		/// <param name="isTails">True if the coin flip result should be tails.</param>
		/// <returns>The <see cref="PlayerPreCoinFlipCancellationData"/>.</returns>
		public static PlayerPreCoinFlipCancellationData Override(bool isTails) =>
			new PlayerPreCoinFlipCancellationData(isTails ? CoinFlipCancellation.Tails : CoinFlipCancellation.Heads);

		/// <summary>
		/// Prevents the coin flip.
		/// </summary>
		/// <returns>The <see cref="PlayerPreCoinFlipCancellationData"/>.</returns>
		public static PlayerPreCoinFlipCancellationData PreventFlip() =>
			new PlayerPreCoinFlipCancellationData(CoinFlipCancellation.PreventFlip);

		public enum CoinFlipCancellation
		{
			None,
			Heads,
			Tails,
			PreventFlip,
		}
	}

	/// <summary>
	/// Represents RoundEnd event cancellation data.
	/// </summary>
	public readonly struct RoundEndCancellationData : IEventCancellation
	{
		/// <inheritdoc />
		public bool IsCancelled { get; }

		public readonly float Delay;

		private RoundEndCancellationData(bool isCancelled, float delay)
		{
			IsCancelled = isCancelled;
			Delay = delay;
		}

		/// <summary>
		/// Allows the round end.
		/// </summary>
		/// <returns>The <see cref="RoundEndCancellationData"/>.</returns>
		public static RoundEndCancellationData AllowRoundEnd() =>
			new RoundEndCancellationData(false, 0);

		/// <summary>
		/// Delays the round end.
		/// </summary>
		/// /// <param name="delay">Determines the delay (in seconds).</param>
		/// <returns>The <see cref="RoundEndCancellationData"/>.</returns>
		/// <exception cref="ArgumentException"></exception>
		public static RoundEndCancellationData DelayRoundEnd(float delay)
		{
			if (delay <= 0)
				throw new ArgumentException("Delay must be greater than 0.", nameof(delay));

			return new RoundEndCancellationData(true, delay);
		}

		/// <summary>
		/// Permanently aborts the round end.
		/// </summary>
		/// <returns>The <see cref="RoundEndCancellationData"/>.</returns>
		public static RoundEndCancellationData AbortRoundEnd()
		{
			return new RoundEndCancellationData(true, 0);
		}
	}

	/// <summary>
	/// Represents RoundEndConditionsCheck event cancellation data.
	/// </summary>
	public readonly struct RoundEndConditionsCheckCancellationData : IEventCancellation
	{
		/// <inheritdoc />
		public bool IsCancelled => Cancellation != RoundEndConditionsCheckCancellation.None;

		public readonly RoundEndConditionsCheckCancellation Cancellation;

		private RoundEndConditionsCheckCancellationData(RoundEndConditionsCheckCancellation cancellation) => Cancellation = cancellation;

		/// <summary>
		/// Doesn't override the round end conditions check result.
		/// </summary>
		/// <returns>The <see cref="PlayerPreCoinFlipCancellationData"/>.</returns>
		public static RoundEndConditionsCheckCancellationData LeaveUnchanged() =>
			new RoundEndConditionsCheckCancellationData(RoundEndConditionsCheckCancellation.None);

		/// <returns></returns>
		/// /// <summary>
		/// Overrides the the round end conditions check result.
		/// </summary>
		/// <param name="satisfied">Indicates whether round end conditions are satisfied.</param>
		/// <returns>The <see cref="PlayerPreCoinFlipCancellationData"/>.</returns>
		public static RoundEndConditionsCheckCancellationData Override(bool satisfied) =>
			new RoundEndConditionsCheckCancellationData(satisfied ? RoundEndConditionsCheckCancellation.ConditionsSatisfied : RoundEndConditionsCheckCancellation.ConditionsNotSatisfied);

		public enum RoundEndConditionsCheckCancellation
		{
			None,
			ConditionsSatisfied,
			ConditionsNotSatisfied
		}
	}

	/// <summary>
	/// Represents PlayerGetGroup event cancellation data.
	/// </summary>
	public readonly struct PlayerGetGroupCancellationData : IEventCancellation
	{
		/// <inheritdoc />
		public bool IsCancelled { get; }

		public readonly UserGroup AssignedUserGroup;

		private PlayerGetGroupCancellationData(bool isCancelled, UserGroup assignedUserGroup)
		{
			IsCancelled = isCancelled;
			AssignedUserGroup = assignedUserGroup;
		}

		/// <summary>
		/// Doesn't override the user group.
		/// </summary>
		/// <returns>The <see cref="PlayerGetGroupCancellationData"/>.</returns>
		public static PlayerGetGroupCancellationData LeaveUnchanged() =>
			new PlayerGetGroupCancellationData(false, null);

		/// <returns></returns>
		/// /// <summary>
		/// Overrides the user group.
		/// </summary>
		/// <param name="assignedUserGroup">User group assigned to the Player.</param>
		/// <returns>The <see cref="PlayerGetGroupCancellationData"/>.</returns>
		public static PlayerGetGroupCancellationData Override(UserGroup assignedUserGroup) =>
			new PlayerGetGroupCancellationData(true, assignedUserGroup);
	}
}