namespace PluginAPI.Commands
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using CommandSystem;
	using PluginAPI.Commands.Structs;
	using PluginAPI.Core;
	using PluginAPI.Core.Attributes;
	using RemoteAdmin;

	public class CommandsManager
	{
		private static readonly Dictionary<Type, object> CommandHandlers = new Dictionary<Type, object>();

		private static readonly Dictionary<Type, Dictionary<string, Command>> _registeredCommands = new Dictionary<Type, Dictionary<string, Command>>()
		{
			// Console commands.
			{ typeof(GameConsoleCommandHandler), new Dictionary<string, Command>() },
			// Game console commands.
			{ typeof(ClientCommandHandler), new Dictionary<string, Command>() },
			// Remote admin commands.
			{ typeof(RemoteAdminCommandHandler), new Dictionary<string, Command>() },
		};

		private static readonly Dictionary<Type, string> _commandHandlerToName = new Dictionary<Type, string>()
		{
			// Console commands.
			{ typeof(GameConsoleCommandHandler), "&2Console" },
			// Game console commands.
			{ typeof(ClientCommandHandler), "&3GameConsole" },
			// Remote admin commands.
			{ typeof(RemoteAdminCommandHandler), "&1RemoteAdmin" },
		};

		internal static bool RegisterCommand(PluginHandler handler, Type commandHandler, Type commandType)
		{
			if (!_registeredCommands.TryGetValue(commandHandler, out Dictionary<string, Command> commands))
			{
				Log.Error($"Command handler of type &6{commandHandler.FullName}&r in plugin &6{handler.PluginName}&r is not valid for command &6{commandType.Name}&r!");
				return false;
			}

			var command = new Command()
			{
				Object = (ICommand)Activator.CreateInstance(commandType),
				Plugin = handler,
			};

			if (command.Object == null)
			{
				Log.Error($"Failed creating instance for command &6{commandType.FullName}&r in plugin &6{handler.PluginName}&r, object is null!");
				return false;
			}

			if (commands.TryGetValue(command.Object.Command, out Command cmd))
			{
				Log.Error($"&7[{_commandHandlerToName[commandHandler]}&7]&r Command &6{command.Object.Command}&r is already registered in plugin &6{cmd.Plugin.PluginName}&r!");
				return false;
			}

			if (commandHandler == typeof(GameConsoleCommandHandler))
				GameCore.Console.singleton.ConsoleCommandHandler.RegisterCommand(command.Object);
			else if (commandHandler == typeof(RemoteAdminCommandHandler))
				CommandProcessor.RemoteAdminCommandHandler.RegisterCommand(command.Object);
			else if (commandHandler == typeof(ClientCommandHandler))
				QueryProcessor.DotCommandHandler.RegisterCommand(command.Object);

			commands.Add(command.Object.Command, command);
			Log.Info($"&7[{_commandHandlerToName[commandHandler]}&7]&r Registered command &6{command.Object.Command}&r in plugin &6{handler.PluginName}&r!");
			return true;
		}

		/// <summary>
		/// Registers comamnds in plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterCommands(object plugin)
		{
			Type type = plugin.GetType();
			RegisterEvents(type, plugin);
		}

		/// <summary>
		/// Registers comamnds in type of plugin.
		/// </summary>
		/// <param name="plugin">The object of plugin.</param>
		public static void RegisterCommands<T>(object plugin) where T : Type
		{
			if (!CommandHandlers.TryGetValue(typeof(T), out object handler))
			{
				handler = Activator.CreateInstance(typeof(T));
				CommandHandlers.Add(typeof(T), handler);
			}

			RegisterEvents(plugin.GetType(), handler);
		}

		static void RegisterEvents(Type pluginType, object handler)
		{
			foreach (var method in handler.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				var attributes = method.GetCustomAttributes<Attribute>();

				PluginCommand command = null;
				PluginCommandAliases commandAliases = null;

				foreach(var attribute in attributes)
				{
					switch (attribute)
					{
						case PluginCommand cmd:
							command = cmd;
							break;
						case PluginCommandAliases aliases:
							commandAliases = aliases;
							break;
					}
				}

				if (command == null) continue;

				if (method.ReturnType != typeof(CommandResponse))
				{
					Log.Error($"Command &6{command.Name}&r (&6{method.Name}&r) has wrong return type &6{method.ReturnType.Name}&r, required &6CommandResponse&r!");
					continue;
				}



			}
		}
	}
}
