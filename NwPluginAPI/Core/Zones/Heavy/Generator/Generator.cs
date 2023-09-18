namespace PluginAPI.Core.Zones.Heavy.Generator
{
	using MapGeneration.Distributors;
	using PluginAPI.Core.Zones.Heavy;
	using UnityEngine;

	/// <summary>
	/// Represents an generator.
	/// </summary>
	public class Generator
	{
		/// <summary>
		/// The base-game object.
		/// </summary>
		public readonly Scp079Generator OriginalObject;

		/// <summary>
		/// The room the generator is in.
		/// </summary>
		public readonly HczRoom Room;

		/*
		/// <summary>
		/// Gets or sets whether or not the generator is opened.
		/// </summary>
		public bool IsOpened
		{
			get
			{
				return OriginalObject.HasFlag(OriginalObject._flags, Scp079Generator.GeneratorFlags.Open);
			}
			set
			{
				OriginalObject.ServerSetFlag(Scp079Generator.GeneratorFlags.Open, value);
			}
		}

		/// <summary>
		/// Gets or sets whether or not the generator is locked.
		/// </summary>
		public bool IsLocked
		{
			get
			{
				return !OriginalObject.HasFlag(OriginalObject._flags, Scp079Generator.GeneratorFlags.Unlocked);
			}
			set
			{
				OriginalObject.ServerSetFlag(Scp079Generator.GeneratorFlags.Unlocked, !value);
			}
		}
		*/
		/// <summary>
		/// Gets or sets whether or not the generator is activating.
		/// </summary>
		public bool IsActivating
		{
			get => OriginalObject.Activating;
			set => OriginalObject.Activating = value;

		}

		/// <summary>
		/// Gets whether or not the generator is activation-ready.
		/// </summary>
		public bool IsActivationReady => false; //OriginalObject.ActivationReady;

		/// <summary>
		/// Gets or sets whether or not the generator is engaged (active).
		/// </summary>
		public bool IsEngaged
		{
			get => OriginalObject.Engaged;
			set => OriginalObject.Engaged = value;
		}

		/*public short SynchronizedTime
		{
			get
			{
				return OriginalObject._syncTime;
			}
			set
			{
				OriginalObject._syncTime = value;
			}
		}*/

		/*public float InteractionCooldown
		{
			get
			{
				return OriginalObject._doorToggleCooldownTime;
			}
			set
			{
				OriginalObject._doorToggleCooldownTime = value;
			}
		}
		*/
		/*public float UnlockInteractionCooldown
		{
			get
			{
				return OriginalObject._unlockCooldownTime;
			}
			set
			{
				OriginalObject._unlockCooldownTime = value;
			}
		}
		*/
		/// <summary>
		/// Gets the generator's <see cref="UnityEngine.Transform"/>.
		/// </summary>
		public Transform Transform => OriginalObject.transform;

		/// <summary>
		/// Gets the generator's <see cref="UnityEngine.GameObject"/>.
		/// </summary>
		public GameObject GameObject => OriginalObject.gameObject;

		/// <summary>
		/// Gets the generator's position.
		/// </summary>
		public Vector3 Position => Transform.position;

		/// <summary>
		/// Gets the generator rotation.
		/// </summary>
		public Quaternion Rotation => Transform.rotation;

		/// <summary>
		/// Plays the generator's denied sound.
		/// </summary>
		public void PlayDeniedSound()
		{
			//OriginalObject.RpcDenied();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Generator"/> class.
		/// </summary>
		/// <param name="room">The room the generator is in.</param>
		/// <param name="generator">The base-game generator.</param>
		public Generator(HczRoom room, Scp079Generator generator)
		{
			Room = room;
			OriginalObject = generator;
		}
	}
}