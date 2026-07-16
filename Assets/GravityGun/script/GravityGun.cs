
using UnityEngine;

public class GravityGun : MonoBehaviour
{

	[SerializeField]
	Transform _playerCamera;
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
	private float _grabForce;

	[SerializeField]
	private LayerMask _grabableLayer;

	private Rigidbody _grabObject;

	private GravityGunState _curState;

	private const int _GrabingLayer = 7;
	private const int _GrabLayer = 6;
	private void Awake()
	{
		_curState = GravityGunState.Idle;
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
				Debug.Log("grabbing");
			}
			else
			{
				Debug.Log("Not grabbing");
			}
			if(Vector3.Distance(_grabObject.transform.position, _playerCamera.position) < _grabDistance)
			{
				_curState = GravityGunState.Grab;
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
				_curState = GravityGunState.Idle;
		}
	}

	private void HandleFire()
	{
		if (_grabObject != null)
		{
			Vector3 dir = _playerCamera.forward;
			PutGrabObject();
			_grabObject.AddForce(dir * _FireForce, ForceMode.Impulse);
			_curState = GravityGunState.Idle;
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
				_curState = GravityGunState.Idle;
			}
		}
	}

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
			_curState = GravityGunState.Grabing;
		}
		else if(_curState == GravityGunState.Grab)
		{
			_curState = GravityGunState.Idle;
		}
		//Debug.Log("StartGrabInput");
	}
	public void EndGrabInput()
	{
		if (_curState == GravityGunState.Grabing)
		{
			_curState = GravityGunState.Idle;
		}
	}

	public void StartFireInput()
	{
		_curState = GravityGunState.Fire;
	}
	public void EndFireInput()
	{
		_curState = GravityGunState.Idle;
	}


	
}

