namespace PluginAPI
{
	public static class PluginApiVersion
	{
		public const string Version = "13.1.2"; //major.minor.patch ONLY
		public const string VersionString = "13.1.2";

		//PackageVersion needs to be set to the same value as VersionString MANUALLY IN .csproj

		public static string VersionStatic => VersionString;
	}
}