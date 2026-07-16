using System;
using UnityEngine;

public class GravityGun : MonoBehaviour
{

	[SerializeField]
	Transform _playerCamera;
	[SerializeField]
	private float _grabDistance;
	[SerializeField]
	private float _maxGrabingDistance;
	[SerializeField]
	private float _grabVelocity;
	[SerializeField]
	private float _FireForce;

	[SerializeField]
	private LayerMask _grabLayer;

	private Rigidbody _grabObject;

	private State _curState;
	private void Awake()
	{
		_curState = State.Idle;
	}

	private void FixedUpdate()
	{
		switch (_curState)
		{
			case State.Idle:
				HandleIdle();
				break;
			case State.Grabing:
				HandleGrabing();
				break;
			case State.Grab:
				HandleGrab();
				break;
			case State.Fire:
				HandleFire();
				break;
		}
		Debug.Log(_curState.ToString());
	}

	private void HandleIdle()
	{
		if (_grabObject != null)
		{
			_grabObject.constraints = RigidbodyConstraints.None;
			_grabObject.WakeUp();
			_grabObject = null;
		}
	}

	private void HandleGrabing()
	{
		Vector3 dir = _playerCamera.forward;
		Debug.DrawRay(_playerCamera.position, dir*_maxGrabingDistance);
		if(Physics.Raycast(_playerCamera.position, dir, out RaycastHit hitInfo,_maxGrabingDistance,_grabLayer))
		{
			_grabObject = hitInfo.rigidbody;
			Rigidbody grabingObjectRigid = hitInfo.rigidbody;
			if(grabingObjectRigid != null)
			{
				grabingObjectRigid.linearVelocity += -dir * _grabVelocity*Time.fixedDeltaTime;
				if(grabingObjectRigid.linearVelocity.sqrMagnitude> _grabVelocity* _grabVelocity)
				{
					grabingObjectRigid.linearVelocity = -dir * _grabVelocity;
				}
				Debug.Log("grabbing");
			}
			else
			{
				Debug.Log("Not grabbing");
			}
			if(Vector3.Distance(_grabObject.transform.position, _playerCamera.position) < _grabDistance)
			{
				_curState = State.Grab;
			}
		}

	}

	private void HandleGrab()
	{
		if( _grabObject != null )
		{
			_grabObject.transform.rotation = Quaternion.identity;
			Vector3 dir =_playerCamera.forward;
			_grabObject.transform.position = dir * _grabDistance + _playerCamera.position;
			_grabObject.constraints = RigidbodyConstraints.FreezeAll;
			_grabObject.Sleep();
		}
	}

	private void HandleFire()
	{

	}

	public void StartGrabInput()
	{
		if(_curState== State.Idle)
		{
			_curState = State.Grabing;
		}
		else if(_curState == State.Grab)
		{
			_curState = State.Idle;
		}
		Debug.Log("StartGrabInput");
	}
	public void EndGrabInput()
	{
		if (_curState == State.Grabing)
		{
			_curState = State.Idle;
		}
	}

	public void StartFireInput()
	{
		_curState = State.Fire;
	}
	public void EndFireInput()
	{
		_curState = State.Idle;
	}


	private enum State
	{
		Idle,
		Grabing,
		Grab,
		Fire
	}
}
