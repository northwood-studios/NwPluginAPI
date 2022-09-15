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
		public static bool IsDetonated => Server.Instance.GetComponent<AlphaWarheadController>().detonated;

		/// <summary>
		/// Gets a value if warhead detonation is in prgoress.
		/// </summary>
		public static bool IsDetonationInProgress => Server.Instance.GetComponent<AlphaWarheadController>().inProgress;

		/// <summary>
		/// Gets a value if detonation can be started.
		/// </summary>
		public static bool CanBeStarted => Server.Instance.GetComponent<AlphaWarheadController>().CanDetonate;

		/// <summary>
		/// Gets or sets a time of detonation.
		/// </summary>
		public static float DetonationTime
		{
			get => Server.Instance.GetComponent<AlphaWarheadController>().timeToDetonation;
			set => Server.Instance.GetComponent<AlphaWarheadController>().timeToDetonation = value;
		}

		/// <summary>
		/// Gets a real detonation time.
		/// </summary>
		public static float RealDetonationTime => Server.Instance.GetComponent<AlphaWarheadController>().RealDetonationTime();

		#region Detonation
		/// <summary>
		/// Starts the detonation countdown.
		/// </summary>
		public static void Start()
		{
			Server.Instance.GetComponent<AlphaWarheadController>().InstantPrepare();
			Server.Instance.GetComponent<AlphaWarheadController>().StartDetonation();
		}

		/// <summary>
		/// Stops the detonation countdown.
		/// </summary>
		public static void Stop()
		{
			Server.Instance.GetComponent<AlphaWarheadController>().CancelDetonation();
		}

		/// <summary>
		/// Detonate warhead.
		/// </summary>
		public static void Detonate()
		{
			Server.Instance.GetComponent<AlphaWarheadController>().StartDetonation(instant: true);
		}
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
