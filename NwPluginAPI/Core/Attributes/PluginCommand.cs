namespace PluginAPI.Core.Attributes
{
	using Enums;
	using System;

	/// <summary>
	/// Marks a class as plugin command.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginCommand : Attribute
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public CommandType Type { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginCommand"/> class.
		/// </summary>
		/// <param name="name">The name of the command.</param>
		/// <param name="description">The description of the command.</param>
		/// <param name="type">The <see cref="CommandType"/> of the command.</param>
		public PluginCommand(string name, string description, CommandType type)
		{
			Name = name;
			Description = description;
			Type = type;
		}
	}
}