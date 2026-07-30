using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public event Action OnPlayerDeath;
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

	public void ClearLevel(int clearLevel)
	{
		int lastClearLevel = GetLastClearLevel();
		if(lastClearLevel < clearLevel)
			PlayerPrefs.SetInt("LastClearLevel",clearLevel);
	}
	public int GetLastClearLevel()
	{
		return PlayerPrefs.GetInt("LastClearLevel",0);
	}
	public void HandlePlayerDeath()
	{
		OnPlayerDeath?.Invoke();
	}

}
