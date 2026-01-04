using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Scriptable Objects/LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public List<EnemyWave> enemyWaves = new();
    public GameObject bossPrefab;
}
