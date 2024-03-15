using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] private EnemyScriptableObject[] enemyList;

    private List<IEnemyController> enemyControllers = new();

    private int currentEnemy = 0;
    private TankView playerTank;

    public void PoolEnemyTanks(int enemyCount, int damage)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int id = Random.Range(0, 3);
            EnemyModel enemyModel = new EnemyModel(enemyList[id].enemyType,
                                                       enemyList[id].movementSpeed,
                                                       enemyList[id].rotationSpeed,
                                                       enemyList[id].health,
                                                       enemyList[id].firingRate,
                                                       enemyList[id].stoppingDistance,
                                                       enemyList[id].bulletSpeed,
                                                       enemyList[id].bulletPrefab,
                                                       enemyList[id].bulletDamage);

            if (enemyList[i].enemyType == EnemyType.Heavy_Assault)
            {
                HeavyEnemyController heavyEnemyController = new HeavyEnemyController(playerTank, enemyModel, enemyList[id].enemyPrefab,
                                                                    spawnPositions[i], damage);
                enemyControllers.Add(heavyEnemyController);
            }
            else if (enemyList[i].enemyType == EnemyType.Scout)
            {
                ScoutEnemyController scoutEnemyController = new ScoutEnemyController(playerTank, enemyModel, enemyList[id].enemyPrefab,
                    spawnPositions[i], damage);
                enemyControllers.Add(scoutEnemyController);
            }
            else
            {
                ArtilleryEnemyController artilleryEnemyController = new ArtilleryEnemyController(playerTank, enemyModel,
                    enemyList[id].enemyPrefab,
                    spawnPositions[i], damage);
                enemyControllers.Add(artilleryEnemyController);
            }
        }

        SpawnNextTank();
    }

    public void SpawnNextTank()
    {
        if (currentEnemy == enemyControllers.Count)
        {
            currentEnemy = 0;
            enemyControllers.Clear();
            GameManager.Instance.SetupNewWave();
            return;
        }
        enemyControllers[currentEnemy].EnableTank();
        currentEnemy++;
    }

    public void SetupPlayerTank(TankController tankController) => playerTank = tankController.GetTankView();

}
