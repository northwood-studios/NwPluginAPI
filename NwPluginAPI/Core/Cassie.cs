namespace PluginAPI.Core
{
	using PlayerRoles;
	using PlayerStatsSystem;
	using Respawning;
	using System.Collections.Generic;
	using System.Linq;
	using static NineTailedFoxAnnouncer;

	/// <summary>
	/// Represents the cassie system in-game.
	/// </summary>
	public static class Cassie
	{
		#region Static Parameters
		/// <summary>
		/// Gets whether or not CASSIE is speaking.
		/// </summary>
		public static bool IsSpeaking => singleton.queue.Count != 0;

		/// <summary>
		/// Gets a collection of CASSIE voice lines.
		/// </summary>
		public static IEnumerable<VoiceLine> VoiceLines => singleton.voiceLines;

		#endregion

		#region Static Methods
		#region Sending messages.
		/// <summary>
		/// Send CASSIE message without glitch phrases.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="isHeld">Whether or not the message is held.</param>
		/// <param name="isNoisy">Whether or not the  message starts with intro sound.</param>
		/// <param name="isSubtitles">Whether or not the  message includes subtitles.</param>
		public static void Message(string message, bool isHeld = false, bool isNoisy = true, bool isSubtitles = false) => RespawnEffectsController.PlayCassieAnnouncement(message, isHeld, isNoisy, isSubtitles);

		/// <summary>
		/// Send CASSIE message with glitch phrases.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="glitchChance">The chance of placing a glitch phrase between each word.</param>
		/// <param name="jamChance">The chance of jamming each word.</param>
		public static void GlitchyMessage(string message, float glitchChance, float jamChance) => singleton.ServerOnlyAddGlitchyPhrase(message, glitchChance, jamChance);
		#endregion

		/// <summary>
		/// Clears all CASSIE messages in queue.
		/// </summary>
		public static void Clear() => RespawnEffectsController.ClearQueue();

		#region Utils.
		/// <summary>
		/// Calculates duration of a CASSIE message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="rawNumber">Raw number.</param>
	    public static float CalculateDuration(string message, bool rawNumber = false) => singleton.CalculateDuration(message, rawNumber);

		/// <summary>
		/// Converts team into a CASSIE readable unit name.
		/// </summary>
		/// <param name="team">The team.</param>
		/// <param name="unitName">Unit name.</param>
		public static string ConvertTeam(Team team, string unitName) => NineTailedFoxAnnouncer.ConvertTeam(team, unitName);

		/// <summary>
		/// Converts number into a CASSIE readable word.
		/// </summary>
		/// <param name="num">Number to convert.</param>
		public static string ConvertNumber(int num) => NineTailedFoxAnnouncer.ConvertNumber(num);

		/// <summary>
		/// Checks whether or not the provided word is a CASSIE readable one.
		/// </summary>
		/// <param name="word">The word.</param>
		public static bool IsValid(string word) => singleton.voiceLines.Any(line => line.apiName.ToUpper() == word.ToUpper());
		#endregion

		/// <summary>
		/// Forces an scp termination announcement.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <param name="info">The damage information.</param>
		public static void ScpTermination(Player player, DamageHandlerBase info)
			=> AnnounceScpTermination(player.ReferenceHub, info);
		#endregion
	}
}
