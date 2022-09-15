
namespace PluginAPI.Enums
{
	using System;

	/// <summary>
	/// Command types.
	/// </summary>
	[Flags]
	public enum CommandType
	{
		Console,
		GameConsole,
		RemoteAdmin
	}
}
