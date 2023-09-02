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
		A7 = 13,
		MolecularDisruptor = 14,
		Com45 = 15,
		Jailbird = 16,
		Explosion = 17,
		GrenadeExplosion = 18,
		Recontainment = 19,
		Recontain079 = 20,
		Universal = 21,
		Asphyxiated = 22,
		Bleeding = 23,
		PocketDecay = 24,
		Decontamination = 25,
		Hemorrhage = 26,
		Poisoned = 27,
		SeveredHands = 28,
		Checkpoint = 29,
		FriendlyFireDetector = 30,
		Hypothermia = 31,
		CardiacArrest = 32,
		Falldown = 33,
		Tesla = 34,
		Scp207 = 35,
		Scp173 = 36,
		Scp106 = 37,
		Scp049 = 38,
		Scp096GateKill = 39,
		Scp096SlapLeft = 40,
		Scp096SlapRight = 41,
		Scp096Charge = 42,
		Scp0492 = 43,
		Scp939Claw = 44,
		Scp939LungeTarget = 45,
		Scp939LungeSecondary = 46,
		Scp018 = 47,
		Warhead = 48,
		PlayerLeft = 49,
		ForcedDeath = 50,
	}
}
