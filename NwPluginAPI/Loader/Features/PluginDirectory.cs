namespace PluginAPI.Loader.Features
{
	using PluginAPI.Helpers;

	/// <summary>
    /// Contains all the paths leading to plugins and dependencies.
    /// </summary>
    public struct PluginDirectory
    {
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="containingFolder">The folder on which the "plugins" folder is stored.</param>
		public PluginDirectory(string containingFolder)
		{
			Plugins = containingFolder;

			Dependencies = Paths.GetDirectory(Plugins, "dependencies");
		}

		public string Dependencies { get; set; }
		public string Plugins { get; set; }
	}
}
