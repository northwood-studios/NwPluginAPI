namespace PluginAPI.Core.Factories
{
	using Interfaces;
	using System.Collections.Generic;

	public interface IEntityFactory<TEntity> where TEntity : IEntity
    {
        TEntity Create(IGameComponent component);
        TEntity GetOrAdd(IGameComponent component);
        IEnumerable<TEntity> Get();
    }
}
