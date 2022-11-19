using CustomPlayerEffects;

namespace PluginAPI.Core
{
	/// <summary>
	/// Manages a players effects.
	/// </summary>
	public class EffectsManager
	{
		private readonly Player _player;

		/// <summary>
		/// Initializes a new instance of the <see cref="EffectsManager"/> class.
		/// </summary>
		/// <param name="plr">The player.</param>
		public EffectsManager(Player plr) => _player = plr;

		/// <summary>
		/// Changes the state of a <see cref="StatusEffectBase">status effect</see> on the <see cref="Player"/>.
		/// </summary>
		/// <param name="intensity">The effect's new intensity.</param>
		/// <param name="duration">The effect's new duration.</param>
		/// <param name="addDuration">Whether the duration will be forced set or added to it's current one.</param>
		/// <returns>Whether or not an effect was found.</returns>
		public T ChangeState<T>(byte intensity, float duration = 0f, bool addDuration = false) where T : StatusEffectBase =>
			_player.ReferenceHub.playerEffectsController.ChangeState<T>(intensity, duration, addDuration);

		/// <summary>
		/// Changes the state of a <see cref="StatusEffectBase">status effect</see> on the <see cref="Player"/>.
		/// </summary>
		/// <param name="effectName">The string that will be used to lookup the effect.</param>
		/// <param name="intensity">The effect's new intensity.</param>
		/// <param name="duration">The effect's new duration.</param>
		/// <param name="addDuration">Whether the duration will be forced set or added to it's current one.</param>
		/// <returns>Whether or not an effect was found.</returns>
		public StatusEffectBase ChangeState(string effectName, byte intensity, float duration = 0f, bool addDuration = false) =>
			_player.ReferenceHub.playerEffectsController.ChangeState(effectName, intensity, duration, addDuration);

		/// <summary>
		/// Disables all <see cref="StatusEffectBase">status effects</see>.
		/// </summary>
		public void DisableAllEffects() => _player.ReferenceHub.playerEffectsController.DisableAllEffects();

		/// <summary>
		/// Enables a specific <see cref="StatusEffectBase">status effect</see> on the <see cref="Player"/>.
		/// </summary>
		/// <typeparam name="T">The specified effect that will be looked for.</typeparam>
		/// <param name="duration">The effect's new duration, by default the effect is.</param>
		/// <param name="addDuration">Whether the duration will be forced set or added to it's current one.</param>
		/// <returns>The <see cref="StatusEffectBase"/> instance of <typeparamref name="T"/>, otherwise <see langword="null"/>.</returns>
		public T EnableEffect<T>(float duration = 0f, bool addDuration = false) where T : StatusEffectBase =>
			_player.ReferenceHub.playerEffectsController.EnableEffect<T>(duration, addDuration);

		/// <summary>
		/// Disables a specific <see cref="StatusEffectBase">status effect</see> on the <see cref="Player"/>.
		/// </summary>
		/// <typeparam name="T">The specified effect that will be looked for.</typeparam>
		/// <returns>The <see cref="StatusEffectBase"/> instance of <typeparamref name="T"/>, otherwise <see langword="null"/>.</returns>
		public T DisableEffect<T>() where T : StatusEffectBase =>
			_player.ReferenceHub.playerEffectsController.DisableEffect<T>();

		/// <summary>
		/// Gets a specific <see cref="StatusEffectBase"/>.
		/// </summary>
		/// <typeparam name="T">The specified effect that will be looked for.</typeparam>
		/// <returns>The <see cref="StatusEffectBase"/> instance of <typeparamref name="T"/>, otherwise <see langword="null"/>.</returns>
		public T GetEffect<T>() where T : StatusEffectBase =>
			_player.ReferenceHub.playerEffectsController.GetEffect<T>();

		/// <summary>
		/// Attempts to find a <see cref="StatusEffectBase"/> and safely casts it.
		/// </summary>
		/// <typeparam name="T">The specified effect that will be looked for.</typeparam>
		/// <param name="statusEffect">The found player effect.</param>
		/// <returns>Whether or not a player effect was found. (And was cast successfully)</returns>
		public bool TryGetEffect<T>(out T statusEffect) where T : StatusEffectBase =>
			_player.ReferenceHub.playerEffectsController.TryGetEffect(out statusEffect);

		/// <summary>
		/// Attempts to find a <see cref="StatusEffectBase"/> based on the input string.
		/// </summary>
		/// <param name="effectName">The string that will be used to lookup the effect.</param>
		/// <param name="statusEffect">The returned player effect, if any was found. Otherwise it will be null.</param>
		/// <returns>Whether or not an effect was found.</returns>
		public bool TryGetEffect(string effectName, out StatusEffectBase statusEffect) =>
			_player.ReferenceHub.playerEffectsController.TryGetEffect(effectName, out statusEffect);
	}
}
