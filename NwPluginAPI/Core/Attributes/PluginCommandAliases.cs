namespace PluginAPI.Core.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginCommandAliases : Attribute
	{
		public string[] Aliases { get; set; }

		public PluginCommandAliases(params string[] aliases)
		{
			Aliases = aliases;
		}
	}
}
