namespace PluginAPI.Core
{
	using UnityEngine;

	public class RoomLight
	{
		internal FlickerableLightController LightController;
		private Color? _defaultLightColor;

		private void SaveDefaultColor()
		{
			if (!_defaultLightColor.HasValue)
				_defaultLightColor = LightController.WarheadLightColor;
		}

		/// <summary>
		/// Enables or disables light in room.
		/// </summary>
		public bool IsEnabled
		{
			get
			{
				return LightController.LightsEnabled;
			}
			set
			{
				LightController.LightsEnabled = value;
			}
		}

		/// <summary>
		/// Gets or sets color of lights in room.
		/// </summary>
		public Color LightColor
		{
			get
			{
				return DefaultColor;
			}
			set
			{
				SaveDefaultColor();
				LightController.WarheadLightColor = value;
				LightController.WarheadLightOverride = value != DefaultColor;
			}
		}

		/// <summary>
		/// Gets default color of lights.
		/// </summary>
		public Color DefaultColor
		{
			get
			{
				SaveDefaultColor();
				return _defaultLightColor.Value;
			}
		}

		/// <summary>
		/// Gets or sets lights intensity in room.
		/// </summary>
		public float LightIntensity
		{
			get
			{
				return LightController.LightIntensityMultiplier;
			}
			set
			{
				LightController.LightIntensityMultiplier = value;
			}
		}

		/// <summary>
		/// Flickers lights in room.
		/// </summary>
		/// <param name="duration">The durtaion of flicker.</param>
		public void FlickerLights(float duration)
		{
			LightController.ServerFlickerLights(duration);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="lightController">The light controller for room.</param>
		public RoomLight(FlickerableLightController lightController) => LightController = lightController;
	}
}
