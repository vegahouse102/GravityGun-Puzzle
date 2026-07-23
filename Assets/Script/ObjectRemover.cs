using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent<RemoveAndEffectObject>(out RemoveAndEffectObject removeAndEffectObject))
		{
			removeAndEffectObject.RemoveAndEffect();
		}
	}
}
