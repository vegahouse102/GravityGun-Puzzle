using UnityEngine;
using UnityEngine.Events;

public class PowerReceiver : MonoBehaviour
{
	public UnityEvent<bool> OnActivate;
	private int _curOnCount;

	public void SetPower(bool value)
	{
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
	}
}
