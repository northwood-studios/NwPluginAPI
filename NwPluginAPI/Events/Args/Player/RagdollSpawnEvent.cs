using PlayerRoles;
using PlayerStatsSystem;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class RagdollSpawnEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RagdollSpawn;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public IRagdollRole Ragdoll { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }

		public RagdollSpawnEvent(ReferenceHub hub, IRagdollRole ragdoll, DamageHandlerBase handler)
		{
			Player = Core.Player.Get(hub);
			Ragdoll = ragdoll;
			DamageHandler = handler;
		}

		RagdollSpawnEvent() { }
	}
}
