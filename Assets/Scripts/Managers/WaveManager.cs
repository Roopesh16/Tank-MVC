using System.Collections.Generic;

public class WaveManager
{
    private EnemySpawner enemySpawner;
    private List<WaveScriptableObject> wavesList = new();

    private int waveCount = 0;

    public WaveManager(EnemySpawner enemySpawner, List<WaveScriptableObject> wavesList)
    {
        this.enemySpawner = enemySpawner;
        this.wavesList = wavesList;
        OnEnable();
    }

    public void OnEnable()
    {
        GameManager.Instance.eventManager.OnNewWave.AddListener(StartNewWave);
    }

    public void OnDisable()
    {
        GameManager.Instance.eventManager.OnNewWave.RemoveListener(StartNewWave);
    }

    public void StartNewWave()
    {
        if (waveCount == wavesList.Count)
        {
            GameManager.Instance.eventManager.OnGameOver.InvokeEvent();
            return;
        }

        enemySpawner.PoolEnemyTanks(wavesList[waveCount].enemiesToSpawn, GameManager.Instance.GetBulletDamage());
        waveCount++;
    }

    public void SpawnNextTank() => enemySpawner.SpawnNextTank();

    public void SetTankController(TankController tankController)
    {
        enemySpawner.SetupPlayerTank(tankController);
    }

    public int GetWaveNumber() => wavesList[waveCount].waveNumber;
}
