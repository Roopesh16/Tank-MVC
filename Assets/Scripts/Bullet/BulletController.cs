using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletSpawned;
    private Transform parentPosition;
    private Transform spawnPoint;
    
    public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint, Transform parentPosition)
    {
        this.bulletModel = bulletModel;
        this.spawnPoint = spawnPoint;
        
        bulletSpawned = GameObject.Instantiate<BulletView>(bulletPrefab,spawnPoint);
        bulletSpawned.InitBulletView(bulletModel.color, bulletModel.blastRadius,bulletModel.bulletSpeed);
        bulletSpawned.SetBulletController(this);
        bulletSpawned.transform.SetParent(parentPosition);
    }
    
    public void ShootBullet()
    {
        bulletSpawned.gameObject.SetActive(true);
        bulletSpawned.gameObject.transform.position = spawnPoint.position;
        // bulletSpawned.gameObject.transform.forward = spawnPoint.forward;
        bulletSpawned.ShootBullet();
    }

    public void OnBulletHit()
    {
        bulletSpawned.BlastImpact();
        bulletSpawned.GetBlastParticle().Play();
        bulletSpawned.DisableMesh();
        bulletSpawned.StopBullet(spawnPoint);
        // Invoke("DisableBullet",bulletSpawned.GetBlastParticle().main.duration);
        DisableBullet();
    }

    private void DisableBullet()
    {
        bulletSpawned.gameObject.SetActive(false);
        GameManager.Instance.GetBulletSpawner().ReturnBulletToPool(this);
    }
}
