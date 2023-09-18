using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using static PlayerRoles.PlayableScps.Scp173.Scp173AudioPlayer;

namespace PluginAPI.Events.Args.Scp173
{
	public class Scp173PlaySoundEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp173PlaySound;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp173SoundId SoundId { get; }

		public Scp173PlaySoundEvent(ReferenceHub hub, Scp173SoundId id)
		{
			Player = Core.Player.Get(hub);
			SoundId = id;
		}

		Scp173PlaySoundEvent() { }
	}
}
