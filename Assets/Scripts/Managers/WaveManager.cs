using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

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

    public async void SetupNewWave()
    {
        if (waveCount == wavesList.Count)
        {
            UIManager.instance.DisplayGameOver();
            return;
        }
        UIManager.instance.SetWaveText(wavesList[waveCount].waveNumber);
        await Task.Delay(GameManager.instance.UITimer);
        enemySpawner.PoolEnemyTanks(wavesList[waveCount].enemyCount, GameManager.instance.GetBulletDamage());
        waveCount++;
    }

    public void SpawnNextTank()
    {
        enemySpawner.SpawnNextTank();
    }
}
