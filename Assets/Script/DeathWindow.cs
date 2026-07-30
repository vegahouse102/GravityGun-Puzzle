using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DeathWindow : MonoBehaviour
{
	[SerializeField]
	private Image _image;
	[SerializeField]
	private float _transitionTime;
	[SerializeField]
	private float _waitTime;

	private bool _isDeath;
	private 
	void Start()
	{
		GameManager.Instance.OnPlayerDeath += Death;
	}
	private void OnDestroy()
	{
		GameManager.Instance.OnPlayerDeath -= Death;
	}

	// Update is called once per frame
	public void Death()
	{
		if (_isDeath)
			return;
		_isDeath = true;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(_image.DOColor(new Color(1, 0, 0, 0.6f), _transitionTime));
		sequence.AppendInterval(_waitTime);
		sequence.AppendCallback(()=>TransitionManager.Instance.RestartScene());
	}
}
