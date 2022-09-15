namespace PluginAPI.Core.Extensions
{
	using PluginAPI.Core.Attributes;
	using System;
	using System.Reflection;

	public static class ReflectionExtensions
    {
        public static bool IsValidEntrypoint(this Type type)
        {
            foreach(MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                PluginEntryPoint attr = method.GetCustomAttribute<PluginEntryPoint>();
                if (attr != null)
                    return true;
            }

            return false;
        }
    }
}
