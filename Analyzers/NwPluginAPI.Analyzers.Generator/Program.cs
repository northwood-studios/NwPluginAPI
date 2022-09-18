using PluginAPI.Events;
using System.Text;

StringBuilder builder = new StringBuilder();
builder.AppendLine("using System.Collections.Generic;");
builder.AppendLine(string.Empty);
builder.AppendLine("public static class GeneratedRequiredParameters");
builder.AppendLine("{");
builder.AppendLine("	public static Dictionary<int, string[]> RequiredParameters = new Dictionary<int, string[]>()");
builder.AppendLine("	{");


foreach (var parameter in EventManager.RequiredParameters)
{
	if (parameter.Value.Length == 0)
		builder.AppendLine("		{ " + parameter.Key + ", new string[0] },");
	else
	{
		builder.Append("		{ " + parameter.Key + ", new string[] { ");
		foreach (var type in parameter.Value)
			builder.Append($"\"{type.FullName}\", ");
		builder.Append("} },");
		builder.AppendLine();
	}
}

builder.AppendLine("	};");
builder.AppendLine("}");

File.WriteAllText($"..\\..\\..\\..\\NWPluginAPI.Analyzers\\Generated\\GeneratedRequiredParameters.cs", builder.ToString());
