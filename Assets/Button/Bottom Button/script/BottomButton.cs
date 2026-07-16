using System;
using UnityEngine;
using UnityEngine.Events;

public class BottomButton : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	private const string _PressedKey = "Pressed";
	private const string _UnPressedKey = "UnPressed";

	public UnityEvent<bool> OnActivate;

	public void Pressed()
	{
		_animator.SetTrigger(_PressedKey);
		OnActivate?.Invoke(true);
	}
	public void UnPressed()
	{
		_animator.SetTrigger(_UnPressedKey);
		OnActivate?.Invoke(false);
	}
}
