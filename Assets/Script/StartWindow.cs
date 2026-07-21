using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
	[SerializeField]
	Image _image;
	[SerializeField]
	float time;
	[SerializeField]
	Ease ease;
	public void Start()
	{
		_image.DOColor(new Color(0, 0, 0, 0), time)
			.SetEase(ease); ;
	}
}
