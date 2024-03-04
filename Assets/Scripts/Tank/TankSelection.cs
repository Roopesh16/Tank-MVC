using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawner tankSpawner;
    [SerializeField] private BulletSpawner bulletSpawner;

    public void GreenTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.GREEN);
        bulletSpawner.CreateBullet(TankTypes.GREEN, tankSpawner.GetBulletSpawn());
        GameManager.Instance.SetupNewGame(tankSpawner.GetTankController(), bulletSpawner.GetDamage());
        gameObject.SetActive(false);
    }

    public void RedTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.RED);
        bulletSpawner.CreateBullet(TankTypes.RED, tankSpawner.GetBulletSpawn());
        GameManager.Instance.SetupNewGame(tankSpawner.GetTankController(), bulletSpawner.GetDamage());
        gameObject.SetActive(false);
    }

    public void BlueTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.BLUE);
        bulletSpawner.CreateBullet(TankTypes.BLUE, tankSpawner.GetBulletSpawn());
        GameManager.Instance.SetupNewGame(tankSpawner.GetTankController(), bulletSpawner.GetDamage());
        gameObject.SetActive(false);
    }
}
