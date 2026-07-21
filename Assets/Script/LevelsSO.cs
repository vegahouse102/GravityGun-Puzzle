using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsSO", menuName = "Scriptable Objects/LevelsSO")]
[Serializable]
public class LevelsSO : ScriptableObject
{

	public List<LevelSO> levelSOs = new();

}
