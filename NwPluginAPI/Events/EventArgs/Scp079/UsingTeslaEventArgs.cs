using PlayerRoles.PlayableScps.Scp079;
using PluginAPI.Core;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;

namespace PluginAPI.Events.EventArgs.Scp079
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp079UseTesla"/>.
	/// </summary>
	public class UsingTeslaEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UsingTeslaEventArgs"/>.
		/// </summary>
		/// <param name="scp079"></param>
		/// <param name="tesla"></param>
		/// <param name="energyCost"></param>
		/// <param name="cooldown"></param>
		public UsingTeslaEventArgs(IPlayer scp079, TeslaGate tesla, int energyCost, float cooldown)
		{
			Player = (Core.Player)scp079;
			Scp079Role = Player.RoleBase as Scp079Role;
			Tesla = tesla;
			EnergyCost = energyCost;
			Cooldown = cooldown;
		}

		/// <summary>
		/// Gets player playing SCP-079.
		/// </summary>
		public Core.Player Player { get; }

		/// <summary>
		/// Gets player <see cref="PlayerRoles.PlayableScps.Scp079.Scp079Role"/> instance.
		/// </summary>
		public Scp079Role Scp079Role { get; }

		/// <summary>
		/// Gets <see cref="TeslaGate"/> that SCP-079 is using.
		/// </summary>
		public TeslaGate Tesla { get; }

		/// <summary>
		/// Get or set SCP-079 energy cost.
		/// </summary>
		public int EnergyCost { get; set; }

		/// <summary>
		/// Get or set SCP-079 cooldown of this ability.
		/// </summary>
		public float Cooldown { get; set; }
	}
}