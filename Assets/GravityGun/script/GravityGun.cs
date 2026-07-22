
using System;
using UnityEngine;

public class GravityGun : MonoBehaviour
{


	[SerializeField]
	PlayerInputGetter _input;
	[SerializeField]
	Transform _playerCamera;

	[SerializeField]
	private float _cameraDelta;
	[SerializeField]
	private float _grabDistance;
	[SerializeField]
	private float _grabDistanceThreshold;

	[SerializeField]
	private float _grabForce;
	[SerializeField]
	private float _maxGrabingDistance;
	[SerializeField]
	private float _grabingVelocity;
	[SerializeField]
	private float _maxFireDistance;

	[SerializeField]
	private float _fireForce;


	[SerializeField]
	private LayerMask _grabableLayer;

	public PlayerInputGetter Input => _input;
	public Transform PlayerCamera => _playerCamera;

	public float CameraDelta => _cameraDelta;

	public float GrabDistance => _grabDistance;

	public float GrabDistanceThreshold => _grabDistanceThreshold;

	public float MaxGrabingDistance => _maxGrabingDistance;

	public float MaxFireDistance => _maxFireDistance;

	public float GrabingVelocity => _grabingVelocity;

	public float FireForce => _fireForce;

	public float GrabForce => _grabForce;

	public LayerMask GrabableLayer => _grabableLayer;


	[SerializeField]
	Node _IdleNode;
	[SerializeField]
	Node _grabNode;
	[SerializeField]
	Node _grabingNode;
	[SerializeField]
	Node _fireNode;

	public Node IdleNode => _IdleNode;

	public Node GrabNode => _grabNode;

	public Node GrabingNode => _grabingNode;

	public Node FireNode => _fireNode;


	private Rigidbody _grabObject;


	private const int _GrabingLayer = 7;
	private const int _GrabLayer = 6;




	private StateMachine _statemachine;
	private void Awake()
	{
		_statemachine = new StateMachine(_IdleNode);

	}

	private void FixedUpdate()
	{
		_statemachine.OnFixedUpdate();

	}
	private void Update()
	{
		_statemachine.OnUpdate();
		if (Input.Input.Player.Fire.WasPressedThisFrame())
		{
			_statemachine.ChangeState(_fireNode);
		}
	}

	public void PutGrabObject()
	{
		_grabObject.constraints = RigidbodyConstraints.None;
		//_grabObject.WakeUp();
		_grabObject.useGravity = true;
		_grabObject.gameObject.layer = _GrabLayer;
		_grabObject = null;
	}

	public void GrabGrabObject()
	{
		//_grabObject.constraints = RigidbodyConstraints.FreezeAll;
		//_grabObject.Sleep();
		_grabObject.gameObject.layer = _GrabingLayer;
		_grabObject.useGravity = false;
		_grabObject.linearVelocity = Vector3.zero;
		_grabObject.angularVelocity = Vector3.zero;
		//_grabObject.useGravity = false;
	}
	public Rigidbody GetGrabObject()
	{
		return _grabObject;
	}
	public void SetGrabObject(Rigidbody grabObject)
	{
		_grabObject = grabObject; ;
	}

	public void StartGrabInput()
	{
	}
	public void EndGrabInput()
	{
	}



	
}

