namespace PluginAPI.Core
{
    public static class Warhead
	{
		/// <summary>
		/// Gets or sets a value if lever in nukesite is enabled or disabled.
		/// </summary>
		public static bool LeverStatus
		{
			get => Server.Instance.GetComponent<AlphaWarheadNukesitePanel>(true).enabled;
			set => Server.Instance.GetComponent<AlphaWarheadNukesitePanel>(true).enabled = value;
		}

		/// <summary>
		/// Gets or sets a value if button in outside nuke panel is unlocked.
		/// </summary>
		public static bool WarheadUnlocked
		{
			get => Server.Instance.GetComponent<AlphaWarheadOutsitePanel>(true).keycardEntered;
			set => Server.Instance.GetComponent<AlphaWarheadOutsitePanel>(true).keycardEntered = value;
		}

		/// <summary>
		/// Gets a value if warhead is detonated.
		/// </summary>
		public static bool IsDetonated => AlphaWarheadController.Detonated;

		/// <summary>
		/// Gets a value if warhead detonation is in progress.
		/// </summary>
		public static bool IsDetonationInProgress => AlphaWarheadController.InProgress;

		/// <summary>
		/// Gets or sets a time of detonation.
		/// </summary>
		public static float DetonationTime
		{
			get => AlphaWarheadController.TimeUntilDetonation;
			set => Server.Instance.GetComponent<AlphaWarheadController>().ForceTime(value);
		}

		#region Detonation
		/// <summary>
		/// Starts the detonation countdown.
		/// </summary>
		/// <param name="isAutomatic">Determines whether the detonation is automatic.</param>
		/// <param name="suppressSubtitles">Determines whether subtitles should be suppressed.</param>
		public static void Start(bool isAutomatic = true, bool suppressSubtitles = false)
		{
			Server.Instance.GetComponent<AlphaWarheadController>().InstantPrepare();
			Server.Instance.GetComponent<AlphaWarheadController>().StartDetonation(isAutomatic, suppressSubtitles);
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
		/// Show shake effect on all players.
		/// </summary>
		public static void Shake()
		{
			//foreach(var player in Player.List)
			//	player.Warhead.Shake();
		}
		#endregion
	}
}
