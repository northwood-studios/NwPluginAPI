namespace PluginAPI.Core.Factories
{
	using PluginAPI.Core.Interfaces;
	using System;

	public class PlayerFactory : Factory<IPlayer>
    {
        public virtual Type BaseType { get; } = typeof(Player);

        public override IPlayer Create(IGameComponent component)
        {
            if (component == (IGameComponent)ReferenceHub.HostHub)
                return new Server(component);

            return new Player(component);
        }
    }
}
