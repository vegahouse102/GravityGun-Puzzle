using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClearTrigger : MonoBehaviour
{
	[SerializeField]
	private LayerMask _clearMask;

	public UnityEvent OnClear;

	private void OnTriggerEnter(Collider other)
	{
		if ((_clearMask & (1 << other.gameObject.layer)) != 0)
		{
			string name = SceneManager.GetActiveScene().name;
			GameManager.Instance.ClearLevel(name);
			OnClear?.Invoke();
		}
	}
}
