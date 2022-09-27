namespace PluginAPI.Commands
{
	using System;
	using System.Collections.Generic;
	
	using CommandSystem;

	using PluginAPI.Core;
	using RemoteAdmin;

	public class CommandsManager
	{
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
	}
}
