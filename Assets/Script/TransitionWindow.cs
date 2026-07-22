using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class TransitionWindow : MonoBehaviour
{
	[SerializeField]
	Image _image;
	[SerializeField]
	float _imageTransitionTime;
	[SerializeField]
	TMPro.TextMeshProUGUI _text;


	bool _isTransitioning;

	public void Awake()
	{
		TransitionManager.Instance.OnStartTransition += StartTransitionScene;
	}
	public void OnDestroy()
	{
		TransitionManager.Instance.OnStartTransition -= StartTransitionScene;
	}
	public void StartTransitionScene()
	{
		if (_isTransitioning)
			return;
		_isTransitioning = true;
		gameObject.SetActive(true);
		Sequence sequence = DOTween.Sequence();
		sequence.Append(_image.DOColor( new Color(0, 0, 0, 1), _imageTransitionTime)
			.SetEase(Ease.InCubic));
		sequence.AppendCallback(()=>_text.gameObject.SetActive(true));

		Sequence tmp = DOTween.Sequence();
		tmp.AppendCallback(()=>_text.text = "LOADING.");
		tmp.AppendInterval(1f);
		tmp.AppendCallback(() => _text.text = "LOADING..");
		tmp.AppendInterval(1f);
		tmp.AppendCallback(() => _text.text = "LOADING...");
		tmp.AppendInterval(1f);
		tmp.SetLoops(-1);
		sequence.Append(tmp);

	}
	public void SetTransitionSceneProgress(float progress01)
	{

	}
}
