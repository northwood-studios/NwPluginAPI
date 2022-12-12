namespace PluginAPI.Commands
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using CommandSystem;

	using PluginAPI.Core;
	using RemoteAdmin;

	/// <summary>
	/// Manages commands.
	/// </summary>
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

		/// <summary>
		/// Registers a command.
		/// </summary>
		/// <param name="handler">The plugin handler.</param>
		/// <param name="commandHandler">The command handler.</param>
		/// <param name="commandType">The command type.</param>
		/// <returns></returns>
		internal static bool RegisterCommand(PluginHandler handler, Type commandHandler, Type commandType)
		{
			if (!_registeredCommands.TryGetValue(commandHandler, out Dictionary<string, Command> commands))
			{
				Log.Error($"Command handler of type &6{commandHandler.FullName}&r in plugin &6{handler.PluginName}&r is not valid for command &6{commandType.Name}&r!");
				return false;
			}

			ICommand activatedCommand = (ICommand)Activator.CreateInstance(commandType);
			var command = new Command()
			{
				Object = activatedCommand,
				Plugin = handler,
			};

			if (typeof(ParentCommand).IsAssignableFrom(commandType))
			{
				if (!_registeredCommands.ContainsKey(commandType))
				{
					_registeredCommands.Add(commandType, new Dictionary<string, Command>());
					Log.Info("Registered parent command for: "+commandType.Name);
				}
				if (!_commandHandlerToName.ContainsKey(commandType))
				{
					// give it a name so that the output isn't shit.
					_commandHandlerToName.Add(commandType, activatedCommand.Command);
				}
			}

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
			else
			{
				// this is not pretty.
				Log.Info($"Attempting to register subcommand {activatedCommand.Command} for custom handler / parent command: {commandHandler.Name}");
				foreach (var attributeData in commandHandler.GetCustomAttributesData())
				{
					if (attributeData.AttributeType != typeof(CommandHandlerAttribute)) continue;

					// the command we're currently registering references another command as its handler
					// we need to find it, and get its handler see where it was registered
					// then we'll register our current command under its parent so it can be called.
					Type parentCommandHandlerType = (Type)attributeData.ConstructorArguments[0].Value;
					if (parentCommandHandlerType != null)
					{
						Dictionary<string, Command> parentHandlerRegisteredCommands = _registeredCommands[parentCommandHandlerType];
						// the type referenced in the CommandHandler is a command in itself, it SHOULD extend "ParentCommand".
						Command parentCommandInstance = parentHandlerRegisteredCommands.Values.FirstOrDefault(x => x.Object.GetType() == commandHandler);
						ParentCommand parentCommand = parentCommandInstance.Object as ParentCommand;
						parentCommand?.RegisterCommand(activatedCommand);
					}
				}
			}

			commands.Add(command.Object.Command, command);
			Log.Debug($"&7[{_commandHandlerToName[commandHandler]}&7]&r Registered command &6{command.Object.Command}&r in plugin &6{handler.PluginName}&r!", Log.DebugMode);
			return true;
		}
	}
}
