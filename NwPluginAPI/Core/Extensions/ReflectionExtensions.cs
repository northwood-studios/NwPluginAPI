namespace PluginAPI.Core.Extensions
{
	using Attributes;
	using System;
	using System.Reflection;

	/// <summary>
	/// Reflection-related extensions.
	/// </summary>
	public static class ReflectionExtensions
	{
		public static bool IsValidEntrypoint(this Type type)
		{
			foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				var attr = method.GetCustomAttribute<PluginEntryPoint>();
				if (attr != null)
					return true;
			}

			return false;
		}

		public static T GetPrivateFieldValue<T>(this object obj, string fieldName)
		{
			Type type = obj.GetType();
			FieldInfo field = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        
			if (field != null)
			{
				return (T)field.GetValue(obj);
			}
        
			throw new ArgumentException($"Field '{fieldName}' not found in type '{type}'.");
		}
	}
}