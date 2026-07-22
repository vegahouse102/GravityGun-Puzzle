using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	PlayerInputGetter _inputGetter;
	[SerializeField]
	CharacterController _controller;
	[SerializeField]
	Transform _player;
	[SerializeField]
	float _jumpHeight = 2f;
	[SerializeField]
	float _walkSpeed;
	[SerializeField]
	float _runSpeed;


	float _verticalVelocity;
	float _gravity = -9.8f;

	private void Update()
	{
		Vector3 velocity = Vector3.zero;

		Vector2 move = _inputGetter.Input.Player.Move.ReadValue<Vector2>();

		if (_inputGetter.Input.Player.Sprint.IsPressed())
			move *= _runSpeed;
		else
			move *= _walkSpeed;

		velocity = _player.right*move.x + _player.forward*move.y;


		if (_controller.isGrounded)
		{
			if (_verticalVelocity < 0)
				_verticalVelocity = -2f;

			if (_inputGetter.Input.Player.Jump.IsPressed())
			{
				_verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
			}
		}

		_verticalVelocity += _gravity * Time.deltaTime;

		velocity.y = _verticalVelocity;

		_controller.Move(velocity * Time.deltaTime);
	}
}
