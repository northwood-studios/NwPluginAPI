using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using Hazards;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerEnterEnvironmentalHazard : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerEnterEnvironmentalHazard;

		/// <summary>
		/// Gets the player who is entering the enviromental hazard.
		/// </summary>
		[EventArgument]
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the enviromental hazard which the player is entering.
		/// </summary>
		[EventArgument]
		public EnvironmentalHazard EnvironmentalHazard { get; }

		public PlayerEnterEnvironmentalHazard(ReferenceHub hub, EnvironmentalHazard hazard)
		{
			Player = Core.Player.Get(hub);
			EnvironmentalHazard = hazard;
		}

		PlayerEnterEnvironmentalHazard() { }
	}
}
