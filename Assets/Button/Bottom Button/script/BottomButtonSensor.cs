using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class BottomButtonSensor : MonoBehaviour
{
	[SerializeField]
	string _tag;
	public UnityEvent OnDetect;
	public UnityEvent OnClear;

	private int count;

	private void OnTriggerEnter(Collider other)
	{

		if (!other.CompareTag(_tag))
			return;
		if (count == 0)
			OnDetect?.Invoke();
		count++;
		
	}

	private void OnTriggerExit(Collider other)
	{

		if (!other.CompareTag(_tag))
			return;
		count--;
		if (count == 0)
			OnClear?.Invoke();


	}
}
