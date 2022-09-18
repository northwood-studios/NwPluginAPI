namespace PluginAPI.Events
{
	public class EventParameter
	{
		public string DefaultIdentifierName { get; }
		
		public EventParameter(string identifierName) 
		{
			DefaultIdentifierName = identifierName;
		}
	}
}
