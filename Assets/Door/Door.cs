using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour
{
	[SerializeField]
	Animator _animator;
	private const string _openKey = "Open";
	private const string _closeKey = "Close";
	public void SetActive(bool value)
	{
		if (value)
		{
			_animator.SetTrigger(_openKey);
		}
		else
		{
			_animator.SetTrigger(_closeKey);
		}
	}
}
