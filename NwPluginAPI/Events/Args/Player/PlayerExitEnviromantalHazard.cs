using Hazards;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerExitEnviromantalHazard : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerExitEnvironmentalHazard;

		/// <summary>
		/// Gets the player who is exiting the enviromental hazard.
		/// </summary>
		[EventArgument]
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the enviromental hazard which the player is exiting.
		/// </summary>
		[EventArgument]
		public EnvironmentalHazard EnvironmentalHazard { get; }

		public PlayerExitEnviromantalHazard(ReferenceHub hub, EnvironmentalHazard hazard)
		{
			Player = Core.Player.Get(hub);
			EnvironmentalHazard = hazard;
		}

		public PlayerExitEnviromantalHazard() { }
	}
}
