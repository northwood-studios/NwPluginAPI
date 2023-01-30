using System.Linq;
using Interactables.Interobjects.DoorUtils;
using JetBrains.Annotations;
using PlayerRoles.PlayableScps.Scp096;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Scp096
{
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
			Door = DoorVariant.AllDoors.OrderBy(door => Vector3.Distance(door.transform.position, player.ReferenceHub.transform.position)).FirstOrDefault();
		}

		/// <summary>
		///  Gets the player who is playing SCP-096.
		/// </summary>
		public Player Player { get; }

		/// <summary>
		/// Gets SCP-096 role instance.
		/// </summary>
		public Scp096Role Scp096Role { get; }

		/// <summary>
		/// Gets the door where SCP-096 is trying not to cry, if there is one.
		/// </summary>
		[CanBeNull]
		public DoorVariant Door { get; }
	}
}