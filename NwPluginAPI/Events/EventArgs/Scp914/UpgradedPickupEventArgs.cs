using InventorySystem.Items.Pickups;
using PluginAPI.Enums;
using Scp914;
using UnityEngine;

namespace PluginAPI.Events.EventArgs.Scp914
{
	/// <summary>
	/// This EventArgs is for <see cref="ServerEventType.Scp914PickupUpgraded"/>.
	/// </summary>
	public class UpgradedPickupEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="UpgradingPickupEventArgs"/>.
		/// </summary>
		/// <param name="outPosition"></param>
		/// <param name="knobSetting"></param>
		/// <param name="pickup"></param>
		public UpgradedPickupEventArgs(Vector3 outPosition, Scp914KnobSetting knobSetting, ItemPickupBase pickup)
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
		/// Gets the position the item will be output to.
		/// </summary>
		public Vector3 OutputPosition { get; }

		/// <summary>
		/// Gets SCP-914 <see cref="Scp914KnobSetting"/>.
		/// </summary>
		public Scp914KnobSetting KnobSetting { get; }

		/// <summary>
		/// Gets item pickup.
		/// </summary>
		public ItemPickupBase Pickup { get; }
	}
}