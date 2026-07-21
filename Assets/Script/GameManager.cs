using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[SerializeField]
	private LevelsSO _levelsSO;
	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public LevelsSO GetLevelsSO()
	{
		return _levelsSO;
	}

	public void ClearLevel(string clearLevelName)
	{
		foreach(var level in _levelsSO.levelSOs)
		{
			if(level.LevelName == clearLevelName)
			{
				level.IsClear = true;
				Debug.Log($"clear {clearLevelName}");
				return;
			}
		}
	}

}
