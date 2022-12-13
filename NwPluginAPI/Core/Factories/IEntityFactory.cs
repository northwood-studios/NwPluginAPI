namespace PluginAPI.Core.Factories
{
	using Interfaces;
	using System.Collections.Generic;

	/// <summary>
	/// Defines basic factory features.
	/// </summary>
	/// <remarks>See https://www.tutorialspoint.com/design_pattern/factory_pattern.htm for more info </remarks>
	/// <typeparam name="TEntity">The entity to create.</typeparam>
	public interface IEntityFactory<TEntity> where TEntity : IEntity
    {
	    TEntity Create(IGameComponent component);
        TEntity GetOrAdd(IGameComponent component);
		void AddIfNotExists(IGameComponent component);
        IEnumerable<TEntity> Get();
    }
}
