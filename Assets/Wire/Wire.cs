using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
	[SerializeField]
	Renderer _render;
	[SerializeField]
	PowerReceiver _myReceiver;
	[SerializeField]
	private List<PowerReceiver> _nearPowerReceiver = new();
	bool _curState;
	private void Awake()
	{
		_render.material.color = Color.black;
		foreach(var receiver in _nearPowerReceiver)
		{
			_myReceiver.OnRelaySignal.AddListener(receiver.SetPower);
			receiver.OnRelaySignal.AddListener(_myReceiver.SetPower);
		}
	}
	public void SetActive(bool value)
	{
		if (value == _curState)
			return;
		_curState = value;
		if (_curState)
			_render.material.color = Color.red;
		else
			_render.material.color = Color.black;
	}
}
