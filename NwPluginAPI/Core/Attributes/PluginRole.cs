using PluginAPI.Enums;
using System;

namespace PluginAPI.Core.Attributes
{
	/// <summary>
	/// Marks the plugin role.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class PluginRole : Attribute
	{
		public RoleRegisterType RegisterType;
		public int RoleId;

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginRole"/> class.
		/// </summary>
		/// <param name="registerType">The type of registered role.</param>
		public PluginRole(RoleRegisterType registerType)
		{
			RegisterType = registerType;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginRole"/> class.
		/// </summary>
		/// <param name="registerType">The type of registered role.</param>
		public PluginRole(RoleRegisterType registerType, int roleId)
		{
			RegisterType = registerType;
			RoleId = roleId;
		}
	}
}
