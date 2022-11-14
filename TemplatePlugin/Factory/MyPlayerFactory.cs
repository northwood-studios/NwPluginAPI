﻿namespace TemplatePlugin.Factory
{
	using System;
	using PluginAPI.Core.Factories;
	using PluginAPI.Core.Interfaces;

	/// <summary>
	/// A factory 
	/// </summary>
	public class MyPlayerFactory : PlayerFactory
    {
        public override Type BaseType { get; } = typeof(MyPlayer);

		public override IPlayer Create(IGameComponent component) => new MyPlayer(component);
	}
}
