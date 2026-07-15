using UnityEngine;

public class PlayerGravityGunInput: MonoBehaviour
{
	[SerializeField]
	PlayerInputGetter _input;
	[SerializeField]
	GravityGun _gun;

	void Update()
	{
		if (_input.Input.Player.Grab.WasPressedThisFrame())
		{
			_gun.StartGrabInput();
		}
		if(_input.Input.Player.Grab.WasReleasedThisFrame())
		{
			_gun.EndGrabInput();
		}



		if (_input.Input.Player.Fire.WasPressedThisFrame())
		{
			_gun.StartFireInput();
		}
		if (_input.Input.Player.Fire.WasReleasedThisFrame())
		{
			_gun.EndFireInput();
		}
	}
}
