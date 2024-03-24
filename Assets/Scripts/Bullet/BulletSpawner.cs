using UnityEngine;
using Bullet;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private BulletScriptableObject[] bulletList;
    private bool hasTankSpawned = false;
    private Transform bulletSpawnPoint;
    private BulletPool bulletPool;
    private BulletModel bulletModel;
    
    public void CreateBullet(TankTypes tankType, Transform bulletSpawnPoint)
    {
        int bId = (int)tankType;
        bulletPool = new BulletPool();    
        bulletModel = new BulletModel(bulletList[bId]);
        this.bulletSpawnPoint = bulletSpawnPoint;
        hasTankSpawned = true;
    }

    private void Update()
    {
        if (hasTankSpawned && Input.GetKeyDown(KeyCode.Space))
        {
            BulletController bulletController = bulletPool.GetBullet(bulletModel, bulletPrefab, bulletSpawnPoint, transform);
            bulletController.ShootBullet();
        }
    }
    
    public int GetDamage() => bulletModel.damage;

    public void ReturnBulletToPool(BulletController bulletController) => bulletPool.ReturnItem(bulletController);
}
