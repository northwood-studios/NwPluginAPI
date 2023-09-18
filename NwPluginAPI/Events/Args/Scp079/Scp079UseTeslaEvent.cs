using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079UseTeslaEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079UseTesla;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public TeslaGate Tesla { get; }

		public Scp079UseTeslaEvent(ReferenceHub hub, TeslaGate tesla)
		{
			Player = Core.Player.Get(hub);
			Tesla = tesla;
		}

		Scp079UseTeslaEvent() { }
	}
}
