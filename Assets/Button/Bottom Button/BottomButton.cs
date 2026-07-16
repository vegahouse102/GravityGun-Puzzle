using System;
using UnityEngine;
using UnityEngine.Events;

public class BottomButton : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	private const string _PressedKey = "Pressed";
	private const string _UnPressedKey = "UnPressed";

	public UnityAction OnActivate;
	public UnityAction OnDeactivate;

	public void Pressed()
	{
		_animator.SetTrigger(_PressedKey);
		OnActivate?.Invoke();
	}
	public void UnPressed()
	{
		_animator.SetTrigger(_UnPressedKey);
		OnDeactivate?.Invoke();
	}
}
