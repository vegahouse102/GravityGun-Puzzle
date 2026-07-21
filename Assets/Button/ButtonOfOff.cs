using UnityEngine;
using UnityEngine.Events;

public class ButtonOfOff : MonoBehaviour
{
	public UnityEvent OnActive;
	public UnityEvent OnDisabled;
	public void SetActive(bool active)
	{
		if (active)
			OnActive?.Invoke();
		else
		{
			OnDisabled?.Invoke();
		}
	}
}
