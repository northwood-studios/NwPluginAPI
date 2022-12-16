namespace PluginAPI.Loader.Features
{
	using Helpers;

	/// <summary>
    /// Contains the paths containing plugins and dependencies.
    /// </summary>
    public readonly struct PluginDirectory
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="PluginDirectory"/> struct.
		/// </summary>
		/// <param name="containingFolder">The folder on which the "plugins" folder is stored.</param>
		public PluginDirectory(string containingFolder)
		{
			Plugins = containingFolder;
			Dependencies = Paths.GetDirectory(Plugins, "dependencies");
		}

		/// <summary>
		/// Gets or sets the dependencies folder.
		/// </summary>
		public readonly string Dependencies;

		/// <summary>
		/// Gets or sets the plugins folder.
		/// </summary>
		public readonly string Plugins;
    }
}
