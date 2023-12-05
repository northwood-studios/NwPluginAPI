namespace PluginAPI.Core
{
	using UnityEngine;

	/// <summary>
	/// Represents a room's light.
	/// </summary>
	public class RoomLight
	{
		private readonly RoomLightController _lightController;
		private Color? _defaultLightColor;

		private void SaveDefaultColor()
		{
			if (!_defaultLightColor.HasValue)
				_defaultLightColor = _lightController.OverrideColor;
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
				_lightController.OverrideColor = value;
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
		public RoomLight(RoomLightController lightController) => _lightController = lightController;
	}
}