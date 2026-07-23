using UnityEngine;

public class GravityGunFireState : Node
{


	[SerializeField]
	private GravityGun _gravityGun;



	[SerializeField]
	AudioSource _fire;




	public override void OnStart()
	{
		_fire.Play();
		if (_gravityGun.GetGrabObject() != null)
		{
			Vector3 dir = _gravityGun.PlayerCamera.forward;
			_gravityGun.GetGrabObject().AddForce(dir * _gravityGun.FireForce, ForceMode.Impulse);
			//ChangeState(_gravityGun.IdleNode);
		}
		else
		{
			Vector3 dir = _gravityGun.PlayerCamera.forward;
			Vector3 start = _gravityGun.PlayerCamera.position + dir * _gravityGun.CameraDelta;
			Debug.DrawRay(start, dir * _gravityGun.MaxFireDistance);

			if (Physics.Raycast(start, dir, out RaycastHit hit, _gravityGun.MaxFireDistance))
			{
				if (((1 << hit.collider.gameObject.layer) & _gravityGun.GrabableLayer.value) == 0)
				{
					ChangeState(_gravityGun.IdleNode);
					return;
				}
				hit.rigidbody.AddForce(dir * _gravityGun.FireForce, ForceMode.Impulse);

			}
			
		}
		ChangeState(_gravityGun.IdleNode);
	}
	public override void OnFixedUpdate()
	{

	}

}
