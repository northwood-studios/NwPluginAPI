namespace PluginAPI.Core
{
	using System;
	using System.Collections.Generic;
	using Factories;
	using Interfaces;
	using Events;

	/// <summary>
	/// Factory manager for plugin system.
	/// </summary>
	public static class FactoryManager
    {
        internal static readonly Dictionary<Type, PlayerFactory> PlayerFactories = new Dictionary<Type, PlayerFactory>()
        {
            { typeof(EventManager), new PlayerFactory() }
        };

        internal static readonly Dictionary<Type, Type> FactoryTypes = new Dictionary<Type, Type>()
        {
            { typeof(PlayerFactory), typeof(EventManager) },
        };

		/// <summary>
		/// Registers new player factory.
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
		/// Initializes factory manager.
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
                    entity.Value.OnUpdate();
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
		            PlayerSharedStorage.DestroyStorage(plr);
		            plr.OnDestroy();
	            }
	            catch (Exception ex)
	            {
		            Log.Error($"Failed executing OnDestroy in {plr.GetType().Name}, error\n {ex}");
	            }
	            factory.Entities.Remove(obj);
            }
        }
    }
}
