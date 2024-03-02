using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyCount = 3;
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] private EnemyScriptableObject[] enemyList;

    public void PoolEnemyTanks()
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

            EnemyController enemyController = new EnemyController(enemyModel, enemyList[id].enemyPrefab, spawnPositions[i]);

        }
    }
}
