using Hazards;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI.Events.Args.Scp049
{
	public class Scp049MarkPlayer : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp049MarkPlayer;

		/// <summary>
		/// Gets the player playing as SCP-049.
		/// </summary>
		[EventArgument]
		public Core.Player Scp049 { get; }

		/// <summary>
		/// Gets the player marked.
		/// </summary>
		[EventArgument]
		public Core.Player Target { get; }

		/// <summary>
		/// Get or set mark duration.
		/// </summary>
		[EventArgument]
		public double Duration { get; set; }

		public Scp049MarkPlayer(ReferenceHub scp049, ReferenceHub target, double duration)
		{
			Scp049 = Core.Player.Get(scp049);
			Target = Core.Player.Get(target);
			Duration = duration;
		}

		Scp049MarkPlayer() { }
	}
}
