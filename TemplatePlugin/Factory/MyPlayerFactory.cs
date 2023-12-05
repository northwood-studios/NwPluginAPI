namespace TemplatePlugin.Factory
{
	using System;
	using PluginAPI.Core;
	using PluginAPI.Core.Factories;
	using PluginAPI.Core.Interfaces;

	/// <summary>
	/// A factory for <see cref="MyPlayer"/>s.
	/// </summary>
	public class MyPlayerFactory : PlayerFactory
	{
		public override Type BaseType { get; } = typeof(MyPlayer);

		public override Player Create(IGameComponent component)
		{
			if (component is ReferenceHub hub && hub.isLocalPlayer)
				return new Server(hub);

			return new MyPlayer(component);
		}
	}
}