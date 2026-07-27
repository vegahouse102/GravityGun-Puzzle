using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class BottomButtonSensor : MonoBehaviour
{
	[SerializeField]
	string _tag;
	public UnityEvent OnDetect;
	public UnityEvent OnClear;


	private HashSet<GameObject> _pressedObject = new();
	private void OnTriggerEnter(Collider other)
	{

		if (!other.CompareTag(_tag))
			return;
		if (_pressedObject.Contains(other.gameObject))
			return;

		if (_pressedObject.Count == 0)
			OnDetect?.Invoke();

		_pressedObject.Add(other.gameObject);

		if (other.gameObject.TryGetComponent<RemoveAndEffectObject>(out RemoveAndEffectObject removeAndEffect))
		{
			removeAndEffect.OnRemoveStart += HandleRemovedObject;
		}
		
	}

	private void OnTriggerExit(Collider other)
	{

		if (!other.CompareTag(_tag))
			return;
		if (!_pressedObject.Contains(other.gameObject))
			return;


		_pressedObject.Remove(other.gameObject);
		if (other.gameObject.TryGetComponent<RemoveAndEffectObject>(out RemoveAndEffectObject removeAndEffect))
		{
			removeAndEffect.OnRemoveStart -= HandleRemovedObject;
		}
		if (_pressedObject.Count == 0)
			OnClear?.Invoke();


	}
	private void HandleRemovedObject(GameObject removedObject)
	{
		if (removedObject.TryGetComponent(out RemoveAndEffectObject remove))
			remove.OnRemoveStart -= HandleRemovedObject;

		_pressedObject.Remove(removedObject);

		if (_pressedObject.Count == 0)
			OnClear?.Invoke();
	}

}
