using UnityEngine;
using UnityEngine.Events;

public class Wire : MonoBehaviour
{
	[SerializeField]
	Renderer _render;
	bool _curState;

	public UnityEvent<bool> OnActivate;
	private void Awake()
	{
		_render.material.color = Color.black;
	}
	public void SetActive(bool value)
	{
		if (value == _curState)
			return;
		_curState = value;
		OnActivate?.Invoke(_curState);
		if (_curState)
			_render.material.color = Color.red;
		else
			_render.material.color = Color.black;
	}
}
