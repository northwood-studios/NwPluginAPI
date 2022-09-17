namespace PluginAPI.Core
{
	/// <summary>
	/// Player info.
	/// </summary>
	public class PlayerInfo
	{
		private readonly Player _player;

		/// <summary>
		/// Constructor for player info.
		/// </summary>
		/// <param name="plr">The player.</param>
		public PlayerInfo(Player plr) => _player = plr;

		/// <summary>
		/// Gets or sets if player nickname is hidden in player info.
		/// </summary>
		public bool IsNicknameHidden
		{
			get => _player.ReferenceHub.nicknameSync.ShownPlayerInfo.HasFlag(PlayerInfoArea.Nickname);
			set
			{
				if (value)
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Nickname;
				else
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Nickname;
			}
		}

		/// <summary>
		/// Gets or sets if player badge is hidden in player info.
		/// </summary>
		public bool IsBadgeHidden
		{
			get => _player.ReferenceHub.nicknameSync.ShownPlayerInfo.HasFlag(PlayerInfoArea.Badge);
			set
			{
				if (value)
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Badge;
				else
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Badge;
			}
		}

		/// <summary>
		/// Gets or sets if player custom info is hidden in player info.
		/// </summary>
		public bool IsCustomInfoHidden
		{
			get => _player.ReferenceHub.nicknameSync.ShownPlayerInfo.HasFlag(PlayerInfoArea.CustomInfo);
			set
			{
				if (value)
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.CustomInfo;
				else
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.CustomInfo;
			}
		}

		/// <summary>
		/// Gets or sets if player power status is hidden in player info.
		/// </summary>
		public bool IsPowerStatusHidden
		{
			get => _player.ReferenceHub.nicknameSync.ShownPlayerInfo.HasFlag(PlayerInfoArea.PowerStatus);
			set
			{
				if (value)
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.PowerStatus;
				else
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.PowerStatus;
			}
		}

		/// <summary>
		/// Gets or sets if player role is hidden in player info.
		/// </summary>
		public bool IsRoleHidden
		{
			get => _player.ReferenceHub.nicknameSync.ShownPlayerInfo.HasFlag(PlayerInfoArea.Role);
			set
			{
				if (value)
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Role;
				else
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Role;
			}
		}

		/// <summary>
		/// Gets or sets if player unit name is hidden in player info.
		/// </summary>
		public bool IsUnitNameHidden
		{
			get => _player.ReferenceHub.nicknameSync.ShownPlayerInfo.HasFlag(PlayerInfoArea.UnitName);
			set
			{
				if (value)
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.UnitName;
				else
					_player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.UnitName;
			}
		}
	}
}
