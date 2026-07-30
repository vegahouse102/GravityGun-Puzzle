using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("contact");
		if(other.TryGetComponent<CharacterController>(out CharacterController characterController))
		{
			GameManager.Instance.HandlePlayerDeath();
		}
	}
}
