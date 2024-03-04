using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class WaveManager : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private List<WaveScriptableObject> wavesList = new();

    public static WaveManager instance = null;

    private int waveCount = 0;

    public WaveManager(EnemySpawner enemySpawner,List<WaveScriptableObject> wavesList)
    {
        this.enemySpawner = enemySpawner;
        this.wavesList = wavesList;
    }

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

    public void StartNewWave()
    {
        if (waveCount == wavesList.Count)
        {
            UIManager.instance.DisplayGameOver();
            return;
        }

        enemySpawner.PoolEnemyTanks(wavesList[waveCount].enemyCount, GameManager.instance.GetBulletDamage());
        waveCount++;
    }

    public void SpawnNextTank() => enemySpawner.SpawnNextTank();

    public void SetTankController(TankController tankController)
    {
        enemySpawner.SetupPlayerTank(tankController);
    }

    public int GetWaveNumber() => wavesList[waveCount].waveNumber;
}
