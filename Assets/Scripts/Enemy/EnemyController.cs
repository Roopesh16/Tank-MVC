using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;

    public EnemyController(EnemyModel enemyModel,EnemyView enemyView,Transform spawnPosition)
    {
        this.enemyModel = enemyModel;
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView,spawnPosition);
        this.enemyView.SetEnemyController(this);

        this.enemyView.SetEnemyView(enemyModel.movementSpeed, enemyModel.rotationSpeed, enemyModel.stoppingDistance);
    }

    public void DecreaseHealth()
    {
        enemyModel.health -= 10;
        Debug.Log(enemyModel.health);
        
        if(enemyModel.health <= 0)
            enemyView.gameObject.SetActive(false);
    }
}
