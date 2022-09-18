namespace PluginAPI.Core.Zones.Heavy
{
	using MapGeneration.Distributors;
	using UnityEngine;

	public class Generator
	{
		public readonly Scp079Generator OriginalObject;
		public readonly HczRoom Room;

		/*public bool IsOpened
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
		public bool IsActivating
		{
			get => OriginalObject.Activating;
			set => OriginalObject.Activating = value;

		}
		public bool IsActivationReady => false;//OriginalObject.ActivationReady;

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
		public Transform Transform => OriginalObject.transform;
		public GameObject GameObject => OriginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		public void PlayDeniedSound()
		{
			//OriginalObject.RpcDenied();
		}

		public Generator(HczRoom room, Scp079Generator generator)
		{
			Room = room;
			OriginalObject = generator;
		}
	}
}
