using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private List<WaveScriptableObject> wavesList = new();
    public static WaveManager instance = null;

    private int waveCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetupNewWave()
    {
        if (waveCount == wavesList.Count)
        {
            Debug.Log("Game Over");
            return;
        }
        enemySpawner.PoolEnemyTanks(wavesList[waveCount].enemyCount, GameManager.instance.GetBulletDamage());
        waveCount++;
    }

    public void SpawnNextTank()
    {
        enemySpawner.SpawnNextTank();
    }
}
