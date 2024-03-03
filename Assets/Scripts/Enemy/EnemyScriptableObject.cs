using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Enemy/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyType enemyType;
    public float movementSpeed;
    public float rotationSpeed;
    public int health;
    public float firingRate;
    public float stoppingDistance;
    public EnemyView enemyPrefab;
    public float bulletSpeed;
    public int bulletDamage;
    public EnemyBulletView bulletPrefab;
}