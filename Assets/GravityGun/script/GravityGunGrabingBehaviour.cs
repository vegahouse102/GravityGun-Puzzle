using UnityEngine;

public class GravityGunGrabingState : Node
{
	[SerializeField]
	GravityGun _gravityGun;

	[SerializeField]
	AudioSource _grabbing;

	public override void OnStart()
	{
		_grabbing.Play();
	}
	public override void OnFixedUpdate()
	{
		Vector3 dir = _gravityGun.PlayerCamera.forward;
		Vector3 start = _gravityGun.PlayerCamera.position + dir * _gravityGun.CameraDelta;
		Debug.DrawRay(start, dir * _gravityGun.MaxGrabingDistance);

		if (Physics.Raycast(start, dir, out RaycastHit hit, _gravityGun.MaxGrabingDistance))
		{
			if (((1 << hit.collider.gameObject.layer) & _gravityGun.GrabableLayer.value) == 0)
				return;
			_gravityGun.SetGrabObject(hit.rigidbody);
			Rigidbody grabObject = hit.rigidbody;
			if (grabObject != null)
			{
				grabObject.linearVelocity += -dir * _gravityGun.GrabingVelocity * Time.deltaTime;
				if (grabObject.linearVelocity.sqrMagnitude > _gravityGun.GrabingVelocity * _gravityGun.GrabingVelocity)
				{
					grabObject.linearVelocity = -dir * _gravityGun.GrabingVelocity;
				}
				//Debug.Log("grabbing");
			}
			else
			{
				//Debug.Log("Not grabbing");
			}
			if (Vector3.Distance(grabObject.transform.position, _gravityGun.PlayerCamera.position) < _gravityGun.GrabDistance)
			{
				ChangeState(_gravityGun.GrabNode);
				//SetState(GravityGunState.Grab);
				//_curState = GravityGunState.Grab;
			}
		}
	}

	public override void OnUpdate()
	{
		if (_gravityGun.Input.Input.Player.Grab.WasReleasedThisFrame())
		{
			ChangeState(_gravityGun.IdleNode);
		}
	}
}
