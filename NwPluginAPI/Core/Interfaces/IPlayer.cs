namespace PluginAPI.Core.Interfaces
{
	using UnityEngine;

	/// <summary>
	/// Defines a player.
	/// </summary>
	public interface IPlayer : IEntity
	{
		/// <summary>
		/// Gets if player is dedicated server.
		/// </summary>
		bool IsServer { get; }

		/// <summary>
		/// Gets the player's <see cref="global::ReferenceHub"/>.
		/// </summary>
		ReferenceHub ReferenceHub { get; }

		/// <summary>
		/// Gets the player's <see cref="UnityEngine.GameObject"/>.
		/// </summary>
		GameObject GameObject { get; }

		/// <summary>
		/// Gets player temporary data storage.
		/// </summary>
		DataStorage TemporaryData { get; }

		/// <summary>
		/// Executed when player object is created.
		/// </summary>
		void OnStart();

		/// <summary>
		/// Executed when player object is destroyed.
		/// </summary>
		void OnDestroy();

		/// <summary>
		/// Executed every frame.
		/// </summary>
		void OnUpdate();

		/// <summary>
		/// Executed after all OnUpdate functions have been called.
		/// </summary>
		void OnLateUpdate();

		/// <summary>
		/// Executed with the frequency of the physics system.
		/// <remarks>Unity's physics engine runs at 50hz by default.</remarks>
		/// </summary>
		void OnFixedUpdate();

		/// <summary>
		/// Gets the <see cref="UnityEngine.MonoBehaviour"/> and caches it.
		/// </summary>
		T GetComponent<T>(bool globalSearch = false) where T : MonoBehaviour;

		/// <summary>
		/// Gets the <see cref="UnityEngine.MonoBehaviour"/> and caches it.
		/// </summary>
		bool TryGetComponent<T>(out T component, bool globalSearch = false) where T : MonoBehaviour;
	}
}