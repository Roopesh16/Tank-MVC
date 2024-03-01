using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;

    public EnemyController(EnemyModel enemyModel,EnemyView enemyView,Transform spawnPosition)
    {
        this.enemyModel = enemyModel;
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView,spawnPosition);

        this.enemyView.SetEnemyView(enemyModel.movementSpeed, enemyModel.rotationSpeed, enemyModel.stoppingDistance);
    }
}
