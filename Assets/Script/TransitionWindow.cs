using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class TransitionWindow : MonoBehaviour
{
	[SerializeField]
	Image _image;
	[SerializeField]
	TMPro.TextMeshProUGUI _text;


	bool _isTransitioning;

	public void Start()
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
		sequence.AppendCallback(()=>_text.gameObject.SetActive(true));

		Sequence tmp = DOTween.Sequence();
		tmp.AppendCallback(()=>_text.text = "LOADING.");
		tmp.AppendInterval(.1f);
		tmp.AppendCallback(() => _text.text = "LOADING..");
		tmp.AppendInterval(.1f);
		tmp.AppendCallback(() => _text.text = "LOADING...");
		tmp.AppendInterval(.1f);
		//tmp.SetUpdate(true);
		tmp.SetLoops(-1);
		sequence.Append(tmp);
		//sequence.SetUpdate(true);

	}
	public void SetTransitionSceneProgress(float progress01)
	{

	}
}
