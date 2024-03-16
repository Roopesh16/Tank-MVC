using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletPrefab;
    private BulletView bulletSpawned;
    private Transform spawnPoint;
    private Transform parentPosition;


    public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint, Transform parentPosition)
    {
        this.bulletModel = bulletModel;
        this.bulletPrefab = bulletPrefab;
        this.spawnPoint = spawnPoint;
        this.parentPosition = parentPosition;
    }
    
    public void ShootBullet()
    {
        bulletSpawned = GameObject.Instantiate<BulletView>(bulletPrefab, spawnPoint);
        bulletSpawned.SetBulletController(this);
        bulletSpawned.transform.SetParent(parentPosition);
        bulletSpawned.InitBulletView(bulletModel.color, bulletModel.blastRadius,bulletModel.bulletSpeed);
    }

    public int GetDamage() => bulletModel.damage;
}
