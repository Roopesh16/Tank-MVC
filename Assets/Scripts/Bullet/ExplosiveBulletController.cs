using UnityEngine;

namespace Bullet
{
    public class ExplosiveBulletController : BulletController
    {
        public ExplosiveBulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint,
            Transform parentPosition) : base(bulletModel, bulletPrefab, spawnPoint, parentPosition)

        { }
        
        protected override void DisableBullet()
        {
            GameManager.Instance.GetBulletSpawner().ReturnBulletToPool(this);
        }
    }
}