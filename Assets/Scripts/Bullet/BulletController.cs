using UnityEngine;

namespace Bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint, Transform parentPosition){}
        public virtual void ShootBullet(){}
        public virtual void OnBulletHit(){}
        protected virtual void DisableBullet(){}
    }
}