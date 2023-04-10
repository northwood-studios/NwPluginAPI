using System;
using System.Reflection;

namespace PluginAPI.Events
{
	/// <summary>
	/// Represents a event parameter.
	/// </summary>
	public class EventParameter
	{
		/// <summary>
		/// Gets the type of the parameter.
		/// </summary>
		public Type BaseType { get; }

		public bool IsReadonly { get; }

		/// <summary>
		/// Gets the default parameter name.
		/// </summary>
		public string DefaultIdentifierName { get; }

		public PropertyInfo PropertyInfo { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="EventParameter"/> class.
		/// </summary>
		/// <param name="type">The <see cref="BaseType"/>.</param>
		/// <param name="defaultIdentifierName">The <see cref="DefaultIdentifierName"/>.</param>
		public EventParameter(Type type, PropertyInfo property, string defaultIdentifierName)
		{
			BaseType = type;
			PropertyInfo = property;
			IsReadonly = !property.CanWrite;
			DefaultIdentifierName = defaultIdentifierName;
		}
	}
}