using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI.Events.Args.Scp049
{
	public class Scp049CallProgeny : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp049CallProgeny;

		/// <summary>
		/// Gets the player who is playing as SCP-049.
		/// </summary>
		[EventArgument]
		public Core.Player Scp049 { get; }

		/// <summary>
		/// Gets or set the duration of the ability.
		/// </summary>
		[EventArgument]
		public double Duration { get; set; }

		public Scp049CallProgeny(ReferenceHub scp049, double duration)
		{
			Scp049 = Core.Player.Get(scp049);
			Duration = duration;
		}

		Scp049CallProgeny() { }
	}
}
