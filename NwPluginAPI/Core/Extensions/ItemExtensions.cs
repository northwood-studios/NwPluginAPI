using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace PluginAPI.Core.Extensions
{
	public static class ItemExtensions
	{
		/// <summary>
		/// Checks if the current <see cref="ItemType"/> is ammunition.
		/// </summary>
		/// <param name="type">The ItemType value to check.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ItemType"/> is an ammunition; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAmmo(this ItemType type)
		{
			switch (type)
			{
				// List of ammunition
				case ItemType.Ammo12gauge:
				case ItemType.Ammo44cal:
				case ItemType.Ammo556x45:
				case ItemType.Ammo762x39:
				case ItemType.Ammo9x19:
					return true;
				// Default case: not an ammunition
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Checks if the current <see cref="ItemType"/> represents a firearm.
		/// </summary>
		/// <param name="type">The ItemType value to check.</param>
		/// <param name="countSpecialWeapons">
		/// A boolean parameter indicating whether to count special weapons (default is false).
		/// If set to true, special weapons like Jailbird and MicroHID are considered firearms; otherwise, they are not.
		/// </param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ItemType"/> is a firearm; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsFirearm(this ItemType type, bool countSpecialWeapons = false)
		{
			switch (type)
			{
				// List of firearm
				case ItemType.GunAK:
				case ItemType.GunCOM15:
				case ItemType.GunCOM18:
				case ItemType.GunCom45:
				case ItemType.GunCrossvec:
				case ItemType.GunLogicer:
				case ItemType.GunRevolver:
				case ItemType.GunShotgun:
				case ItemType.GunE11SR:
				case ItemType.GunFRMG0:
				case ItemType.GunA7:
				case ItemType.GunFSP9:
					return true;
				// Special cases (Jailbird and MicroHID) depend on the value of countSpecialWeapons
				case ItemType.Jailbird:
				case ItemType.MicroHID:
					return countSpecialWeapons;
				// Default case: not a firearm
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Checks if the current <see cref="ItemType"/> is an medical item.
		/// </summary>
		/// <param name="type">The ItemType value to check.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ItemType"/> is a medical item; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsMedical(this ItemType type) => type is ItemType.Medkit or ItemType.Adrenaline or ItemType.Painkillers or ItemType.SCP500;

		/// <summary>
		/// Checks if the current <see cref="ItemType"/> is an utility item.
		/// </summary>
		/// <param name="type">The ItemType value to check.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ItemType"/> is a utility item; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsUtility(this ItemType type) => type is ItemType.Radio or ItemType.Flashlight;

		/// <summary>
		/// Checks if the current <see cref="ItemType"/> is an armor item.
		/// </summary>
		/// <param name="type">The <see cref="ItemType"/> value to check.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ItemType"/> is an armor item; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsArmor(this ItemType type) => type is ItemType.ArmorCombat or ItemType.ArmorHeavy or ItemType.ArmorLight;

		/// <summary>
		/// Checks if the current <see cref="ItemType"/> represents is an throwable item.
		/// </summary>
		/// <param name="type">The ItemType value to check.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ItemType"/> is a throwable item; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsThrowable(this ItemType type) => type is ItemType.SCP018 or ItemType.GrenadeFlash or ItemType.GrenadeHE or ItemType.SCP2176;
		
		/// <summary>
		/// Checks if the current <see cref="ItemType"/> is an keycard.
		/// </summary>
		/// <param name="type">The ItemType value to check.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="ItemType"/> is a keycard; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsKeycard(this ItemType type)
		{
			switch (type)
			{
				// List of keycard
				case ItemType.KeycardChaosInsurgency:
				case ItemType.KeycardContainmentEngineer:
				case ItemType.KeycardFacilityManager:
				case ItemType.KeycardGuard:
				case ItemType.KeycardJanitor:
				case ItemType.KeycardMTFCaptain:
				case ItemType.KeycardMTFOperative:
				case ItemType.KeycardMTFPrivate:
				case ItemType.KeycardO5:
				case ItemType.KeycardResearchCoordinator:
				case ItemType.KeycardScientist:
				case ItemType.KeycardZoneManager:
					return true;
				// Default case: not a keycard
				default: 
					return false;
			}
		}

		/// <summary>
		/// Retrieves the <see cref="ItemBase"/> associated with the specified <see cref="ItemType"/>.
		/// </summary>
		/// <param name="type">The <see cref="ItemType"/> value for which to retrieve the <see cref="ItemBase"/>.</param>
		/// <returns>
		/// The <see cref="ItemBase"/> associated with the specified <paramref name="type"/> if found; otherwise, <c>null</c>.
		/// </returns>
		public static ItemBase GetItemBase(this ItemType type)
		{
			return InventoryItemLoader.TryGetItem(type, out ItemBase itemBase) ? itemBase : null;
		}

		/// <summary>
		/// Gets a random attachments code for the specified <see cref="ItemType"/> representing a firearm.
		/// </summary>
		/// <param name="firearm">The <see cref="ItemType"/> value representing the firearm.</param>
		/// <returns>
		/// A random attachments code for the specified firearm, or an exception if the provided
		/// argument is not a valid firearm.
		/// </returns>
		/// <exception cref="ArgumentException">
		/// Thrown when the provided argument is not a valid firearm.
		/// </exception>
		public static uint GetRandomAttachments(this ItemType firearm)
		{
			if (!firearm.IsFirearm())
				throw new ArgumentException("The provided argument is not a valid firearm.", nameof(firearm));

			return AttachmentsUtils.GetRandomAttachmentsCode(firearm);
		}

		/// <summary>
		/// Applies attachments to the specified <see cref="Firearm"/> using the provided attachments code.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> to which to apply the attachments.</param>
		/// <param name="attachmentCode">The attachments code to apply to the firearm.</param>
		/// <param name="enableFlashLight">If the weapon when applying attachments has a flashlight, do you want to turn it on; default is true</param>
		/// <exception cref="ArgumentNullException">
		/// Thrown when the provided <paramref name="firearm"/> is null.
		/// </exception>
		public static void ApplyAttachments(this Firearm firearm, uint attachmentCode, bool enableFlashLight = true)
		{
			if (firearm == null)
				throw new ArgumentNullException(nameof(firearm), "Firearm is null");

			firearm.ApplyAttachmentsCode(attachmentCode, true);

			var firearmStatusFlags = firearm.Status.Flags;
			
			if(!firearmStatusFlags.HasFlag(FirearmStatusFlags.MagazineInserted))
				firearmStatusFlags |= FirearmStatusFlags.MagazineInserted;
			
			if (firearm.HasAdvantageFlag(AttachmentDescriptiveAdvantages.Flashlight) && enableFlashLight)
			{
				firearmStatusFlags |= FirearmStatusFlags.FlashlightEnabled;
			}
			
			firearm.Status = new FirearmStatus(firearm.Status.Ammo, firearmStatusFlags, firearm.GetCurrentAttachmentsCode());
		}

		/// <summary>
		/// Applies a set of random attachments to the specified <see cref="Firearm"/>.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> to which random attachments will be applied.</param>
		/// <exception cref="ArgumentNullException">Thrown if the <paramref name="firearm"/> is null.</exception>
		public static void ApplyRandomAttachments(this Firearm firearm)
		{
			if (firearm == null)
				throw new ArgumentNullException(nameof(firearm), "Firearm is null");
			// Get a random attachments code
			var randomAttachments = GetRandomAttachments(firearm.ItemTypeId);
			
			// Apply the random attachments, preserving the flashlight status if it's enabled
			ApplyAttachments(firearm, randomAttachments, firearm.Status.Flags.HasFlag(FirearmStatusFlags.FlashlightEnabled));
		}
		
		/// <summary>
		/// Try to apply attachment to the specified <see cref="Firearm"/> based on a player's preferences.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> to which attachments preferences will be applied.</param>
		/// <param name="player">The <see cref="Player"/> whose preferences are used for attachments.</param>
		/// <param name="preserveAmmo">Optional. Indicates whether to preserve the current ammo when applying preferences (default is true).</param>
		/// <returns>
		/// <c>true</c> if attachment preferences were successfully applied; otherwise, <c>false</c>.
		/// </returns>
		public static bool TryApplyAttachmentsPreferences(this Firearm firearm, Player player, bool preserveAmmo = true)
		{
			if (firearm == null)
				return false;

			if(AttachmentsServerHandler.PlayerPreferences.TryGetValue(player.ReferenceHub, out var prefs) && prefs.TryGetValue(firearm.ItemTypeId, out uint attachmentsCode))
			{
				firearm.Status = preserveAmmo ? new FirearmStatus(firearm.Status.Ammo, firearm.Status.Flags, firearm.GetCurrentAttachmentsCode()) : new FirearmStatus(0, firearm.Status.Flags, firearm.GetCurrentAttachmentsCode());
				
				ApplyAttachments(firearm, attachmentsCode, firearm.Status.Flags.HasFlag(FirearmStatusFlags.FlashlightEnabled));
				return true;
			}
			return false;
		}

		/// <summary>
		/// Gets the maximum ammo capacity for the specified <see cref="Firearm"/>.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> for which to retrieve the maximum ammo capacity.</param>
		/// <returns>The maximum ammo capacity for the specified <paramref name="firearm"/>.</returns>
		public static byte GetMaxAmmo(this Firearm firearm)
		{
			return firearm == null ? (byte)0 : firearm.AmmoManagerModule.MaxAmmo;
		}

		/// <summary>
		/// Gets the maximum ammo capacity for the specified <see cref="ItemType"/>.
		/// </summary>
		/// <param name="type">The <see cref="ItemType"/> for which to retrieve the maximum ammo capacity.</param>
		/// <returns>The maximum ammo capacity for the specified <paramref name="type"/>. Returns 0 if the item is not a firearm.</returns>
		public static byte GetMaxAmmo(this ItemType type)
		{
			var baseItem = GetItemBase(type);
			
			return baseItem is not Firearm firearm ? (byte)0 : firearm.AmmoManagerModule.MaxAmmo;
		}

		/// <summary>
		/// Reloads the specified <see cref="Firearm"/> to its maximum ammo capacity while preserving attachments and status flags.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> to be reloaded.</param>
		/// <exception cref="ArgumentNullException">Thrown if the <paramref name="firearm"/> is null.</exception>
		public static void ReloadFirearm(this Firearm firearm)
		{
			if (firearm == null)
				throw new ArgumentNullException(nameof(firearm), "Firearm is null");

			// Create a new FirearmStatus with maximum ammo capacity while preserving attachments and status flags
			firearm.Status = new FirearmStatus(firearm.AmmoManagerModule.MaxAmmo, firearm.Status.Flags, firearm.Status.Attachments);
		}
		
		/// <summary>
		/// Removes all ammunition from the specified <see cref="Firearm"/>.
		/// </summary>
		/// <param name="firearm">The <see cref="Firearm"/> from which to remove all ammunition.</param>
		/// <exception cref="ArgumentNullException">Thrown if the <paramref name="firearm"/> is null.</exception>
		public static void RemoveAmmo(this Firearm firearm)
		{
			if (firearm == null)
				throw new ArgumentNullException(nameof(firearm), "Firearm is null");

			// Set the ammo count to zero
			firearm.Status = new FirearmStatus(0, firearm.Status.Flags, firearm.Status.Attachments);
		}
	}
}
