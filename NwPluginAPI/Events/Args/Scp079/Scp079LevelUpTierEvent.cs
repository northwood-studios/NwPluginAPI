using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079LevelUpTierEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079LevelUpTier;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public int Tier { get; }

		public Scp079LevelUpTierEvent(ReferenceHub hub, int tier)
		{
			Player = Core.Player.Get(hub);
			Tier = tier;
		}

		Scp079LevelUpTierEvent() { }
	}
}
