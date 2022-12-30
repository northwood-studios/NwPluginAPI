namespace PluginAPI.Core
{
	using UnityEngine;

	/// <summary>
	/// Represents a room's light.
	/// </summary>
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
		/// Gets or sets whether or not the light in room is enabled.
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
		/// Gets or sets the color of the lights.
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
		/// Gets the default color of lights.
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
		/// Gets or sets lightning intensity in room.
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
		/// Flickers the lights.
		/// </summary>
		/// <param name="duration">The durtaion of flicker.</param>
		public void FlickerLights(float duration)
		{
			_lightController.ServerFlickerLights(duration);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RoomLight"/> class.
		/// </summary>
		/// <param name="lightController">The light controller for room.</param>
		public RoomLight(FlickerableLightController lightController) => _lightController = lightController;
	}
}