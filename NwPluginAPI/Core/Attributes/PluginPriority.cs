namespace PluginAPI.Core.Attributes
{
	using Enums;
	using System;

	/// <summary>
	/// Marks a priority for plugin load.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PluginPriority : Attribute
	{
		public byte Priority { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginPriority"/> class.
		/// </summary>
		/// <param name="priority">The <see cref="LoadPriority"/>.</param>
		public PluginPriority(LoadPriority priority)
		{
			Priority = (byte)priority;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="PluginPriority"/> class.
		/// </summary>
		/// <param name="priority">The <see cref="LoadPriority"/>.</param>
		public PluginPriority(byte priority)
		{
			Priority = priority;
		}
	}
}
