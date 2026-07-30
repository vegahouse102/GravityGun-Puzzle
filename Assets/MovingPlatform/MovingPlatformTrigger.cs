using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour
{
	[SerializeField]
	MovingPlatform MovingPlatform;
	private void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent<CharacterController>(out CharacterController controller))
		{
			//Debug.Log("Player");
			controller.Move (MovingPlatform.GetMoveDelta());
		}
		else if (other.attachedRigidbody != null)
		{
			//Debug.Log("Platforming");
			other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + MovingPlatform.GetMoveDelta());
		}
		//Debug.Log(other);
	}

}
