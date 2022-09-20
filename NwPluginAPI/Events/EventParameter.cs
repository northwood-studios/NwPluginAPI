using System;

namespace PluginAPI.Events
{
	public class EventParameter
	{
		public Type BaseType { get; }
		public string DefaultIdentifierName { get; }
		
		public EventParameter(Type type,string defaultIdentifierName) 
		{
			BaseType = type;
			DefaultIdentifierName = defaultIdentifierName;
		}
	}
}
