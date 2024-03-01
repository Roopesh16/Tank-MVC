using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawner tankSpawner;
    [SerializeField] private BulletSpawner bulletSpawner;

    public void GreenTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.GREEN);
        bulletSpawner.CreateBullet(TankTypes.GREEN,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
    }

    public void RedTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.RED);
        bulletSpawner.CreateBullet(TankTypes.RED,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
    }

    public void BlueTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.BLUE);
        bulletSpawner.CreateBullet(TankTypes.BLUE,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
    }
}
