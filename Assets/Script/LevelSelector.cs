using UnityEngine;

public class LevelSelector : MonoBehaviour
{
	[SerializeField]
	GameObject _levelSelectElement;
	public void Start()
	{
		CreateLevelEelements();
	}


	private void CreateLevelEelements()
	{
		LevelsSO levelsSO = GameManager.Instance.GetLevelsSO();
		int lastNumber = GameManager.Instance.GetLastClearLevel();
		for(int i = 1; i <= lastNumber; i++)
		{
			GameObject element = Instantiate(_levelSelectElement, transform);
			LevelSelectElementView view = element.GetComponent<LevelSelectElementView>();
			view.SetLevelNumber(i);
		}
		if (lastNumber < levelsSO.MaxLevel)
		{
			GameObject element = Instantiate(_levelSelectElement, transform);
			LevelSelectElementView view = element.GetComponent<LevelSelectElementView>();
			view.SetLevelNumber(lastNumber+1);
		}
	}
}
