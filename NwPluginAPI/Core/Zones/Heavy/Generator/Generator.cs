namespace PluginAPI.Core.Zones.Heavy
{
	using MapGeneration.Distributors;
	using PluginAPI.Core.Zones.Heavy;
	using UnityEngine;

	public class Generator
	{
		public readonly Scp079Generator OrginalObject;
		public readonly HczRoom Room;

		public GeneratorLogic Logic { get; set; }

		/*public bool IsOpened
		{
			get
			{
				return OrginalObject.HasFlag(OrginalObject._flags, Scp079Generator.GeneratorFlags.Open);
			}
			set
			{
				OrginalObject.ServerSetFlag(Scp079Generator.GeneratorFlags.Open, value);
			}
		}

		public bool IsLocked
		{
			get
			{
				return !OrginalObject.HasFlag(OrginalObject._flags, Scp079Generator.GeneratorFlags.Unlocked);
			}
			set
			{
				OrginalObject.ServerSetFlag(Scp079Generator.GeneratorFlags.Unlocked, !value);
			}
		}
		*/
		public bool IsActivating
		{
			get => OrginalObject.Activating;
			set => OrginalObject.Activating = value;

		}
		public bool IsActivationReady => false;//OrginalObject.ActivationReady;

		public bool IsEngaged
		{
			get => OrginalObject.Engaged;
			set => OrginalObject.Engaged = value;
		}

		/*public short SynchronizedTime
		{
			get
			{
				return OrginalObject._syncTime;
			}
			set
			{
				OrginalObject._syncTime = value;
			}
		}*/

		/*public float InteractionCooldown
		{
			get
			{
				return OrginalObject._doorToggleCooldownTime;
			}
			set
			{
				OrginalObject._doorToggleCooldownTime = value;
			}
		}
		*/
		/*public float UnlockInteractionCooldown
		{
			get
			{
				return OrginalObject._unlockCooldownTime;
			}
			set
			{
				OrginalObject._unlockCooldownTime = value;
			}
		}
		*/
		public Transform Transform => OrginalObject.transform;
		public GameObject GameObject => OrginalObject.gameObject;
		public Vector3 Position => Transform.position;
		public Quaternion Rotation => Transform.rotation;

		public void PlayDeniedSound()
		{
			//OrginalObject.RpcDenied();
		}

		public Generator(HczRoom room, Scp079Generator generator)
		{
			Room = room;
			OrginalObject = generator;
		}
	}
}
