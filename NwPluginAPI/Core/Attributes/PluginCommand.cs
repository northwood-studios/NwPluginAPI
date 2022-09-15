namespace PluginAPI.Core.Attributes
{
	using PluginAPI.Enums;
	using System;

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginCommand : Attribute
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public CommandType Type { get; set; }

		public PluginCommand(string name, string description, CommandType type)
		{
			Name = name;
			Description = description;
			Type = type;
		}
	}
}
