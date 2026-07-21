
using System;
using UnityEngine;

public class GravityGun : MonoBehaviour
{

	[SerializeField]
	Transform _playerCamera;
	[SerializeField]
	Transform _gravityGunModel;
	[SerializeField]
	private float _cameraDelta;
	[SerializeField]
	private float _grabDistance;
	[SerializeField]
	private float _grabDistanceThreshold;
	[SerializeField]
	private float _maxGrabingDistance;
	[SerializeField]
	private float _grabingVelocity;
	[SerializeField]
	private float _FireForce;

	[SerializeField]
	AudioSource _fire;
	[SerializeField]
	AudioSource _grab;
	[SerializeField]
	AudioSource _grabbing;

	[SerializeField]
	private float _grabForce;

	[SerializeField]
	private LayerMask _grabableLayer;

	private Rigidbody _grabObject;

	private GravityGunState _curState;

	private const int _GrabingLayer = 7;
	private const int _GrabLayer = 6;
	private void Awake()
	{
		SetState(GravityGunState.Idle);
	}

	private void FixedUpdate()
	{
		switch (_curState)
		{
			case GravityGunState.Idle:
				HandleIdle();
				break;
			case GravityGunState.Grabing:
				HandleGrabing();
				break;
			case GravityGunState.Grab:
				HandleGrab();
				break;
			case GravityGunState.Fire:
				HandleFire();
				break;
		}
		//Debug.Log(_curState.ToString());
	}

	#region state
	private void SetState(GravityGunState state)
	{
		if(_curState!=GravityGunState.None)
			ExecuteEndState(_curState);

		_curState = state;
		ExecuteStartState(state);
	}

	private void ExecuteStartState(GravityGunState state)
	{
		switch (_curState)
		{
			case GravityGunState.Idle:
				//HandleIdle();
				break;
			case GravityGunState.Grabing:
				HandleGrabingStart();
				break;
			case GravityGunState.Grab:
				HandleGrabStart();
				break;
			case GravityGunState.Fire:
				HandleFireStart();
				break;
		}
	}
	private void ExecuteEndState(GravityGunState state)
	{
		switch (_curState)
		{
			case GravityGunState.Idle:
				//HandleIdle();
				break;
			case GravityGunState.Grabing:
				//HandleGrabingStart();
				break;
			case GravityGunState.Grab:
				HandleGrabEnd();
				break;
			case GravityGunState.Fire:
				//HandleFireStart();
				break;
		}
	}

	private void HandleFireStart()
	{
		_fire.Play();
	}

	private void HandleGrabStart()
	{
		_grab.Play();
	}

	private void HandleGrabingStart()
	{
		_grabbing.Play();
	}

	

	private void HandleGrabEnd()
	{
		_grab.Stop();
	}

	private void HandleIdle()
	{
		if (_grabObject != null)
		{
			PutGrabObject();
			_grabObject = null;
		}
	}

	private void HandleGrabing()
	{
		Vector3 dir = _playerCamera.forward;
		Vector3 start = _playerCamera.position +dir* _cameraDelta;
		Debug.DrawRay(start, dir*_maxGrabingDistance);

		if (Physics.Raycast(start, dir, out RaycastHit hit, _maxGrabingDistance))
		{
			if (((1 << hit.collider.gameObject.layer) & _grabableLayer.value) == 0)
				return;
			_grabObject = hit.rigidbody;
			if(_grabObject != null)
			{
				_grabObject.linearVelocity += -dir * _grabingVelocity*Time.deltaTime;
				if(_grabObject.linearVelocity.sqrMagnitude> _grabingVelocity* _grabingVelocity)
				{
					_grabObject.linearVelocity = -dir * _grabingVelocity;
				}
				//Debug.Log("grabbing");
			}
			else
			{
				//Debug.Log("Not grabbing");
			}
			if(Vector3.Distance(_grabObject.transform.position, _playerCamera.position) < _grabDistance)
			{
				SetState(GravityGunState.Grab);
				//_curState = GravityGunState.Grab;
			}
		}

	}

	private void HandleGrab()
	{
		if( _grabObject != null )
		{
			//_grabObject.transform.position = _playerCamera.forward * _grabDistance + _playerCamera.position;
			GrabGrabObject();
			Vector3 target =
			    _playerCamera.position +
			    _playerCamera.forward * _grabDistance;
			Vector3 force = (target - _grabObject.position) * _grabForce;

			_grabObject.AddForce(force, ForceMode.Acceleration);
			_grabObject.MoveRotation(Quaternion.identity);
			if (Vector3.Distance(_playerCamera.transform.position, _grabObject.transform.position) > _grabDistanceThreshold)
				SetState(GravityGunState.Idle);
		}
	}

	private void HandleFire()
	{
		if (_grabObject != null)
		{
			Vector3 dir = _playerCamera.forward;
			PutGrabObject();
			_grabObject.AddForce(dir * _FireForce, ForceMode.Impulse);
			SetState(GravityGunState.Idle);
		}
		else
		{
			Vector3 dir = _playerCamera.forward;
			Vector3 start = _playerCamera.position + dir * _cameraDelta;
			Debug.DrawRay(start, dir * _maxGrabingDistance);

			if (Physics.Raycast(start, dir, out RaycastHit hit, _maxGrabingDistance))
			{
				if (((1 << hit.collider.gameObject.layer) & _grabableLayer.value) == 0)
					return;
				hit.rigidbody.AddForce(dir * _FireForce, ForceMode.Impulse);
				SetState(GravityGunState.Idle);
			}
		}
	}
	#endregion
	private void PutGrabObject()
	{
		_grabObject.constraints = RigidbodyConstraints.None;
		//_grabObject.WakeUp();
		_grabObject.useGravity = true;
		_grabObject.gameObject.layer = _GrabLayer;
	}

	private void GrabGrabObject()
	{
		//_grabObject.constraints = RigidbodyConstraints.FreezeAll;
		//_grabObject.Sleep();
		_grabObject.gameObject.layer = _GrabingLayer;
		_grabObject.useGravity = false;
		_grabObject.linearVelocity = Vector3.zero;
		_grabObject.angularVelocity = Vector3.zero;
		//_grabObject.useGravity = false;
	}


	public void StartGrabInput()
	{
		if(_curState== GravityGunState.Idle)
		{
			SetState(GravityGunState.Grabing);
			//SetState(GravityGunState.Idle);
		}
		else if(_curState == GravityGunState.Grab)
		{
			SetState(GravityGunState.Idle);
		}
		//Debug.Log("StartGrabInput");
	}
	public void EndGrabInput()
	{
		if (_curState == GravityGunState.Grabing)
		{
			SetState(GravityGunState.Idle);
		}
	}

	public void StartFireInput()
	{
		SetState(GravityGunState.Fire);
	}
	public void EndFireInput()
	{
		SetState(GravityGunState.Idle);
	}


	
}

