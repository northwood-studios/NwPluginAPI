namespace PluginAPI.Core
{
	/// <summary>
	/// Manages the warhead.
	/// </summary>
    public static class Warhead
	{
		/// <summary>
		/// Gets or sets a value indicating whether or not the lever in the warhead room is enabled.
		/// </summary>
		public static bool LeverStatus
		{
			get => Server.Instance.GetComponent<AlphaWarheadNukesitePanel>(true).enabled;
			set => Server.Instance.GetComponent<AlphaWarheadNukesitePanel>(true).enabled = value;
		}

		/// <summary>
		/// Gets or sets a value indicating whether or not the button in outside nuke panel is unlocked.
		/// </summary>
		public static bool WarheadUnlocked
		{
			get => Server.Instance.GetComponent<AlphaWarheadOutsitePanel>(true).keycardEntered;
			set => Server.Instance.GetComponent<AlphaWarheadOutsitePanel>(true).keycardEntered = value;
		}

		/// <summary>
		/// Gets a value indicating whether or not the warhead is detonated.
		/// </summary>
		public static bool IsDetonated => AlphaWarheadController.Detonated;

		/// <summary>
		/// Gets a value indicating whether or not the warhead detonation is in progress.
		/// </summary>
		public static bool IsDetonationInProgress => AlphaWarheadController.InProgress;

		/// <summary>
		/// Gets or sets a time of detonation.
		/// </summary>
		public static float DetonationTime
		{
			get => AlphaWarheadController.TimeUntilDetonation;
			set => AlphaWarheadController.Singleton.ForceTime(value);
		}

		#region Detonation
		/// <summary>
		/// Starts the detonation countdown.
		/// </summary>
		/// <param name="isAutomatic">Determines whether the detonation is automatic.</param>
		/// <param name="suppressSubtitles">Determines whether subtitles should be suppressed.</param>
		public static void Start(bool isAutomatic = true, bool suppressSubtitles = false)
		{
			AlphaWarheadController.Singleton.InstantPrepare();
			AlphaWarheadController.Singleton.StartDetonation(isAutomatic, suppressSubtitles);
		}

		/// <summary>
		/// Stops the detonation countdown.
		/// </summary>
		public static void Stop() => Server.Instance.GetComponent<AlphaWarheadController>().CancelDetonation();

		/// <summary>
		/// Detonate warhead.
		/// </summary>
		public static void Detonate() => Server.Instance.GetComponent<AlphaWarheadController>().ForceTime(0);
		#endregion

		#region Shake Effect
		/// <summary>
		/// Show the shake effect to all players.
		/// </summary>
		public static void Shake()
		{
			//foreach(var player in Player.List)
			//	player.Warhead.Shake();
		}
		#endregion
	}
}
