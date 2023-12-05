using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI.Enums
{
	/// <summary>
	/// This is used to easily identify damage handlers without needlessly casting them.
	/// </summary>
	public enum DamageType : int
	{
		Custom = 0,
		Firearm = 1,
		Com15 = 2,
		MicroHID = 3,
		E11SR = 4,
		Crossvec = 5,
		FSP9 = 6,
		Logicer = 7,
		COM18 = 8,
		Revolver = 9,
		AK = 10,
		Shotgun = 11,
		MolecularDisruptor = 12,
		Com45 = 13,
		Jailbird = 14,
		Explosion = 15,
		GrenadeExplosion = 16,
		Recontainment = 17,
		Recontain079 = 18,
		Universal = 19,
		Asphyxiated = 20,
		Bleeding = 21,
		PocketDecay = 22,
		Decontamination = 23,
		Hemorrhage = 24,
		Poisoned = 25,
		SeveredHands = 26,
		Checkpoint = 27,
		FriendlyFireDetector = 28,
		Hypothermia = 29,
		CardiacArrest = 30,
		Falldown = 31,
		Tesla = 32,
		Scp207 = 33,
		Scp173 = 34,
		Scp106 = 35,
		Scp049 = 36,
		Scp096GateKill = 37,
		Scp096SlapLeft = 38,
		Scp096SlapRight = 39,
		Scp096Charge = 40,
		Scp0492 = 41,
		Scp939Claw = 42,
		Scp939LungeTarget = 43,
		Scp939LungeSecondary = 44,
		Scp018 = 45,
		Warhead = 46,
		PlayerLeft = 47,
		ForcedDeath = 48,
	}
}
