using UnityEngine;
using UnityEngine.Events;
public class PowerReceiver : MonoBehaviour
{
	public UnityEvent<bool> OnActivate;
	public UnityEvent<bool> OnRelaySignal;
	private int _curOnCount;
	private bool _isSetting;
	public void SetPower(bool value)
	{
		if (_isSetting)
			return;
		_isSetting = true ;
		if (value)
		{
			if (_curOnCount == 0)
				OnActivate?.Invoke(true);
			_curOnCount++;
		}
		else
		{
			_curOnCount--;
			if (_curOnCount == 0)
			{
				OnActivate?.Invoke(false);
			}
		}
		OnRelaySignal?.Invoke(value);
		_isSetting = false;
	}
}
