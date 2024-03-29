using CustomPlayerEffects;

using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class PlayerReceiveEffectEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerReceiveEffect;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public StatusEffectBase Effect { get; }
		[EventArgument]
		public byte Intensity { get; set; }
		[EventArgument]
		public float Duration { get; set; }

		public PlayerReceiveEffectEvent(ReferenceHub hub, StatusEffectBase effect, byte intensity, float duration)
		{
			Player = Player.Get(hub);
			Effect = effect;
			Intensity = intensity;
			Duration = duration;
		}

		PlayerReceiveEffectEvent() { }
	}
}
