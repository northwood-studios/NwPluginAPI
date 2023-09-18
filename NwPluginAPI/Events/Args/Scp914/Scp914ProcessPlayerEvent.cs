using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Scp914;
using UnityEngine;

namespace PluginAPI.Events.Args.Scp914
{
	public class Scp914ProcessPlayerEvent : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.Scp914ProcessPlayer;
		[EventArgument]
		public Core.Player Player { get; }
		[EventArgument]
		public Scp914KnobSetting KnobSetting { get; }
		[EventArgument]
		public Vector3 OutPosition { get; set; }

		public Scp914ProcessPlayerEvent(ReferenceHub hub, Scp914KnobSetting setting, Vector3 outPosition)
		{
			Player = Core.Player.Get(hub);
			KnobSetting = setting;
			OutPosition = outPosition;
		}

		Scp914ProcessPlayerEvent() { }
	}
}
