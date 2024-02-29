using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawner tankSpawner;
    [SerializeField] private BulletSpawner bulletSpawner;

    public void GreenTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.GREEN);
        bulletSpawner.CreateBullet(BulletType.GREEN);
        gameObject.SetActive(false);
    }

    public void RedTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.RED);
        bulletSpawner.CreateBullet(BulletType.RED);
        gameObject.SetActive(false);
    }

    public void BlueTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.BLUE);
        bulletSpawner.CreateBullet(BulletType.BLUE);
        gameObject.SetActive(false);
    }
}
