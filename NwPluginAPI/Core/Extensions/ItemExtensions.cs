namespace PluginAPI.Core
{
	/// <summary>
	/// Item-related extensions.
	/// </summary>
	public static class ItemExtensions
	{
		/// <summary>
		/// Check if an <see cref="T:ItemType">item</see> is an ammo.
		/// </summary>
		/// <param name="item">The item to be checked.</param>
		/// <returns>Returns whether the <see cref="T:ItemType" /> is an ammo or not.</returns>
		public static bool IsAmmo(this ItemType item)
		{
			return item is ItemType.Ammo9x19 or ItemType.Ammo12gauge or ItemType.Ammo44cal or ItemType.Ammo556x45 or ItemType.Ammo762x39;
		}

		/// <summary>
		/// Check if an <see cref="T:ItemType">item</see> is a weapon.
		/// </summary>
		/// <param name="type">The item to be checked.</param>
		/// <param name="checkMicro">Indicates whether the MicroHID item should be taken into account or not.</param>
		/// <param name="checkJailBird">Indicates whether the checkJailBird item should be taken into account or not.</param>
		/// <returns>Returns whether the <see cref="T:ItemType" /> is a weapon or not.</returns>
		public static bool IsWeapon(this ItemType type, bool checkMicro = true, bool checkJailBird = true)
		{
			if (type is ItemType.GunAK or ItemType.GunCOM15 or ItemType.GunCOM18 or ItemType.GunCom45 or ItemType.GunCrossvec or ItemType.GunLogicer or ItemType.GunRevolver or ItemType.GunShotgun or ItemType.GunE11SR or ItemType.GunFSP9)
				return true;
			if (checkMicro && type == ItemType.MicroHID)
			{
				return true;
			}
			return checkJailBird && type == ItemType.Jailbird;
		}
		/// <summary>
		/// Check if an <see cref="T:ItemType">item</see> is an SCP Item.
		/// </summary>
		/// <param name="type">The item to be checked.</param>
		/// <returns>Returns whether or not the <see cref="T:ItemType" /> is an SCP.</returns>
		public static bool IsScpItem(this ItemType type) => type is ItemType.SCP018 or ItemType.SCP500 or ItemType.SCP268 or ItemType.SCP207 or ItemType.SCP244a or ItemType.SCP244b or ItemType.SCP2176 or ItemType.SCP1853 or ItemType.SCP330 or ItemType.SCP1576 or ItemType.SCP2176;

		/// <summary>
		/// Check if an <see cref="T:ItemType">item</see> is a throwable item.
		/// </summary>
		/// <param name="type">The item to be checked.</param>
		/// <returns>Returns whether or not the <see cref="T:ItemType" /> is a throwable item.</returns>
		public static bool IsThrowable(this ItemType type) => type is ItemType.SCP018 or ItemType.GrenadeHE or ItemType.GrenadeFlash or ItemType.SCP2176;

		/// <summary>
		/// Check if an <see cref="T:ItemType">item</see> is a medical item.
		/// </summary>
		/// <param name="type">The item to be checked.</param>
		/// <param name="checkScp207">Indicates whether the Scp207 item should be taken into account or not.</param>
		/// <returns>Returns whether or not the <see cref="T:ItemType" /> is a medical item.</returns>
		public static bool IsMedical(this ItemType type , bool checkScp207 = false)
		{
			if (type is ItemType.Painkillers or ItemType.Medkit or ItemType.SCP500 or ItemType.Adrenaline)
			{
				return true;
			}

			return checkScp207 && type == ItemType.SCP207;
		}

		/// <summary>
		/// Check if a <see cref="T:ItemType" /> is an armor item.
		/// </summary>
		/// <param name="type">The item to be checked.</param>
		/// <returns>Returns whether or not the <see cref="T:ItemType" /> is an armor.</returns>
		public static bool IsArmor(this ItemType type) => type is ItemType.ArmorCombat or ItemType.ArmorHeavy or ItemType.ArmorLight;

		/// <summary>
		/// Check if an <see cref="T:ItemType">item</see> is a keycard.
		/// </summary>
		/// <param name="type">The item to be checked.</param>
		/// <returns>Returns whether or not the <see cref="T:ItemType" /> is a keycard.</returns>
		public static bool IsKeycard(this ItemType type) => type is ItemType.KeycardJanitor or ItemType.KeycardScientist or ItemType.KeycardResearchCoordinator or ItemType.KeycardZoneManager or ItemType.KeycardGuard or ItemType.KeycardNTFOfficer or ItemType.KeycardContainmentEngineer or ItemType.KeycardNTFLieutenant or ItemType.KeycardNTFCommander or ItemType.KeycardFacilityManager or ItemType.KeycardChaosInsurgency or ItemType.KeycardO5;

	}
}
