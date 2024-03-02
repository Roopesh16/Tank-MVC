using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawner tankSpawner;
    [SerializeField] private BulletSpawner bulletSpawner;
    [SerializeField] private EnemySpawner enemySpawner;

    public void GreenTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.GREEN);
        bulletSpawner.CreateBullet(TankTypes.GREEN,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
        enemySpawner.PoolEnemyTanks(bulletSpawner.GetDamage());
    }

    public void RedTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.RED);
        bulletSpawner.CreateBullet(TankTypes.RED,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
        enemySpawner.PoolEnemyTanks(bulletSpawner.GetDamage());
    }

    public void BlueTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.BLUE);
        bulletSpawner.CreateBullet(TankTypes.BLUE,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
        enemySpawner.PoolEnemyTanks(bulletSpawner.GetDamage());
    }
}
