namespace PluginAPI.Core
{
	using System;
	using System.Collections.Generic;
	using Factories;
	using Interfaces;
	using Events;

	/// <summary>
	/// Manages factories for plugin system.
	/// </summary>
	public static class FactoryManager
    {
        internal static readonly Dictionary<Type, PlayerFactory> PlayerFactories = new Dictionary<Type, PlayerFactory>()
        {
            { typeof(EventManager), new PlayerFactory() }
        };

        internal static readonly Dictionary<Type, Type> FactoryTypes = new Dictionary<Type, Type>()
        {
            { typeof(Player), typeof(EventManager) },
        };

		/// <summary>
		/// Registers a new player factory.
		/// </summary>
		/// <param name="plugin">The plugin object.</param>
		/// <param name="factory">The factory.</param>
        public static void RegisterPlayerFactory(object plugin, PlayerFactory factory)
        {
            var type = plugin.GetType();

            if (PlayerFactories.ContainsKey(type)) return;

            FactoryTypes.Add(factory.BaseType, type);
            PlayerFactories.Add(type, factory);
        }

		/// <summary>
		/// Registers a new player factory.
		/// </summary>
		/// <param name="plugin">The plugin object.</param>
		public static void RegisterPlayerFactory<T>(object plugin) where T : PlayerFactory => RegisterPlayerFactory(plugin, Activator.CreateInstance<T>());

		/// <summary>
		/// Initializes the factory manager.
		/// </summary>
		public static void Init()
        {
            StaticUnityMethods.OnUpdate += OnUpdate;
            StaticUnityMethods.OnLateUpdate += OnLateUpdate;
            StaticUnityMethods.OnFixedUpdate += OnFixedUpdate;
            ReferenceHub.OnPlayerRemoved += RemovePlayer;
        }

        static void OnUpdate()
        {
            foreach (var factory in PlayerFactories.Values)
            {
                foreach(var entity in factory.Entities)
                {
					try
					{
						entity.Value.OnUpdate();
					}
					catch (Exception ex)
					{
						Log.Error($"Failed executing OnUpdate in {entity.Value.GetType().Name}, error\n {ex}");
					}
                }
            }
        }

        static void OnLateUpdate()
        {
            foreach (var factory in PlayerFactories.Values)
            {
                foreach (var entity in factory.Entities)
                {
                    try
                    {
                        entity.Value.OnLateUpdate();
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Failed executing OnLateUpdate in {entity.Value.GetType().Name}, error\n {ex}");
                    }
                }
            }
        }

        static void OnFixedUpdate()
        {
            foreach (var factory in PlayerFactories.Values)
            {
                foreach (var entity in factory.Entities)
                {
                    try
                    {
                        entity.Value.OnFixedUpdate();
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Failed executing OnFixedUpdate in {entity.Value.GetType().Name}, error\n {ex}");
                    }
                }
            }
        }

        static void RemovePlayer(ReferenceHub obj)
        {
            foreach(var factory in PlayerFactories.Values)
            {
	            if (!factory.Entities.TryGetValue(obj, out IPlayer plr))
		            continue;

	            try
	            {
		            plr.OnDestroy();
	            }
	            catch (Exception ex)
	            {
		            Log.Error($"Failed executing OnDestroy in {plr.GetType().Name}, error\n {ex}");
	            }

				if (plr is Player p)
					p.OnInternalDestroy();

				factory.Entities.Remove(obj);
            }
        }
    }
}
