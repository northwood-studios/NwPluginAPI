using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using UnityEngine.Playables;

namespace PluginAPI.Events.EventArgs.Scp096
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp096AddingTarget"/>.
	/// </summary>
	public class AddingTargetEventArg
	{
		/// <summary>
		/// Initializes a new instance of <see cref="AddingTargetEventArg"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		/// <param name="target">The player who was will be added as a target of SCP-096.</param>
		/// <param name="isForLooking">The event is executed because SCP-096 was looked at or shot at.</param>
		public AddingTargetEventArg(IPlayer player, IPlayer target, bool isForLooking)
		{
			Player = (Core.Player)player;
			Scp096Role = Player.RoleBase as Scp096Role;
			Target = (Core.Player)target;
			IsForLook = isForLooking;
		}

		/// <summary>
		/// Gets player playing SCP-096.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player who is a new target.
		/// </summary>
		public Core.Player Target { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp096.Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Gets whether the event is executed because SCP-096 was looked at or fired at.
		/// </summary>
		public bool IsForLook { get; }
	}
}