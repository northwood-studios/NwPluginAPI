using InventorySystem.Items.Pickups;
using PluginAPI.Core.Interfaces;
using PluginAPI.Enums;
using Scp914;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Scp914
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp914UpgradePickup"/>.
	/// </summary>
	public class UpgradingPickupEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UpgradingPickupEventArgs"/>.
		/// </summary>
		/// <param name="outPosition"></param>
		/// <param name="knobSetting"></param>
		/// <param name="pickup"></param>
		public UpgradingPickupEventArgs(Vector3 outPosition, Scp914KnobSetting knobSetting, ItemPickupBase pickup)
		{
			OutputPosition = outPosition;
			KnobSetting = knobSetting;
			Pickup = pickup;
		}

		/// <summary>
		/// Gets the <see cref="Scp914Controller" /> instance.
		/// </summary>
		public Scp914Controller Scp914 { get; } = Scp914Controller.Singleton;

		/// <summary>
		/// Get or set the position the item will be output to.
		/// </summary>
		public Vector3 OutputPosition { get; set; }

		/// <summary>
		/// Gets or set SCP-914 <see cref="Scp914KnobSetting"/>.
		/// </summary>
		public Scp914KnobSetting KnobSetting { get; set; }

		/// <summary>
		/// Get item pickup.
		/// </summary>
		public ItemPickupBase Pickup { get; }
	}
}