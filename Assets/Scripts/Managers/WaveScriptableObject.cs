using UnityEngine;

[CreateAssetMenu(fileName = "WaveScriptableObject", menuName = "Waves/WaveScriptableObject")]
public class WaveScriptableObject : ScriptableObject
{
    public int waveNumber;
    public int enemyCount;
}