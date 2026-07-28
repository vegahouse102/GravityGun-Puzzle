using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System.Runtime.CompilerServices;
public class MovingPlatform : MonoBehaviour
{
	[SerializeField]
	List<Transform> _platformMovePoints = new List<Transform>();
	[SerializeField]
	private float _velocity;
	[SerializeField]
	private float _endPosStopTime;
	[SerializeField]
	private bool _shouldStartMove;
	Sequence _movingSequence;


	private Vector3 _lastposition;
	[SerializeField]
	private Vector3 _moveDelta;
	private void Awake()
	{
		_movingSequence = DOTween.Sequence();
		for(int i = 1; i <  _platformMovePoints.Count; i++)
		{
			Vector3 cur = _platformMovePoints[i-1].position;
			Vector3 next = _platformMovePoints[i].position;
			_movingSequence.Append(transform.DOMove(next, GetMoveTime(cur,next,_velocity)).SetEase(Ease.Linear));
		}
		_movingSequence.AppendInterval(_endPosStopTime);
		for(int i =  _platformMovePoints.Count - 2; i >= 0; i--)
		{
			Vector3 cur = _platformMovePoints[i +1].position;
			Vector3 next = _platformMovePoints[i].position;
			_movingSequence.Append(transform.DOMove(next, GetMoveTime(cur, next, _velocity)).SetEase(Ease.Linear));
		}
		_movingSequence.AppendInterval(_endPosStopTime);
		_movingSequence.SetUpdate(UpdateType.Fixed);
		_movingSequence.SetLoops(-1);
		SetMove(_shouldStartMove);



		_lastposition = transform.position;

	}
	private void FixedUpdate()
	{
		_moveDelta = transform.position - _lastposition;
		_lastposition = transform.position;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.attachedRigidbody != null)
			Debug.Log("enter");
	}
	private void OnCollisionStay(Collision collision)
	{


		if (collision.collider.attachedRigidbody != null)
		{
			//Debug.Log("Platforming");
			collision.collider.attachedRigidbody.MovePosition(collision.collider.attachedRigidbody.position + _moveDelta);
		}else
		{
			collision.collider.transform.position += _moveDelta;
		}
	}

	public void SetMove(bool value)
	{
		if (value)
			_movingSequence.Play();
		else
			_movingSequence.Pause();
	}
	private float GetMoveTime(Vector3 a, Vector3 b, float velocity)
	{
		float distance = (b - a).magnitude;
		return distance / velocity;
	}
}
