using PlayerStatsSystem;
using PluginAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerRoles.PlayableScps.Scp939;

namespace PluginAPI.Core.Extensions
{
	public static class DamageHandlerExtensions
	{
		/// <summary>
		/// Gets a <see cref="DamageType"/> of a <see cref="DamageHandlerBase"/>
		/// </summary>
		/// <param name="damageHandler"></param>
		/// <returns><see cref="DamageType"/></returns>
		public static DamageType GetDamageType(this DamageHandlerBase damageHandler)
		{
			switch (damageHandler)
			{
				case CustomReasonDamageHandler:
					return DamageType.Custom;
				case WarheadDamageHandler:
					return DamageType.Warhead;
				case ExplosionDamageHandler:
					return DamageType.Explosion;
				case Scp018DamageHandler:
					return DamageType.Scp018;
				case Scp096DamageHandler dmg:
					return DamageType.Scp096;
				case Scp939DamageHandler:
					return DamageType.Scp939;
				case RecontainmentDamageHandler:
					return DamageType.Recontain079;
				case MicroHidDamageHandler:
					return DamageType.MicroHID;
				case DisruptorDamageHandler:
					return DamageType.MolecularDisruptor;
				case FirearmDamageHandler firearmDamageHandler:
					return firearmDamageHandler.GetFirearmDamageType();
				case JailbirdDamageHandler:
					return DamageType.Jailbird;
				case ScpDamageHandler scpDamageHandler:
				{
					var deathTranslation = DeathTranslations.TranslationsById[scpDamageHandler._translationId];
					// Scp106 does damage directly with a value of 106106f so if I want DamageType.Scp106 to be activated at least 1 time I have to do this check
					// And how floats with more than 3 digits become inaccurate...
					return Math.Abs(scpDamageHandler.Damage - 106106) < 0.001 ? DamageType.Scp106 : deathTranslation.GetTranslationDamageType();
				}
				case UniversalDamageHandler universalDamage:
				{
					if (TranslationIdConversion.TryGetValue(universalDamage.TranslationId, out var damageType))
					{
						return damageType;
					}
					
					Log.Warning($"{nameof(DamageHandlerExtensions)}.{nameof(GetDamageType)}: Unknown damage detected from {nameof(UniversalDamageHandler)} with the ID {universalDamage.TranslationId}");
					return DamageType.Universal;
				}
				default:
					return DamageType.Unknown;
			}
		}
		
		/// <summary>
		/// Gets a <see cref="DamageType"/> from <see cref="FirearmDamageHandler"/>
		/// </summary>
		/// <param name="dmg">FireArm damage handler</param>
		/// <returns><see cref="DamageType"/></returns>
		public static DamageType GetFirearmDamageType(this FirearmDamageHandler dmg)
		{
			return dmg.WeaponType switch
			{
				ItemType.GunCrossvec => DamageType.Crossvec,
				ItemType.GunLogicer => DamageType.Logicer,
				ItemType.GunShotgun => DamageType.Shotgun,
				ItemType.GunAK => DamageType.AK,
				ItemType.GunCOM15 => DamageType.Com15,
				ItemType.GunCom45 => DamageType.Com45,
				ItemType.GunCOM18 => DamageType.COM18,
				ItemType.GunFSP9 => DamageType.FSP9,
				ItemType.GunE11SR => DamageType.E11SR,
				ItemType.MicroHID => DamageType.MicroHID,
				ItemType.ParticleDisruptor => DamageType.MolecularDisruptor,
				ItemType.GunRevolver => DamageType.Revolver,
				_ => DamageType.Firearm
			};
		}

		/// <summary>
		/// Gets the specific <see cref="DamageType"/> done by SCP-096.
		/// </summary>
		/// <returns><see cref="DamageType"/>.Scp096GateKill or <see cref="DamageType"/>.Scp096SlapLeft or <see cref="DamageType"/>.Scp096SlapRight or <see cref="DamageType"/>.Scp096Charge</returns>
		public static DamageType GetScp096DamageType(this Scp096DamageHandler handler)
		{
			return handler._attackType switch
			{
				Scp096DamageHandler.AttackType.Charge => DamageType.Scp096Charge,
				Scp096DamageHandler.AttackType.GateKill => DamageType.Scp096GateKill,
				Scp096DamageHandler.AttackType.SlapLeft => DamageType.Scp096SlapLeft,
				Scp096DamageHandler.AttackType.SlapRight => DamageType.Scp096SlapRight,
				_ => DamageType.Scp096
			};
		}
		
		/// <summary>
		/// Gets the specific <see cref="DamageType"/> done by SCP-939.
		/// </summary>
		/// <returns><see cref="DamageType"/>.Scp939Claw or <see cref="DamageType"/>.Scp939LungeSecondary or <see cref="DamageType"/>.Scp939LungeTarget</returns>
		public static DamageType GetScp939DamageType(this Scp939DamageHandler handler)
		{
			switch (handler._damageType)
			{
				case Scp939DamageType.Claw:
					return DamageType.Scp939Claw;
				case Scp939DamageType.LungeSecondary:
					return DamageType.Scp939LungeSecondary;
				case Scp939DamageType.LungeTarget:
					return DamageType.Scp939LungeTarget;
				default:
					return DamageType.Scp939;
			}
		}
		
		/// <summary>
		/// Gets a <see cref="DamageType"/> from a <see cref="DeathTranslation"/>
		/// </summary>
		/// <returns><see cref="DamageType"/></returns>
		public static DamageType GetTranslationDamageType(this DeathTranslation translation)
		{
			return TranslationIdConversion.TryGetValue(translation.Id, out var damageType) ? damageType : DamageType.Unknown;
		}

		/// <summary>
		/// Private dictionary of types of damage based on the id of translation.
		/// </summary>
		private static readonly Dictionary<byte, DamageType> TranslationIdConversion = new()
		{
			{ DeathTranslations.Asphyxiated.Id, DamageType.Asphyxiated },
			{ DeathTranslations.Bleeding.Id, DamageType.Bleeding },
			{ DeathTranslations.Crushed.Id, DamageType.Crushed },
			{ DeathTranslations.Decontamination.Id, DamageType.Decontamination },
			{ DeathTranslations.Explosion.Id, DamageType.Explosion },
			{ DeathTranslations.Falldown.Id, DamageType.Falldown },
			{ DeathTranslations.Poisoned.Id, DamageType.Poisoned },
			{ DeathTranslations.Recontained.Id, DamageType.Recontainment },
			{ DeathTranslations.Scp049.Id, DamageType.Scp049 },
			{ DeathTranslations.Scp096.Id, DamageType.Scp096 },
			{ DeathTranslations.Scp173.Id, DamageType.Scp173 },
			{ DeathTranslations.Scp207.Id, DamageType.Scp207 },
			{ DeathTranslations.Scp939Lunge.Id, DamageType.Scp939 },
			{ DeathTranslations.Scp939Other.Id, DamageType.Scp939 },
			{ DeathTranslations.Tesla.Id, DamageType.Tesla },
			{ DeathTranslations.Unknown.Id, DamageType.Unknown },
			{ DeathTranslations.Warhead.Id, DamageType.Warhead },
			{ DeathTranslations.Zombie.Id, DamageType.Scp0492 },
			{ DeathTranslations.BulletWounds.Id, DamageType.Firearm },
			{ DeathTranslations.PocketDecay.Id, DamageType.PocketDecay },
			{ DeathTranslations.SeveredHands.Id, DamageType.SeveredHands },
			{ DeathTranslations.FriendlyFireDetector.Id, DamageType.FriendlyFireDetector },
			{ DeathTranslations.MicroHID.Id, DamageType.MicroHID },
			{ DeathTranslations.Hypothermia.Id, DamageType.Hypothermia },
		};
	}
}
