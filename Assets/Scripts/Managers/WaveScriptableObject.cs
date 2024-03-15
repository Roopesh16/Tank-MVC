using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WaveScriptableObject", menuName = "Waves/WaveScriptableObject")]
public class WaveScriptableObject : ScriptableObject
{
    public int waveNumber;
    public int enemyCount;
    public List<EnemyType> enemiesToSpawn = new ();
}