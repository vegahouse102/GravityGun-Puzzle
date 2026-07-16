using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class BottomButtonSensor : MonoBehaviour
{
	[SerializeField]
	List<string> strs = new();
	public UnityEvent OnDetect;
	public UnityEvent OnClear;

	private int count;

	private void OnTriggerEnter(Collider other)
	{


		if (strs.Contains(other.name))
		{
			if (count == 0)
				OnDetect?.Invoke();
			count++;
		}
	}

	private void OnTriggerExit(Collider other)
	{

		if (strs.Contains(other.name))
		{
			count--;
			if (count == 0)
				OnClear?.Invoke();
		}

	}
}
