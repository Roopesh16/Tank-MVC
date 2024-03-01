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

    private EnemyController enemyController;

    public EnemyModel(EnemyType enemyType,float movementSpeed,float rotationSpeed,int health,float firingRate,
                      float stoppingDistance,Material tankColor)
    {
        this.enemyType = enemyType;
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.health = health;
        this.firingRate = firingRate;
        this.stoppingDistance = stoppingDistance;
        this.tankColor = tankColor;
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
}
