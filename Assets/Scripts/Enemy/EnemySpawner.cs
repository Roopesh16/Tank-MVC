using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] private EnemyScriptableObject[] enemyList;

    private List<EnemyController> enemyControllers = new();

    private int currentEnemy = 0;

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
                                                       enemyList[id].stoppingDistance);

            EnemyController enemyController = new EnemyController(enemyModel, enemyList[id].enemyPrefab, spawnPositions[i], damage);
            enemyControllers.Add(enemyController);
        }

        SpawnNextTank();
    }

    private void SpawnNextTank()
    {
        enemyControllers[currentEnemy].EnableTank();
    }

}
