using UnityEngine;

public class PlayerPrefClear : MonoBehaviour
{
	[SerializeField]
	private bool _startClear;
	void Awake()
	{
#if UNITY_EDITOR
		if( _startClear )
			PlayerPrefs.DeleteAll();
#endif
	}

	// Update is called once per frame
	void Update()
	{

	}
}
