using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class InteractionButton : InterationBehaviour
{
	[SerializeField]
	private Animator _animator;
	[SerializeField]
	private float _interactionTime;

	[SerializeField]
	private ButtonOfOff _ofoff;
	private const string _interactionKey = "Interaction";
	public UnityEvent<bool> OnInteraction;



	Sequence _curSequence;
	public override void Interacte()
	{
		if (_curSequence != null && _curSequence.IsPlaying())
			return;
		_curSequence = DOTween.Sequence();
		_curSequence.AppendCallback(() =>
		{
			_animator.SetTrigger(_interactionKey);
			_ofoff.SetActive(true);
			OnInteraction?.Invoke(true);
		});
		_curSequence.AppendInterval(_interactionTime);
		_curSequence.AppendCallback(() =>
		{
			OnInteraction?.Invoke(false);
		});


	}


}
