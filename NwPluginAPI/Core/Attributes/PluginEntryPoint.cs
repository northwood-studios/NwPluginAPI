namespace PluginAPI.Core.Attributes
{
	using System;

	/// <summary>
	/// Marks the plugin entrypoint.
	/// Called when the plugin is initialized.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginEntryPoint : Attribute
	{
		public string Name { get; }
		public string Version { get; }
		public string Description { get; }
		public string Author { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginEntryPoint"/> class.
		/// </summary>
		/// <param name="pluginName">The plugin name.</param>
		/// <param name="pluginVersion">The plugin version.</param>
		/// <param name="description">The plugin description.</param>
		/// <param name="author">The plugin author.</param>
		public PluginEntryPoint(string pluginName, string pluginVersion, string description, string author)
		{
			Name = pluginName;
			Author = author;
			Description = description;
			Version = pluginVersion;
		}
	}
}
