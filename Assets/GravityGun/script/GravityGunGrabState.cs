using UnityEngine;

public class GravityGunGrabState : Node
{

	[SerializeField]
	private GravityGun _gravityGun;


	[SerializeField]
	AudioSource _grab;

	public override void OnStart()
	{
		_grab.Play();
	}
	public override void OnFixedUpdate()
	{
		if (_gravityGun.GetGrabObject()!= null)
		{
			//grabObject.transform.position = _playerCamera.forward * _grabDistance + _playerCamera.position;
			_gravityGun.GrabGrabObject();
			Vector3 target =
			   _gravityGun.PlayerCamera.position +
			    _gravityGun.PlayerCamera.forward * _gravityGun.GrabDistance;
			Rigidbody grabObject = _gravityGun.GetGrabObject();
			Vector3 force = (target - grabObject.position) * _gravityGun.GrabForce;

			grabObject.AddForce(force, ForceMode.Acceleration);
			grabObject.MoveRotation(Quaternion.identity);
			if (Vector3.Distance(_gravityGun.PlayerCamera.transform.position, grabObject.transform.position) > _gravityGun.GrabDistanceThreshold)
				ChangeState(_gravityGun.IdleNode);
			//SetState(GravityGunState.Idle);
		}
	}
	public override void OnUpdate()
	{
		if (_gravityGun.Input.Input.Player.Grab.WasPressedThisFrame())
		{
			ChangeState(_gravityGun.IdleNode);
		}
	}
	public override void OnEnd()
	{
		_grab.Stop();
	}
}
