using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	[SerializeField]
	PlayerInputGetter _input;
	[SerializeField]
	Transform _player;

	[SerializeField]
	Transform _camera;

	[SerializeField]
	float _sensitivity;
	float _pitch;
	private void FixedUpdate()
	{
		Vector2 lookDelta = _input.Input.Player.Look.ReadValue<Vector2>();
		_player.Rotate(Vector3.up * lookDelta.x * _sensitivity * Time.fixedDeltaTime);
		_pitch -= lookDelta.y * _sensitivity * Time.fixedDeltaTime;
		_pitch = Mathf.Clamp(_pitch, -80f, 80f);

		_camera.localRotation = Quaternion.Euler(_pitch, 0, 0);
	}
	public void SetSensitivity(float sensitivity)
	{
		_sensitivity = sensitivity;
	}
}
