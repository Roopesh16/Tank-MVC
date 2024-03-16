using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private BulletScriptableObject[] bulletList;
    private bool hasTankSpawned = false;
    private BulletController bulletController;

    public void CreateBullet(TankTypes tankType, Transform bulletSpawnPoint)
    {
        int bId = (int)tankType;
        BulletModel bulletModel = new BulletModel(bulletList[bId].bulletSpeed,
                                                 bulletList[bId].bulletType,
                                                 bulletList[bId].bulletColor,
                                                 bulletList[bId].blastRadius,
                                                 bulletList[bId].firingRate,
                                                 bulletList[bId].damage);
        bulletController = new BulletController(bulletModel, bulletPrefab, bulletSpawnPoint, transform);
        hasTankSpawned = true;
    }

    private void Update()
    {
        if (hasTankSpawned && Input.GetKeyDown(KeyCode.Space))
        {
            bulletController.ShootBullet();
        }
    }
    
    public int GetDamage() => bulletController.GetDamage();
}
