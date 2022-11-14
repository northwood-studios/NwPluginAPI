
namespace PluginAPI.Enums
{
	using System;

	/// <summary>
	/// Represents command types.
	/// </summary>
	[Flags]
	public enum CommandType : byte
	{
		Console = 1,
		GameConsole = 1 << 1,
		RemoteAdmin = 1 << 2
	}
}
