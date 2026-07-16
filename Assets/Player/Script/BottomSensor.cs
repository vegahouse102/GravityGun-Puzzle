using UnityEngine;

public class BottomSensor : MonoBehaviour
{
	[SerializeField]
	private CapsuleCollider _collider;
	[SerializeField]
	private float _d;
	[SerializeField]
	private float _layDistance;
	[SerializeField]
	private LayerMask _groundMask;
	

	public bool IsGround { get; private set; }
	// Update is called once per frame
	void FixedUpdate()
	{
		IsGround = false;
		Vector3 bottom = new Vector3( _collider.bounds.center.x, _collider.bounds.min.y-_d, _collider.bounds.center.z); 
		Debug.DrawRay(bottom, Vector3.down * _layDistance);
		if (Physics.Raycast(bottom, Vector3.down, _layDistance, _groundMask)) 
		{
		
			IsGround = true;
		}
	}
}
