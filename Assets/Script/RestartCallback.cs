using UnityEngine;

public class RestartCallback : MonoBehaviour
{
	public void Restart()
	{
		TransitionManager.Instance.RestartScene();
	}
}
