using UnityEngine;

public class LevelSelectElementView : MonoBehaviour
{
	[SerializeField]
	private TMPro.TextMeshProUGUI _levelNumber;
	private int _curLevelNumber;
	private void Awake()
	{

	}
	public void SetLevelNumber(int number)
	{
		_curLevelNumber = number;
		_levelNumber.text = number.ToString();
	}

	public void HandleSelectedLevelSO()
	{
		TransitionManager.Instance.StartTransition(_curLevelNumber.ToString());
	}
}
