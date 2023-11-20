using Hazards;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace PluginAPI.Events.Args.Player
{
	public class PlayerStayOnEnvironmentalHazard : IEventArguments
	{
		public ServerEventType BaseType { get; } = ServerEventType.PlayerStayOnEnvironmentalHazard;

		/// <summary>
		/// Gets the player who is staying the enviromental hazard.
		/// </summary>
		[EventArgument]
		public Core.Player Player { get; }

		/// <summary>
		/// Gets the enviromental hazard which the player is staying.
		/// </summary>
		[EventArgument]
		public EnvironmentalHazard EnvironmentalHazard { get; }

		public PlayerStayOnEnvironmentalHazard(ReferenceHub hub, EnvironmentalHazard hazard)
		{
			Player = Core.Player.Get(hub);
			EnvironmentalHazard = hazard;
		}

		public PlayerStayOnEnvironmentalHazard() { }
	}
}
