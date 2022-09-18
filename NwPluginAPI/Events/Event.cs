using System;
using System.Collections.Generic;

namespace PluginAPI.Events
{
	public class Event
	{
		public readonly Dictionary<Type, EventParameter> Parameters;
	}
}
