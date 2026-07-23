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

	[SerializeField]
	AudioSource _erase;
	private bool _isRemove;

	public event Action OnRemoveStart;
	public event Action OnRemoveEnd;
	public Sequence RemoveAndEffect()
	{
		if (_isRemove)
			return DOTween.Sequence();
		_isRemove = true;



		_erase?.Play();

		_rigid.useGravity = false;
		_renderer.material.color = Color.red;
		Sequence sequence = DOTween.Sequence();
		sequence.AppendCallback(() => { gameObject.layer = 11; });// 지워지면 못잡는다.
		sequence.AppendCallback(() => OnRemoveStart?.Invoke());
		sequence.Append(DOTween.To(
			() => _renderer.material.color,
			(Color color) => _renderer.material.color = color,
			new Color(0, 0, 0, 1),
			_time
		));

		sequence.AppendCallback(()=> OnRemoveEnd?.Invoke());
		sequence.AppendCallback(()=>Destroy(gameObject));
		return sequence;
	}
}
