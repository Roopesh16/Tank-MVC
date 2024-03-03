using UnityEngine;

public class EnemyModel
{
   public EnemyType enemyType;
    public float movementSpeed;
    public float rotationSpeed;
    public int health;
    public float firingRate;
    public float stoppingDistance;
    public Material tankColor;
    public float bulletSpeed;
    public EnemyBulletView enemyBullet;

    private EnemyController enemyController;

    public EnemyModel(EnemyType enemyType,float movementSpeed,float rotationSpeed,int health,float firingRate,
                      float stoppingDistance,float bulletSpeed,EnemyBulletView enemyBullet)
    {
        this.enemyType = enemyType;
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.health = health;
        this.firingRate = firingRate;
        this.stoppingDistance = stoppingDistance;
        this.bulletSpeed = bulletSpeed;
        this.enemyBullet = enemyBullet;
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
}
