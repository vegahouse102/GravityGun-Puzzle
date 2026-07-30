using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	[SerializeField]
	AudioSource _deathAudio;
	void Start()
	{
		GameManager.Instance.OnPlayerDeath += Death;
	}
	private void OnDestroy()
	{

		GameManager.Instance.OnPlayerDeath -= Death;
	}

	private void Death()
	{
		_deathAudio.Play();
		gameObject.SetActive(false);
	}
}
