using PlayerRoles.Ragdolls;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Core.Attributes;

namespace PluginAPI.Events
{
	public class RagdollSpawnEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.RagdollSpawn;
		[EventArgument]
		public Player Player { get; }
		[EventArgument]
		public IRagdollRole Ragdoll { get; }
		[EventArgument]
		public DamageHandlerBase DamageHandler { get; }

		public RagdollSpawnEvent(ReferenceHub hub, IRagdollRole ragdoll, DamageHandlerBase handler)
		{
			Player = Player.Get(hub);
			Ragdoll = ragdoll;
			DamageHandler = handler;
		}

		RagdollSpawnEvent() { }
	}
}
