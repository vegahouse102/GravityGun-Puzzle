using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsSO", menuName = "Scriptable Objects/LevelsSO")]
[Serializable]
public class LevelsSO : ScriptableObject
{
	[SerializeField]
	private  int _maxLevel;
	public int MaxLevel { get { return _maxLevel; }  }
}
