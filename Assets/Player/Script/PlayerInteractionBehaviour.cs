using UnityEngine;

public class PlayerInteractionBehaviour : MonoBehaviour
{
	[SerializeField]
	PlayerInputGetter _input;
	[SerializeField]
	Transform _camera;
	[SerializeField]
	private float _maxInteractionDistance;
	[SerializeField]
	private LayerMask _layer;
	void Update()
	{
		if (_input.Input.Player.Interaction.WasPressedThisFrame())
		{
			Vector3 pos = _camera.transform.position;
			
			Debug.DrawRay(pos, _camera.forward * _maxInteractionDistance);
			if (Physics.Raycast(pos,_camera.forward,out RaycastHit hit,_maxInteractionDistance,_layer))
			{
				Rigidbody rigid = hit.collider.attachedRigidbody;

				if (rigid != null)
				{
					InterationBehaviour interation =  rigid.gameObject.GetComponent<InterationBehaviour>();
					interation?.Interacte();
				}
			}
		}
	}
}
