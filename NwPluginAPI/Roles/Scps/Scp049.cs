using PlayerRoles.PlayableScps.Scp049;
using PluginAPI.Core;
using static PlayerRoles.PlayableScps.Scp049.Scp049AudioPlayer;

namespace PluginAPI.Roles.Scps
{
	public class Scp049<TPlayer> : BaseScp<TPlayer> where TPlayer : Player
	{
		public readonly new Scp049Role RoleBase;

		public readonly Scp049SenseAbility SenseAbility;

		private TPlayer _currentTarget;

		public TPlayer Target
		{
			get
			{
				if (_currentTarget?.ReferenceHub != SenseAbility.Target)
					_currentTarget = SenseAbility.HasTarget ? Core.Player.Get<TPlayer>(SenseAbility.Target) : null;

				return _currentTarget;
			}
		}

		public Scp049(Scp049Role role) : base(role)
		{
			RoleBase = role;
			RoleBase.SubroutineModule.TryGetSubroutine(out SenseAbility);
		}

		public virtual bool ReceiveSound(ref SoundType type) => true;

		public virtual bool CallZombies(ref float duration) => true;

		public virtual bool AttackPlayer(TPlayer target) => true;

		public virtual bool ChasePlayer(TPlayer target) => true;

		public virtual bool InfectPlayer(TPlayer target) => true;
	}
}
