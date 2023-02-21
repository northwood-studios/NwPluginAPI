using PlayerRoles;
using PlayerStatsSystem;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Player
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.RagdollSpawn"/>.
	/// </summary>
	public class SpawningRagdollEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="SpawningRagdollEventArgs"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="ragdoll"></param>
		/// <param name="damageHandlerBase"></param>
		/// <param name="position"></param>
		/// <param name="rotation"></param>
		/// <param name="nickname"></param>
		/// <param name="roleType"></param>
		public SpawningRagdollEventArgs(IPlayer player, BasicRagdoll ragdoll, DamageHandlerBase damageHandlerBase,
			Vector3 position, Quaternion rotation, string nickname, RoleTypeId roleType)
		{
			Player = (Core.Player)player;
			Ragdoll = ragdoll;
			DamageHandler = damageHandlerBase;
			Position = position;
			Rotation = rotation;
			Nickname = nickname;
			RoleType = roleType;
		}

		/// <summary>
		/// Gets the player owner of the ragdoll.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player ragdoll
		/// </summary>
		public BasicRagdoll Ragdoll { get; }

		/// <summary>
		/// Get or set ragdoll <see cref="DamageHandlerBase"/>.
		/// </summary>
		public DamageHandlerBase DamageHandler { get; set; }

		/// <summary>
		/// Get or set ragdoll spawn position.
		/// </summary>
		public Vector3 Position { get; set; }

		/// <summary>
		/// Get or set ragdoll spawn rotation.
		/// </summary>
		public Quaternion Rotation { get; set; }

		/// <summary>
		/// Get or set ragdoll nickname.
		/// </summary>
		public string Nickname { get; set; }

		/// <summary>
		/// Get or set ragdoll role type.
		/// </summary>
		public RoleTypeId RoleType { get; set; }
	}
}