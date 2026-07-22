using UnityEngine;

public class GravityGunIdleState : Node
{
	[SerializeField]
	GravityGun _gravityGun;
	public override void OnStart()
	{
		if (_gravityGun.GetGrabObject() != null)
		{
			_gravityGun.PutGrabObject();
		}
	}
	public override void OnUpdate()
	{
		if (_gravityGun.Input.Input.Player.Grab.WasPressedThisFrame())
		{
			ChangeState(_gravityGun.GrabingNode);
		}
	}
}
