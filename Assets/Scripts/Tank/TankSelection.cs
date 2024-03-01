using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawner tankSpawner;
    [SerializeField] private BulletSpawner bulletSpawner;

    public void GreenTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.GREEN);
        bulletSpawner.CreateBullet(BulletType.High_Explosive,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
    }

    public void RedTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.RED);
        bulletSpawner.CreateBullet(BulletType.Armour_Piercing,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
    }

    public void BlueTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.BLUE);
        bulletSpawner.CreateBullet(BulletType.Guided_Missile,tankSpawner.GetBulletSpawn());
        gameObject.SetActive(false);
    }
}
