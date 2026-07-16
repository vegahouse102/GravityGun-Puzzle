using UnityEngine;
using DG.Tweening;
public class BottomButtonTest : MonoBehaviour
{
	[SerializeField]
	private BottomButton button;
	void Start()
	{
		Sequence sequence = DOTween.Sequence();
		sequence.AppendCallback(button.Pressed);
		sequence.AppendInterval(2f);
		sequence.AppendCallback(button.UnPressed);
		sequence.AppendInterval(2f);
		sequence.SetLoops(-1);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
