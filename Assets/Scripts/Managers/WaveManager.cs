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
    }

    public void StartNewWave()
    {
        if (waveCount == wavesList.Count)
        {
            UIManager.instance.DisplayGameOver();
            return;
        }

        enemySpawner.PoolEnemyTanks(wavesList[waveCount].enemyCount, GameManager.Instance.GetBulletDamage());
        waveCount++;
    }

    public void SpawnNextTank() => enemySpawner.SpawnNextTank();

    public void SetTankController(TankController tankController)
    {
        enemySpawner.SetupPlayerTank(tankController);
    }

    public int GetWaveNumber() => wavesList[waveCount].waveNumber;
}
