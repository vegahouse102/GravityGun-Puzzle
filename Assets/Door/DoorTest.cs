using UnityEngine;
using DG.Tweening;
public class DoorTest : MonoBehaviour
{
	[SerializeField]
	Door _door;
	void Start()
	{
		Sequence sequence = DOTween.Sequence();
		sequence.AppendCallback(()=>_door.SetActive(true));
		sequence.AppendInterval(2f);
		sequence.AppendCallback( ()=>_door.SetActive(false));
		sequence.AppendInterval(2f);
		sequence.SetLoops(-1);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
