using System;

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

		/// <summary>
		/// Gets the default parameter name.
		/// </summary>
		public string DefaultIdentifierName { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="EventParameter"/> class.
		/// </summary>
		/// <param name="type">The <see cref="BaseType"/>.</param>
		/// <param name="defaultIdentifierName">The <see cref="DefaultIdentifierName"/>.</param>
		public EventParameter(Type type,string defaultIdentifierName) 
		{
			BaseType = type;
			DefaultIdentifierName = defaultIdentifierName;
		}
	}
}
