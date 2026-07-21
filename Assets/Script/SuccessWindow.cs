using DG.Tweening;
using TMPro;
using UnityEngine;

public class SuccessWindow : MonoBehaviour
{
	[SerializeField]
	ClearTrigger _trigger;
	[SerializeField]
	TextMeshProUGUI _text;
	[SerializeField]
	float _effectTime;
	bool _isSuccess;
	public void Awake()
	{
		_trigger.OnClear += Success;
	}

	public void OnDestroy()
	{
		_trigger.OnClear -= Success;
	}
	public void Success()
	{
		if (_isSuccess)
			return;
		_isSuccess = true;
		Sequence sequence = DOTween.Sequence();
		sequence.AppendCallback(SuccessEfffect);
		sequence.AppendInterval(_effectTime);
		sequence.AppendCallback(()=>TransitionManager.Instance.StartTransition("LevelSelect"));
	}


	private void SuccessEfffect()
	{
		//Time.timeScale = 0f;
		_text.gameObject.SetActive(true);
	}
}
