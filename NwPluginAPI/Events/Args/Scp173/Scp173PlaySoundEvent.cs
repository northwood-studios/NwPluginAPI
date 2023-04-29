using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;
using static PlayerRoles.PlayableScps.Scp173.Scp173AudioPlayer;

namespace PluginAPI.Events
{
	public class Scp173PlaySoundEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173PlaySound;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public Scp173SoundId SoundId { get; }

		public Scp173PlaySoundEvent(ReferenceHub hub, Scp173SoundId id)
		{
			Player = Player.Get(hub);
			SoundId = id;
		}

		Scp173PlaySoundEvent() { }
	}
}
