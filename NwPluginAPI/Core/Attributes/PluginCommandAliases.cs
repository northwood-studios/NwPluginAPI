namespace PluginAPI.Core.Attributes
{
	using System;

	/// <summary>
	/// Marks aliases to existing commands.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginCommandAliases : Attribute
	{
		public string[] Aliases { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginCommandAliases"/> class.
		/// </summary>
		/// <param name="aliases">The commands aliases.</param>
		public PluginCommandAliases(string[] aliases)
		{
			Aliases = aliases;
		}
	}
}