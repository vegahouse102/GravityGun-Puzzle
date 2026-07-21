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
		int curNumber = 1;
		foreach (var level in levelsSO.levelSOs)
		{
			
			GameObject element = Instantiate(_levelSelectElement,transform);
			LevelSelectElementView view = element.GetComponent<LevelSelectElementView>();
			view.SetLevelNumber(curNumber);
			view.SetLevelSO(level);

			curNumber++;
			if (!level.IsClear)
				return;
		}
	}
}
