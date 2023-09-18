using CustomPlayerEffects;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerReceiveEffectEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerReceiveEffect;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public StatusEffectBase Effect { get; }
		[EventArgument]
		public byte Intensity { get; set; }
		[EventArgument]
		public float Duration { get; set; }

		public PlayerReceiveEffectEvent(ReferenceHub hub, StatusEffectBase effect, byte intensity, float duration)
		{
			Player = Core.Player.Get(hub);
			Effect = effect;
			Intensity = intensity;
			Duration = duration;
		}

		PlayerReceiveEffectEvent() { }
	}
}
