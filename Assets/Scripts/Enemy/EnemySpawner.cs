using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyCount = 3;
    [SerializeField] private EnemyView enemyPrefab;
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] private EnemyScriptableObject[] enemyScriptableObject;

    public void PoolEnemyTanks()
    {
        for (int i = 0; i < enemyCount;i++)
        {
            int id = Random.Range(0, 3);
            EnemyModel enemyModel = new EnemyModel(enemyScriptableObject[id].enemyType,
                                                   enemyScriptableObject[id].movementSpeed,
                                                   enemyScriptableObject[id].rotationSpeed, 
                                                   enemyScriptableObject[id].health, 
                                                   enemyScriptableObject[id].firingRate, 
                                                   enemyScriptableObject[id].stoppingDistance, 
                                                   enemyScriptableObject[id].tankColor);

            EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab,spawnPositions[i]);

        }
    }
}
