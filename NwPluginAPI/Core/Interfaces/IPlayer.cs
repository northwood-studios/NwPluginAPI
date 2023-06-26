namespace PluginAPI.Core.Interfaces
{
	/// <summary>
	/// Defines a player.
	/// </summary>
	public interface IPlayer : IEntity
	{
		/// <summary>
		/// Gets if the player is in the server.
		/// </summary>
		bool IsOffline { get; }
		
		/// <summary>
		/// Gets the player's user id.
		/// </summary>
		string UserId { get; }
		
		/// <summary>
		/// Gets the player's name.
		/// </summary>
		string Nickname { get; }
		
		/// <summary>
		/// Gets the player's ip address.
		/// </summary>
		string IpAddress { get; }
	}
}