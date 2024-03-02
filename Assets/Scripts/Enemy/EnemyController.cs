using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private int damage;

    public EnemyController(EnemyModel enemyModel,EnemyView enemyView,Transform spawnPosition,int damage)
    {
        this.enemyModel = enemyModel;
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView,spawnPosition);
        this.enemyView.SetEnemyController(this);

        this.enemyView.SetEnemyView(enemyModel.movementSpeed, enemyModel.rotationSpeed, enemyModel.stoppingDistance);
        this.damage = damage;
    }

    public void DecreaseHealth()
    {
        enemyModel.health -= damage;
        
        if(enemyModel.health <= 0)
            enemyView.gameObject.SetActive(false);
    }
}
