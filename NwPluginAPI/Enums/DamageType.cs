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
		FRMG0 = 12,
		MolecularDisruptor = 13,
		Com45 = 14,
		Jailbird = 15,
		Explosion = 16,
		GrenadeExplosion = 17,
		Recontainment = 18,
		Recontain079 = 19,
		Universal = 20,
		Asphyxiated = 21,
		Bleeding = 22,
		PocketDecay = 23,
		Decontamination = 24,
		Hemorrhage = 25,
		Poisoned = 26,
		SeveredHands = 27,
		Checkpoint = 28,
		FriendlyFireDetector = 29,
		Hypothermia = 30,
		CardiacArrest = 31,
		Falldown = 32,
		Tesla = 33,
		Scp207 = 34,
		Scp173 = 35,
		Scp106 = 36,
		Scp049 = 37,
		Scp096GateKill = 38,
		Scp096SlapLeft = 39,
		Scp096SlapRight = 40,
		Scp096Charge = 41,
		Scp0492 = 42,
		Scp939Claw = 43,
		Scp939LungeTarget = 44,
		Scp939LungeSecondary = 45,
		Scp018 = 46,
		Warhead = 47,
		PlayerLeft = 48,
		ForcedDeath = 49,
	}
}
