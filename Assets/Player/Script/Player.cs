using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
	private PlayerInput _input;

	private void Awake()
	{
		_input = new PlayerInput();
	}

	private void OnEnable()
	{
		_input.Enable();
	}

	private void OnDisable()
	{
		_input.Disable();
	}

	private void Update()
	{
		Vector2 move = _input.Player.Move.ReadValue<Vector2>();

		if (_input.Player.Jump.WasPressedThisFrame())
		{
			
		}

		if (_input.Player.Grab.IsPressed())
		{
			
		}

		if (_input.Player.Fire.WasPressedThisFrame())
		{
			
		}
	}
}
