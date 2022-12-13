namespace PluginAPI.Core.Factories
{
	using Interfaces;
	using System;

	/// <summary>
	/// A factory to create <see cref="IPlayer"/>'s.
	/// </summary>
	public class PlayerFactory : Factory<IPlayer>
    {
        public virtual Type BaseType { get; } = typeof(Player);

        /// <summary>
        /// Creates a new <see cref="IPlayer"/> instance.
        /// </summary>
        /// <param name="component">The <see cref="IGameComponent"/>.</param>
        /// <returns>The created <see cref="IPlayer"/>.</returns>
        public override IPlayer Create(IGameComponent component) => new Player(component);
	}
}
