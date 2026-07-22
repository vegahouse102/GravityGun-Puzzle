using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClearTrigger : MonoBehaviour
{
	[SerializeField]
	private LayerMask _clearMask;

	public UnityEvent OnClear;
	private bool _cleared;

	private void OnTriggerEnter(Collider other)
	{
		if (_cleared)
			return;
		if ((_clearMask & (1 << other.gameObject.layer)) != 0)
		{
			_cleared = true;
			string name = SceneManager.GetActiveScene().name;
			GameManager.Instance.ClearLevel(name);
			OnClear?.Invoke();
		}
	}
}
