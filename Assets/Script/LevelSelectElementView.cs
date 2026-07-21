using UnityEngine;

public class LevelSelectElementView : MonoBehaviour
{
	[SerializeField]
	private LevelSO testSO;
	[SerializeField]
	private TMPro.TextMeshProUGUI _levelNumber;
	private LevelSO _curLevelSO;
	private void Awake()
	{
		if(testSO != null) 
			SetLevelSO(testSO);
	}
	public void SetLevelSO(LevelSO levelSO)
	{
		_curLevelSO = levelSO;
	}
	public void SetLevelNumber(int number)
	{
		_levelNumber.text = number.ToString();
	}

	public void HandleSelectedLevelSO()
	{
		TransitionManager.Instance.StartTransition(_curLevelSO.LevelName);
	}
}
