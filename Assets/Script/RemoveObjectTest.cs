using DG.Tweening;
using UnityEngine;

public class RemoveObjectTest : MonoBehaviour
{
	[SerializeField]
	RemoveAndEffectObject _removeObject;
	[SerializeField]
	float time;
	void Start()
	{
		Sequence sequence = DOTween.Sequence();
		sequence.AppendInterval(time);
		sequence.Append(_removeObject.RemoveAndEffect());
	}

	// Update is called once per frame
	void Update()
	{

	}
}
