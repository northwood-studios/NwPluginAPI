namespace PluginAPI.Core.Factories
{
	using Interfaces;
	using System;

	public class PlayerFactory : Factory<IPlayer>
    {
        public virtual Type BaseType { get; } = typeof(Player);

        public override IPlayer Create(IGameComponent component)
        {
	        return ReferenceEquals(component, ReferenceHub.HostHub) ? new Server(component) : new Player(component);
        }
    }
}
