using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI.Events.Args.Scp049
{
	public class Scp049LoseMarkedPlayer : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp049LosingPlayer;

		/// <summary>
		/// Gets the player who is playing as SCP-049.
		/// </summary>
		[EventArgument]
		public Core.Player Scp049 { get; }

		/// <summary>
		/// Gets the player who escaped from SCP-049.
		/// </summary>
		[EventArgument]
		public Core.Player Target { get; }

		/// <summary>
		/// Get or set the cooldown for losing a target.
		/// </summary>
		[EventArgument]
		public double Cooldown { get; set; } 

		public Scp049LoseMarkedPlayer(ReferenceHub scp049, ReferenceHub target)
		{
			Scp049 = Core.Player.Get(scp049);
			Target = Core.Player.Get(target);
		}
	}
}
