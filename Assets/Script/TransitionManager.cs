
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
	public event Action OnStartTransition;
	public event Action OnEndTransition;
	public event Action<float> OnTransitionProgress;

	public static TransitionManager Instance { get; private set; }


	private bool _isTransitioning;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}



	public void StartTransition(string nextSceneName)
	{
		if (_isTransitioning)
			return;

		StartCoroutine(TranstionScene(nextSceneName));

	}
	IEnumerator TranstionScene(string nextSceneName)
	{
		_isTransitioning = true;
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
		Time.timeScale = 0f;
		if (asyncOperation == null)
		{
			_isTransitioning = false;
			yield break ;

		}

		OnStartTransition?.Invoke();


		asyncOperation.allowSceneActivation = false;


		while (asyncOperation.progress < 0.9f)
		{
			OnTransitionProgress?.Invoke(asyncOperation.progress / 0.9f);
			yield return null;
		}
		OnTransitionProgress?.Invoke(1f);

		asyncOperation.allowSceneActivation = true;

		while (!asyncOperation.isDone)
		{
			yield return null;
		}
		OnEndTransition?.Invoke();
		Time.timeScale = 1f;
		_isTransitioning = false;
	}
}
