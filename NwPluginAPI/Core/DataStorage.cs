namespace PluginAPI.Core
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Manages a player's temporary data storage.
	/// </summary>
	public class DataStorage
	{
		/// <summary>
		/// Stored temporary data.
		/// </summary>
		public readonly Dictionary<string, object> StoredData = new Dictionary<string, object>();

		/// <summary>
		/// Clears stored data.
		/// </summary>
		public void Clear() => StoredData.Clear();

		/// <summary>
		/// Gets data from storage.
		/// </summary>
		/// <typeparam name="T">The type of data.</typeparam>
		/// <param name="dataName">The data name.</param>
		/// <param name="data">The output value.</param>
		/// <returns>Whether or not data was previously stored.</returns>
		public bool TryGet<T>(string dataName, out T data) where T : class, IComparable
		{
			if (StoredData.TryGetValue(dataName, out object obj))
			{
				data = (T) obj;
				return true;
			}

			data = default(T);
			return false;
		}

		/// <summary>
		/// Gets data from storage.
		/// </summary>
		/// <typeparam name="T">The type of data</typeparam>
		/// <param name="dataName">The data name.</param>
		/// <returns>The output value.</returns>
		public T Get<T>(string dataName) where T : class, IComparable
		{
			if (StoredData.TryGetValue(dataName, out object obj))
				return (T) obj;

			return default(T);
		}

		/// <summary>
		/// Adds new data name to storage.
		/// </summary>
		/// <typeparam name="T">The type of data.</typeparam>
		/// <param name="dataName">The data name.</param>
		/// <param name="data">The object of data.</param>
		/// <returns>Whether or not data had not been previously stored.</returns>
		public bool Add<T>(string dataName, T data) where T : class, IComparable
		{
			if (Contains(dataName)) return false;

			StoredData.Add(dataName, data);
			return true;
		}

		/// <summary>
		/// Overrides existing data in storage.
		/// </summary>
		/// <typeparam name="T">The type of data.</typeparam>
		/// <param name="dataName">The data name.</param>
		/// <param name="data">The object of data.</param>
		public void Override<T>(string dataName, T data) where T : class, IComparable
		{
			if (!Contains(dataName))
			{
				Add(dataName, data);
				return;
			}

			StoredData[dataName] = data;
		}

		/// <summary>
		/// Checks if data name is already stored.
		/// </summary>
		/// <param name="dataName">The data name.</param>
		/// <returns>Whether or not the data is exists.</returns>
		public bool Contains(string dataName) => StoredData.ContainsKey(dataName);

		/// <summary>
		/// Removes data from storage.
		/// </summary>
		/// <param name="dataName">The data name.</param>
		/// <returns>Whether or not data removal was successful</returns>
		public bool Remove(string dataName) => StoredData.Remove(dataName);
	}
}
