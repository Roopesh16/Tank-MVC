using UnityEngine;

namespace Bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawnPoint, Transform parentPosition){}
        public void ShootBullet(){}
        public  void OnBulletHit(){}
        protected  void DisableBullet(){}
    }
}