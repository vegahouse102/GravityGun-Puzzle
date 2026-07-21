using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "Scriptable Objects/LevelSO")]
[Serializable]
public class LevelSO : ScriptableObject
{
	
	public string LevelName;

	public bool IsClear;
}
