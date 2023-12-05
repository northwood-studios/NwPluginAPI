using PlayerRoles;
using PluginAPI.Core;
using UnityEngine;

namespace PluginAPI.Roles
{
	public class BaseRole<TPlayer> where TPlayer : Player
	{
		public readonly TPlayer Player;
		public readonly PlayerRoleBase RoleBase;

		public RoleTypeId RoleId => RoleBase.RoleTypeId;

		public string RoleName => RoleBase.RoleName;

		public Color RoleColor => RoleBase.RoleColor;

		public Team RoleTeam => RoleBase.Team;

		public RoleChangeReason SpawnReason => RoleBase.ServerSpawnReason;

		public float ActiveTime => RoleBase.ActiveTime;

		public BaseRole(PlayerRoleBase roleBase)
		{
			RoleBase = roleBase;

			if (!roleBase.TryGetOwner(out ReferenceHub hub)) return;

			if (!Core.Player.TryGet(hub, out TPlayer plr)) return;
			Player = plr;
		}

		public virtual void OnUpdate() { }

		public virtual void OnFixedUpdate() { }

		public virtual void OnLateUpdate() { }

		public virtual void OnDestroy() { }
	}
}
