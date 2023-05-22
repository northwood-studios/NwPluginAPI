using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using PlayerRoles.PlayableScps.Scp079;

namespace PluginAPI.Events.Args.Scp079
{
	public class Scp079GainExperienceEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp079GainExperience;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public int Amount { get; set; }
		[EventArgument]
		public Scp079HudTranslation Reason { get; set; }

		public Scp079GainExperienceEvent(ReferenceHub hub, int amount, Scp079HudTranslation reason)
		{
			Player = Core.Player.Get(hub);
			Amount = amount;
			Reason = reason;
		}

		Scp079GainExperienceEvent() { }
	}
}
