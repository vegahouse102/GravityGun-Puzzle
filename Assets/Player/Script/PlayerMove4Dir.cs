using UnityEngine;

public class PlayerMove4Dir : MonoBehaviour
{
	[SerializeField]
	PlayerInputGetter _inputGetter;
	[SerializeField]
	Rigidbody _rigid;
	[SerializeField]
	Transform _player;
	[SerializeField]
	float _speed;

	private void Update()
	{
		if (_inputGetter.Input.Player.Move.IsPressed())
		{
			Vector2 move = _inputGetter.Input.Player.Move.ReadValue<Vector2>();
			move *= _speed;
			_rigid.linearVelocity = _player.right * move.x + _player.forward * move.y + Vector3.up * _rigid.linearVelocity.y;
				//new Vector3(move.x, _rigid.linearVelocity.y, move.y);
		}
		
	}
}
