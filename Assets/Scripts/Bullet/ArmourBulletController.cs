using UnityEngine;

namespace Bullet
{
    public class ArmourBulletController : BulletController
    { 
        public ArmourBulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint,
            Transform parentPosition) : base(bulletModel, bulletPrefab, spawnPoint, parentPosition)

        { }
        
        protected override void DisableBullet()
        {
            GameManager.Instance.GetBulletSpawner().ReturnBulletToPool(this);
        }
    }
}