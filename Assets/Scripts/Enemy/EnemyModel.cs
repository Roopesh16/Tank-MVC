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
    public int bulletDamage;

    private IEnemyController enemyController;

    public EnemyModel(EnemyScriptableObject enemySO)
    {
        enemyType = enemySO.enemyType;
        movementSpeed = enemySO.movementSpeed;
        rotationSpeed = enemySO.rotationSpeed;
        health = enemySO.health;
        firingRate = enemySO.firingRate;
        stoppingDistance = enemySO.stoppingDistance ;
        bulletSpeed = enemySO.bulletSpeed;
        enemyBullet = enemySO.bulletPrefab;
        bulletDamage = enemySO.bulletDamage;
    }

    public void SetEnemyController(IEnemyController enemyController) => this.enemyController = enemyController;
}
