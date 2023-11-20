using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Scp0492
{
	public class Scp0492ConsumeCorpse : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp0492ConsumeCorpse;

		/// <summary>
		/// Gets the player who is playing as SCP-049-2.
		/// </summary>
		[EventArgument]
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the corpse consumed.
		/// </summary>
		[EventArgument]
		public BasicRagdoll CorpseConsumed { get; }

		/// <summary>
		/// Gets or sets the amount of healing for consuming a corpse.
		/// </summary>
		[EventArgument]
		public float Heal { get; set; }

		public Scp0492ConsumeCorpse(ReferenceHub zombie, BasicRagdoll corpseConsumed, float healAmount)
		{
			Player = Core.Player.Get(zombie);
			CorpseConsumed = corpseConsumed;
			Heal = healAmount;
		}

		Scp0492ConsumeCorpse() { }
	}
}