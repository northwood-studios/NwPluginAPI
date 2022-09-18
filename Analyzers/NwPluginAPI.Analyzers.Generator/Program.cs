using PluginAPI.Events;
using System.Text;

StringBuilder builder = new StringBuilder();
builder.AppendLine("using System.Collections.Generic;");
builder.AppendLine(string.Empty);
builder.AppendLine("public class Event");
builder.AppendLine("{");
builder.AppendLine("	public readonly EventParameter[] Parameters;");
builder.AppendLine(string.Empty);
builder.AppendLine("	public Event(params EventParameter[] parameters)");
builder.AppendLine("	{");
builder.AppendLine("		Parameters = parameters;");
builder.AppendLine("	}");
builder.AppendLine("}");
builder.AppendLine(string.Empty);
builder.AppendLine("public class EventParameter");
builder.AppendLine("{");
builder.AppendLine("	public string BaseType { get; set; }");
builder.AppendLine("	public string DefaultIdentifierName { get; set; }");
builder.AppendLine(string.Empty);
builder.AppendLine("	public EventParameter(string baseType, string defaultIdentifierName)");
builder.AppendLine("	{");
builder.AppendLine("		BaseType = baseType;");
builder.AppendLine("		DefaultIdentifierName = defaultIdentifierName;");
builder.AppendLine("	}");
builder.AppendLine("}");
builder.AppendLine(string.Empty);
builder.AppendLine("public static class EventManager");
builder.AppendLine("{");
builder.AppendLine("	public static Dictionary<int, Event> Events = new Dictionary<int, Event>()");
builder.AppendLine("	{");

foreach (var ev in EventManager.Events)
{
	if (ev.Value.Parameters.Length == 0)
		builder.AppendLine("		{ " + (int)ev.Key + ", new Event() },");
	else
	{
		builder.AppendLine("		{ " + (int)ev.Key + ", new Event(");
		for(int x = 0; x < ev.Value.Parameters.Length; x++)
		{
			var param = ev.Value.Parameters[x];

			builder.AppendLine("			new EventParameter(\"" + param.BaseType.FullName + "\", \"" + param.DefaultIdentifierName+ "\")" + (x == (ev.Value.Parameters.Length - 1) ? ") }," : ","));
		}
	}
}

builder.AppendLine("	};");
builder.AppendLine("}");

File.WriteAllText($"..\\..\\..\\..\\NWPluginAPI.Analyzers\\Generated\\GeneratedEventManager.cs", builder.ToString());
