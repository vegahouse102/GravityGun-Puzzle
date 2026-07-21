using DG.Tweening;
using UnityEngine;
public class TransitionWindowTest : MonoBehaviour
{
	[SerializeField]
	TransitionWindow window;
	void Start()
	{
		window.StartTransitionScene();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
