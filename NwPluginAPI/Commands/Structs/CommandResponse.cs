namespace PluginAPI.Commands.Structs
{
	public readonly struct CommandResponse
	{
		public bool IsSuccess { get; }
		public string Message { get; }

		public static CommandResponse Success(string message) => new CommandResponse(true, message);
		public static CommandResponse Failed(string message) => new CommandResponse(false, message);
		public static CommandResponse EmptyResponse() => new CommandResponse(true, null);

		private CommandResponse(bool success, string message)
		{
			IsSuccess = success;
			Message = message;
		}
	}
}
