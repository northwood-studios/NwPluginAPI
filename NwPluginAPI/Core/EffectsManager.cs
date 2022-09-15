using CustomPlayerEffects;

namespace PluginAPI.Core
{
	/// <summary>
	/// Manager for player effects.
	/// </summary>
	public class EffectsManager
	{
		private Player _player;

		/// <summary>
		/// Constructor for effects manager.
		/// </summary>
		/// <param name="plr">The player.</param>
		public EffectsManager(Player plr) => _player = plr;

		#region Enable/Disable
		/// <summary>
		/// Enables effect on player.
		/// </summary>
		/// <typeparam name="T">The type of effect.</typeparam>
		/// <param name="duration">The duration of effect.</param>
		/// <param name="addDurationIfActive">If effect is active duration will be increased.</param>
		public void EnableEffect<T>(float duration = 0f, bool addDurationIfActive = false) where T : PlayerEffect => _player.ReferenceHub.playerEffectsController.EnableEffect<T>(duration, addDurationIfActive);

		/// <summary>
		/// Enables effect on player.
		/// </summary>
		/// <param name="effect">The type of effect.</param>
		/// <param name="duration">The duration of effect.</param>
		/// <param name="addDurationIfActive">If effect is active duration will be increased.</param>
		public void EnableEffect(PlayerEffect effect, float duration = 0f, bool addDurationIfActive = false) => _player.ReferenceHub.playerEffectsController.EnableEffect(effect, duration, addDurationIfActive);

		/// <summary>
		/// Enables effect on player.
		/// </summary>
		/// <param name="name">The name of effect.</param>
		/// <param name="duration">The duration of effect.</param>
		/// <param name="addDurationIfActive">If effect is active duration will be increased.</param>
		/// <returns>If player effect was successfully enabled.</returns>
		public bool EnableEffect(string name, float duration = 0f, bool addDurationIfActive = false) => _player.ReferenceHub.playerEffectsController.EnableByString(name, duration, addDurationIfActive);

		/// <summary>
		/// Disables effect on player.
		/// </summary>
		/// <typeparam name="T">The type of effect.</typeparam>
		public void DisableEffect<T>() where T : PlayerEffect => _player.ReferenceHub.playerEffectsController.DisableEffect<T>();
		#endregion

		#region Intensity
		/// <summary>
		/// Changes player effect intensity.
		/// </summary>
		/// <typeparam name="T">The type of player effect.</typeparam>
		/// <param name="intensity">The intensity amount.</param>
		public void ChangeEffectIntensity<T>(byte intensity) where T : PlayerEffect => _player.ReferenceHub.playerEffectsController.ChangeEffectIntensity<T>(intensity);

		/// <summary>
		/// Changes player effect intensity.
		/// </summary>
		/// <param name="name">The name of effect.</param>
		/// <param name="intensity">The intensity amount.</param>
		/// <param name="duration">The duration of effect.</param>
		/// <returns>If player effect was successfully changed.</returns>
		public bool ChangeEffectIntensity(string name, byte intensity, float duration = 0) => _player.ReferenceHub.playerEffectsController.ChangeByString(name, intensity, duration);
		#endregion
	}
}
