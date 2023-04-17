namespace PluginAPI.Core.Factories
{
	using Interfaces;
	using System.Collections.Generic;

	/// <summary>
	/// Factory for entities.
	/// </summary>
	/// <typeparam name="T">The entity type.</typeparam>
	public class Factory<T> : IEntityFactory<T> where T : IEntity
	{
		internal readonly Dictionary<IGameComponent, T> Entities = new Dictionary<IGameComponent, T>();

		/// <summary>
		/// Gets all entities stored in factory.
		/// </summary>
		/// <returns>List of all entities.</returns>
		public IEnumerable<T> Get() => Entities.Values;

		/// <summary>
		/// Default server entity.
		/// </summary>
		public T DefaultServer { get; set; }

		/// <summary>
		/// Creates new entity.
		/// </summary>
		/// <param name="component">The game component</param>
		/// <returns>Entity.</returns>
		public virtual T Create(IGameComponent component) => default(T);

		/// <summary>
		/// Gets entity from factory.
		/// </summary>
		/// <param name="component">The game component.</param>
		/// <returns>Entity.</returns>
		public T GetOrAdd(IGameComponent component)
		{
			if (Entities.TryGetValue(component, out T entity))
				return entity;

			if (component is ReferenceHub hb && hb.isLocalPlayer)
			{
				if (DefaultServer == null)
					DefaultServer = Create(component);
				return DefaultServer;
			}

			var ent = Create(component);
			Entities.Add(component, ent);
			return ent;
		}

		/// <summary>
		/// Gets entity from factory.
		/// </summary>
		/// <param name="component">The game component.</param>
		/// <returns>Entity.</returns>
		public T Get(IGameComponent component)
		{
			if (Entities.TryGetValue(component, out T entity))
				return entity;

			if (component is ReferenceHub hb && hb.isLocalPlayer)
			{
				if (DefaultServer == null)
					DefaultServer = Create(component);

				return DefaultServer;
			}

			return default(T);
		}

		/// <summary>
		/// Adds missing entity if not exists.
		/// </summary>
		/// <param name="component">The game component.</param>
		public void AddIfNotExists(IGameComponent component)
		{
			if (Entities.ContainsKey(component)) return;

			if (component is ReferenceHub hb && hb.isLocalPlayer)
				return;

			var ent = Create(component);
			Entities.Add(component, ent);
		}
	}
}