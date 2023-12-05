using PluginAPI.Enums;

namespace PluginAPI.Events
{
	public interface IEventArguments
	{
		ServerEventType BaseType { get; }
	}
}
