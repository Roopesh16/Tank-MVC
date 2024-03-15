using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private EnemyBulletView enemyBulletView;
    private int damage;

    public EnemyController(TankView tankView, EnemyModel enemyModel, EnemyView enemyView, Transform spawnPosition, int damage)
    {
        this.enemyModel = enemyModel;
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView, spawnPosition);
        this.enemyView.SetEnemyController(this);
        this.enemyView.SetEnemyView(tankView, enemyModel.movementSpeed, enemyModel.rotationSpeed, enemyModel.stoppingDistance, enemyModel.firingRate);
        this.enemyView.gameObject.SetActive(false);
        this.damage = damage;
        GameManager.Instance.SetEnemyDamage(enemyModel.bulletDamage);
    }

    public void DecreaseHealth()
    {
        enemyModel.health -= damage;

        if (enemyModel.health <= 0)
        {
            enemyView.gameObject.SetActive(false);
            GameManager.Instance.waveManager.SpawnNextTank();
        }
    }

    public void EnableTank()
    {
        enemyView.gameObject.SetActive(true);
        enemyView.StartTank();
    }

    public void MoveBullet()
    {
        enemyBulletView.transform.Translate(enemyBulletView.transform.forward*enemyModel.bulletSpeed*Time.deltaTime,
                                    Space.World);
    }

    public void SpawnBullets(Transform bulletSpawnPosition)
    {
        enemyBulletView = GameObject.Instantiate<EnemyBulletView>(enemyModel.enemyBullet, bulletSpawnPosition);
        enemyBulletView.SetEnemyController(this);
        enemyBulletView.InitEnemyBulletView(enemyView.transform.forward);
    }
}
