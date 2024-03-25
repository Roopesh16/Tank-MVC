using UnityEngine;

namespace Bullet
{
    public class GuidedBulletController : BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletSpawned;
        private Transform parentPosition;
        private Transform spawnPoint;
    
        public GuidedBulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint, Transform parentPosition)
                :base(bulletModel,bulletPrefab,spawnPoint,parentPosition)
        {
            this.bulletModel = bulletModel;
            this.bulletModel.SetBulletController(this);
            this.spawnPoint = spawnPoint;
        
            bulletSpawned = GameObject.Instantiate<BulletView>(bulletPrefab,spawnPoint);
            bulletSpawned.InitBulletView(bulletModel.color, bulletModel.blastRadius,bulletModel.bulletSpeed);
            bulletSpawned.SetBulletController(this);
            bulletSpawned.transform.SetParent(parentPosition);
        }
    
        public override void ShootBullet()
        {
            bulletSpawned.gameObject.SetActive(true);
            bulletSpawned.gameObject.transform.position = spawnPoint.position;
            // bulletSpawned.gameObject.transform.forward = spawnPoint.forward;
            bulletSpawned.ShootBullet();
        }

        public override void OnBulletHit()
        {
            bulletSpawned.BlastImpact();
            bulletSpawned.GetBlastParticle().Play();
            bulletSpawned.DisableMesh();
            bulletSpawned.StopBullet(spawnPoint);
            // Invoke("DisableBullet",bulletSpawned.GetBlastParticle().main.duration);
            DisableBullet();
        }

        protected override void DisableBullet()
        {
            bulletSpawned.gameObject.SetActive(false);
            GameManager.Instance.GetBulletSpawner().ReturnBulletToPool(this);
        }
    }
}