namespace PluginAPI.Core
{
	using UnityEngine;

	public class RoomLight
	{
		private readonly FlickerableLightController _lightController;
		private Color? _defaultLightColor;

		private void SaveDefaultColor()
		{
			if (!_defaultLightColor.HasValue)
				_defaultLightColor = _lightController.WarheadLightColor;
		}

		/// <summary>
		/// Enables or disables light in room.
		/// </summary>
		public bool IsEnabled
		{
			get
			{
				return _lightController.LightsEnabled;
			}
			
			set
			{
				_lightController.LightsEnabled = value;
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
				_lightController.WarheadLightColor = value;
				_lightController.WarheadLightOverride = value != DefaultColor;
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
				return _lightController.LightIntensityMultiplier;
			}
			
			set
			{
				_lightController.LightIntensityMultiplier = value;
			}
		}

		/// <summary>
		/// Flickers lights in room.
		/// </summary>
		/// <param name="duration">The durtaion of flicker.</param>
		public void FlickerLights(float duration)
		{
			_lightController.ServerFlickerLights(duration);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="lightController">The light controller for room.</param>
		public RoomLight(FlickerableLightController lightController) => _lightController = lightController;
	}
}
