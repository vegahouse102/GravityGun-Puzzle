using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	[SerializeField]
	PlayerInputGetter _input;
	[SerializeField]
	Rigidbody _rb;
	[SerializeField]
	float _jumpVelocity;
	private void Update()
	{
		if (_input.Input.Player.Jump.WasPressedThisFrame())
		{
			_rb.linearVelocity = new Vector3(_rb.linearVelocity.x,_jumpVelocity, _rb.linearVelocity.z);
			Debug.Log("asdfasdf");
		}
	}
}
