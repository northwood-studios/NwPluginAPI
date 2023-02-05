using System.Linq;
using Interactables.Interobjects.DoorUtils;
using JetBrains.Annotations;
using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Doors;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Scp096
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp096TryNotCry"/>.
	/// </summary>
	public class TryNotCryEventArg
	{
		/// <summary>
		/// Initializes a new instance of <see cref="TryNotCryEventArg"/>.
		/// </summary>
		/// <param name="player">The player due to this event is executing</param>
		public TryNotCryEventArg(IPlayer player)
		{
			Player = (Player)player;
			Scp096Role = player.ReferenceHub.roleManager.CurrentRole as Scp096Role;
			Door = FacilityDoor.List.OrderBy(door => Vector3.Distance(door.Position, player.ReferenceHub.transform.position)).FirstOrDefault();
		}

		/// <summary>
		///  Gets the player who is playing SCP-096.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp096.Scp096Role"/> instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Gets the door where SCP-096 is trying not to cry, if there is one.
		/// </summary>
		[CanBeNull]
		public FacilityDoor Door { get; }
	}
}