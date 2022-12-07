namespace PluginAPI.Core
{
	using System;
	using System.Reflection;
	using Enums;
	using GameCore;
	using PluginAPI.Loader;

	/// <summary>
	/// Logger for plugin system.
	/// </summary>
	public static class Log
	{
		/// <summary>
		/// Whether or not to disable custom colors from log messages.
		/// </summary>
		public static bool DisableBetterColors;

		/// <summary>
		/// Whether or not its running in the unity editor.
		/// </summary>
		public static bool UnityEditor;

		/// <summary>
		/// Whether or not to enable debug mode in logs.
		/// </summary>
		public static bool DebugMode => ConfigFile.ServerConfig.GetBool("pluginapi_debug");

		/// <summary>
		/// Sends a debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="prefix">The prefix of message.</param>
		public static void Debug(string message, string prefix = null)
		{
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			if (callingAssembly == AssemblyLoader.MainAssembly && !DebugMode) return;

			ConsoleWrite(callingAssembly, prefix, LogType.Debug, message);
		}

		/// <summary>
		/// Sends a debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="debugEnabled">If debug message should be send.</param>
		/// <param name="prefix">The prefix of message.</param>
		public static void Debug(string message, bool debugEnabled, string prefix = null)
		{
			if (debugEnabled) Debug(message, prefix);
		}

		/// <summary>
		/// Sends a info message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="prefix">The prefix of message.</param>
		public static void Info(string message, string prefix = null) => ConsoleWrite(Assembly.GetCallingAssembly(), prefix, LogType.Info, message);

		/// <summary>
		/// Sends a warning message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="prefix">The prefix of message.</param>
		public static void Warning(string message, string prefix = null) => ConsoleWrite(Assembly.GetCallingAssembly(), prefix, LogType.Warning, message);

		/// <summary>
		/// Sends a error message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="prefix">The prefix of message.</param>
		public static void Error(string message, string prefix = null) => ConsoleWrite(Assembly.GetCallingAssembly(), prefix, LogType.Error, message);

		/// <summary>
		/// Sends a raw message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="prefix">The prefix of message.</param>
		public static void Raw(string message, string prefix = null) => ConsoleWrite(Assembly.GetCallingAssembly(), prefix, LogType.Raw, message);

		static string EndTag(ref string currentTag)
		{
			string saveTag = currentTag;
			currentTag = string.Empty;

			return $"</{saveTag}>";
		}

		/// <summary>
		/// Converts a raw message with color tags to formatted message.
		/// </summary>
		/// <param name="message">The raw message.</param>
		/// <param name="defaultColor">The default color of message.</param>
		/// <param name="unityRichText">If its unity richtext or ansi colors.</param>
		/// <returns>Formatted message with colors.</returns>
		public static string FormatText(string message, string defaultColor = null, bool unityRichText = false)
		{
			bool isPrefix = false;
			char escapeChar = (char) 27;
			string newText = string.Empty;
			string lastTag = string.Empty;

			if (defaultColor != null)
				defaultColor = FormatText($"&{defaultColor}", null, unityRichText);

			for (int x = 0; x < message.Length; x++)
			{
				if (message[x] == '&' && !isPrefix)
				{
					isPrefix = true;
					continue;
				}
				else if (isPrefix)
				{
					if (DisableBetterColors)
					{
						isPrefix = false;
						continue;
					}

					switch (message[x])
					{
						//Black
						case '0':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=black>" : $"{escapeChar}[30m";
							lastTag = "color";
							break;
						//Red
						case '1':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=red>" : $"{escapeChar}[31m";
							lastTag = "color";
							break;
						//Green
						case '2':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=green>" : $"{escapeChar}[32m";
							lastTag = "color";
							break;
						//Yellow
						case '3':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=yellow>" : $"{escapeChar}[33m";
							lastTag = "color";
							break;
						//Blue
						case '4':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=blue>" : $"{escapeChar}[34m";
							lastTag = "color";
							break;
						//Purple
						case '5':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=purple>" : $"{escapeChar}[35m";
							lastTag = "color";
							break;
						//Cyan
						case '6':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=cyan>" : $"{escapeChar}[36m";
							lastTag = "color";
							break;
						//White
						case '7':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<color=white>" : $"{escapeChar}[37m";
							lastTag = "color";
							break;
						//Reset
						case 'r':
							if (unityRichText && lastTag != string.Empty)
							{
								newText += EndTag(ref lastTag) + $"{defaultColor}";
								lastTag = "color";
								break;
							}

							if (!unityRichText)
								newText += $"{escapeChar}[0m";
							break;
						//Bold on
						case 'b':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<b>" : $"{escapeChar}[1m";
							break;
						//Bold off
						case 'B':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "</b>" : $"{escapeChar}[22m";
							break;
						//Italic on
						case 'o':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "<i>" : $"{escapeChar}[3m";
							break;
						//Italic off
						case 'O':
							if (unityRichText && lastTag != string.Empty)
								newText += EndTag(ref lastTag);

							newText += unityRichText ? "</i>" : $"{escapeChar}[23m";
							break;
						//Underline on
						case 'n':
							if (unityRichText) break;

							newText += $"{escapeChar}[4m";
							break;
						//Underline off
						case 'N':
							if (unityRichText) break;

							newText += $"{escapeChar}[24m";
							break;
						//Strikethrough on 
						case 'm':
							if (unityRichText) break;

							newText += $"{escapeChar}[9m";
							break;
						//Strikethrough off
						case 'M':
							if (unityRichText) break;

							newText += $"{escapeChar}[29m";
							break;
					}
					isPrefix = false;
					continue;
				}
				newText += message[x];

				if (unityRichText && x == message.Length -1 && lastTag != string.Empty)
					newText += EndTag(ref lastTag);
			}

			return newText;
		}

		private static void ConsoleWrite(Assembly assembly, string prefix, LogType type, string message)
		{
			if (string.IsNullOrEmpty(prefix) && type != LogType.Raw)
				prefix = assembly == AssemblyLoader.MainAssembly ? "PluginAPI" : assembly.GetName().Name;

			switch (type)
			{
				case LogType.Info:
					if (UnityEditor)
						UnityEngine.Debug.Log(FormatText($"&7[&b&6{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7", true));
					else
						ServerConsole.AddLog(FormatText($"&7[&b&6{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7"), ConsoleColor.Cyan);
					break;
				case LogType.Warning:
					if (UnityEditor)
						UnityEngine.Debug.LogWarning(FormatText($"&7[&b&3{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7", true));
					else
						ServerConsole.AddLog(FormatText($"&7[&b&3{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7"), ConsoleColor.DarkYellow);
					break;
				case LogType.Error:
					if (UnityEditor)
						UnityEngine.Debug.LogError(FormatText($"&7[&b&1{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7", true));
					else
						ServerConsole.AddLog(FormatText($"&7[&b&1{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7"), ConsoleColor.Red);
					break;
				case LogType.Debug:
					if (UnityEditor)
						UnityEngine.Debug.Log(FormatText($"&7[&b&5{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7", true));
					else
						ServerConsole.AddLog(FormatText($"&7[&b&5{type}&B&7] &7[&b&2{prefix}&B&7]&r {message}", "7"), ConsoleColor.Magenta);
					break;
				case LogType.Raw:
					if (UnityEditor)
						UnityEngine.Debug.Log(FormatText($"{(!string.IsNullOrEmpty(prefix) ? $"&7[&b&2{prefix}&B&7] " : "")}" + message, "7", true));
					else
						ServerConsole.AddLog(FormatText($"{(!string.IsNullOrEmpty(prefix) ? $"&7[&b&2{prefix}&B&7] " : "")}" + message, "7"));
					break;
			}
		}
	}
}
