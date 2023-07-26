using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI.Core.Extensions
{
	public static class ItemExtensions
	{
		public static bool IsAmmo(this ItemType type)
		{
			switch (type)
			{
				case ItemType.Ammo12gauge:
				case ItemType.Ammo44cal:
				case ItemType.Ammo556x45:
				case ItemType.Ammo762x39:
				case ItemType.Ammo9x19:
					return true;
			}
			return false;
		}

		/// <summary>
		/// Gets if the <see cref="ItemType"/> is a fire Firearm.
		/// </summary>
		/// <param name="type">The <see cref="ItemType"/> to check</param>
		/// <param name="countSpecialWeapons">if is <see langword="true"/>, jailbird and microhid count as firearms</param>
		/// <returns>Returns whether or not the <see cref="ItemType"/> is a firearm.</returns>
		public static bool IsFirearm(this ItemType type, bool countSpecialWeapons = false)
		{
			switch (type)
			{
				case ItemType.GunAK:
				case ItemType.GunCOM15:
				case ItemType.GunCOM18:
				case ItemType.GunCom45:
				case ItemType.GunCrossvec:
				case ItemType.GunLogicer:
				case ItemType.GunRevolver:
				case ItemType.GunShotgun:
				case ItemType.GunE11SR:
				case ItemType.GunFSP9:
					return true;
				case ItemType.Jailbird:
				case ItemType.MicroHID:
					{
						if (countSpecialWeapons)
							return true;
						return false;
					}
			}
			return false;
		}

		/// <summary>
		/// Gets if the <see cref="ItemType"/> is a medical item.
		/// </summary>
		/// <param name="type"></param>
		/// <returns>Returns whether or not the <see cref="ItemType"/> is a medical item.</returns>
		public static bool IsMedical(this ItemType type) => type is ItemType.Medkit or ItemType.Adrenaline or ItemType.Painkillers or ItemType.SCP500;

		/// <summary>
		/// Gets if the <see cref="ItemType"/> is a utility item.
		/// </summary>
		/// <param name="type"></param>
		/// <returns>Returns whether or not the <see cref="ItemType"/> is a utility item.</returns>
		public static bool IsUtility(this ItemType type) => type is ItemType.Radio or ItemType.Flashlight;

		/// <summary>
		/// Gets if the <see cref="ItemType"/> is a armor item.
		/// </summary>
		/// <param name="type"></param>
		/// <returns>Returns whether or not the <see cref="ItemType"/> is a armor item.</returns>
		public static bool IsArmor(this ItemType type) => type is ItemType.ArmorCombat or ItemType.ArmorHeavy or ItemType.ArmorLight;

		/// <summary>
		/// Checks if the specified <see cref="ItemType"/> is a throwable item.
		/// </summary>
		/// <param name="type">The <see cref="ItemType"/> to be checked.</param>
		/// <returns>
		/// Returns whether or not the <see cref="ItemType"/> is a throwable item.
		/// </returns>
		public static bool IsThrowable(this ItemType type) => type is ItemType.SCP018 or ItemType.GrenadeFlash or ItemType.GrenadeHE or ItemType.SCP2176;

		/// <summary>
		/// Gets if the <see cref="ItemType"/> is a keycard item.
		/// </summary>
		/// <param name="type"></param>
		/// <returns>Returns whether or not the <see cref="ItemType"/> is a keycard item.</returns>
		public static bool IsKeycard(this ItemType type)
		{
			switch (type)
			{
				case ItemType.KeycardChaosInsurgency:
				case ItemType.KeycardContainmentEngineer:
				case ItemType.KeycardFacilityManager:
				case ItemType.KeycardGuard:
				case ItemType.KeycardJanitor:
				case ItemType.KeycardNTFCommander:
				case ItemType.KeycardNTFLieutenant:
				case ItemType.KeycardNTFOfficer:
				case ItemType.KeycardO5:
				case ItemType.KeycardResearchCoordinator:
				case ItemType.KeycardScientist:
				case ItemType.KeycardZoneManager:
					return true;
			}
			return false;
		}

		/// <summary>
		/// Gets a <see cref="ItemBase"/> of a <see cref="ItemType"/>.
		/// </summary>
		/// <param name="type"></param>
		/// <returns>The <see cref="ItemBase"/> or <see langword="null"/> if not found.</returns>
		public static ItemBase GetItemBase(this ItemType type)
		{
			if(InventoryItemLoader.TryGetItem(type, out ItemBase itembase))
				return itembase;

			return null;
		}

		/// <summary>
		/// Gets a random attachments code for the specified <see cref="ItemType"/> representing a set of random attachments for a firearm.
		/// </summary>
		/// <param name="firearm">The <see cref="ItemType"/> of the firearm to be searched for random attachments.</param>
		/// <returns>The attachments code, a <see cref="uint"/> value representing a random set of attachments for the firearm.</returns>
		public static uint GetRandomAttachments(this ItemType firearm)
		{
			if (!firearm.IsFirearm())
				throw new ArgumentException("The provided argument is not a valid firearm.", nameof(firearm));

			return AttachmentsUtils.GetRandomAttachmentsCode(firearm);
		}

		/// <summary>
		/// Applies the specified attachments to the given <see cref="Firearm"/>.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> to which the attachments will be applied.</param>
		/// <param name="attachmentCode">The attachments code representing the set of attachments to apply.</param>
		public static void ApllyAttachments(this Firearm firearm, uint attachmentCode)
		{
			if (firearm == null)
				throw new ArgumentNullException(nameof(Firearm), "Firearm is null");

			firearm.ApplyAttachmentsCode(attachmentCode, true);

			FirearmStatusFlags firearmStatusFlags = FirearmStatusFlags.MagazineInserted;
			if (firearm.HasAdvantageFlag(AttachmentDescriptiveAdvantages.Flashlight))
			{
				firearmStatusFlags |= FirearmStatusFlags.FlashlightEnabled;
			}
			firearm.Status = new(firearm.AmmoManagerModule.MaxAmmo, firearmStatusFlags, firearm.GetCurrentAttachmentsCode());
		}

		/// <summary>
		/// Applies a set of random attachments to the specified <see cref="Firearm"/>.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> to which random attachments will be applied.</param>
		/// <exception cref="ArgumentNullException">Thrown if the <paramref name="firearm"/> is null.</exception>
		public static void ApllyRandomAttachments(this Firearm firearm)
		{
			if (firearm == null)
				throw new ArgumentNullException(nameof(Firearm), "Firearm is null");

			firearm.ApplyAttachmentsCode(AttachmentsUtils.GetRandomAttachmentsCode(firearm.ItemTypeId), true);

			FirearmStatusFlags firearmStatusFlags = FirearmStatusFlags.MagazineInserted;
			if (firearm.HasAdvantageFlag(AttachmentDescriptiveAdvantages.Flashlight))
			{
				firearmStatusFlags |= FirearmStatusFlags.FlashlightEnabled;
			}
			firearm.Status = new(firearm.AmmoManagerModule.MaxAmmo, firearmStatusFlags, firearm.GetCurrentAttachmentsCode());
		}

		/// <summary>
		/// Applies the preferences of a <see cref="Player"/>'s attachments to a given <see cref="Firearm"/>.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> to modify.</param>
		/// <param name="player">The <see cref="Player"/> whose attachments preferences are to be applied.</param>
		/// <param name="reloadWeapon">If this value is true, the weapon will be fully reloaded with ammunition when the attachment is applied.</param>
		/// <returns>Returns true if the weapon was modified with the attachments; otherwise, false.</returns>
		public static bool TryApplyAttachmentsPreferences(this Firearm firearm, Player player, bool reloadWeapon = false)
		{
			if(firearm == null)
				throw new ArgumentNullException(nameof(Firearm), "Firearm is null");

			if(AttachmentsServerHandler.PlayerPreferences.TryGetValue(player.ReferenceHub, out var prefs) && prefs.TryGetValue(firearm.ItemTypeId, out uint attachmentsCode))
			{
				firearm.ApplyAttachmentsCode(attachmentsCode, true);

				FirearmStatusFlags firearmStatusFlags = FirearmStatusFlags.MagazineInserted;
				if (firearm.HasAdvantageFlag(AttachmentDescriptiveAdvantages.Flashlight))
				{
					firearmStatusFlags |= FirearmStatusFlags.FlashlightEnabled;
				}

				if(reloadWeapon)
					firearm.Status = new(firearm.AmmoManagerModule.MaxAmmo, firearmStatusFlags, firearm.GetCurrentAttachmentsCode());
				else
					firearm.Status = new(0, firearmStatusFlags, firearm.GetCurrentAttachmentsCode());
				return true;
			}
			return false;
		}

	}
}
