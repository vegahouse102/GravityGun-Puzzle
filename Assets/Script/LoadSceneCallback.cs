using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCallback : MonoBehaviour
{
	[SerializeField]
	private string _loadSceneName;
	public void LoadSceneCallBack()
	{
		TransitionManager.Instance.StartTransition(_loadSceneName);
	}
}
