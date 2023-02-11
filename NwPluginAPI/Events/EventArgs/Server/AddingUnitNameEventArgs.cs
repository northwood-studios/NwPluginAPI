using Respawning.NamingRules;

namespace PluginAPI.Events.EventArgs.Server
{
	/// <summary>
	/// Create new event for this.
	/// </summary>
	public class AddingUnitNameEventArgs
	{
		/// <summary>
		/// Initializes a new instance of <see cref="AddingUnitNameEventArgs"/>.
		/// </summary>
		/// <param name="unitName"></param>
		public AddingUnitNameEventArgs(UnitNamingRule unitName)
		{
			UnitName = unitName;
		}

		/// <summary>
		/// Get or set unit name to add.
		/// </summary>
		public UnitNamingRule UnitName { get; set; }
	}
}