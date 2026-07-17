using UnityEngine;
using DG.Tweening;
using System;
public class RemoveAndEffectObject : MonoBehaviour
{


	[SerializeField]
	Renderer _renderer;
	[SerializeField]
	Rigidbody _rigid;
	[SerializeField]
	private float _time;
	private bool _isRemove;


	public Action OnRemove;
	public Sequence RemoveAndEffect()
	{
		if (_isRemove)
			return DOTween.Sequence();
		_isRemove = true;

		


		_rigid.useGravity = false;
		_renderer.material.color = Color.red;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(DOTween.To(
			() => _renderer.material.color,
			(Color color) => _renderer.material.color = color,
			new Color(0, 0, 0, 1),
			_time
		));

		sequence.AppendCallback(()=> OnRemove?.Invoke());
		sequence.AppendCallback(()=>Destroy(gameObject));
		return sequence;
	}
}
