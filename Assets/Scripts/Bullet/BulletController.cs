using UnityEngine;

namespace Bullet
{
    public class BulletController
    {
        protected BulletModel bulletModel;
        protected BulletView bulletSpawned;
        protected Transform parentPosition;
        protected Transform spawnPoint;
        
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint,
            Transform parentPosition)
        {
            this.bulletModel = bulletModel;
            this.spawnPoint = spawnPoint;
            this.parentPosition = parentPosition;
            
            bulletSpawned = GameObject.Instantiate<BulletView>(bulletPrefab,spawnPoint);
            bulletSpawned.InitBulletView(bulletModel.color, bulletModel.blastRadius,bulletModel.bulletSpeed);
            bulletSpawned.SetBulletController(this);
            bulletSpawned.transform.SetParent(parentPosition);
        }

        public virtual void ShootBullet()
        {
            bulletSpawned.gameObject.SetActive(true);
            bulletSpawned.gameObject.transform.position = spawnPoint.position;
            // bulletSpawned.gameObject.transform.forward = spawnPoint.forward;
            bulletSpawned.ShootBullet();
        }

        public virtual void OnBulletHit()
        {
            bulletSpawned.BlastImpact();
            bulletSpawned.GetBlastParticle().Play();
            bulletSpawned.DisableMesh();
            bulletSpawned.StopBullet(spawnPoint);
            // Invoke("DisableBullet",bulletSpawned.GetBlastParticle().main.duration);
            DisableBullet();
        }

        protected virtual void DisableBullet()
        {
            bulletSpawned.gameObject.SetActive(false);
        }
    }
}