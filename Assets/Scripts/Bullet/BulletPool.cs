using Utility;
using UnityEngine;

namespace Bullet
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        private Transform spawnPoint;
        private Transform parentPosition;

        public BulletController GetBullet(BulletModel bulletModel, BulletView bulletView,
            Transform spawnPoint, Transform parentPosition)
        {
            this.bulletModel = bulletModel;
            this.bulletView = bulletView;
            this.spawnPoint = spawnPoint;
            this.parentPosition = parentPosition;

            return GetItem<BulletController>();
        }

        protected override BulletController CreateItem<U>()
        {
            return new BulletController(bulletModel, bulletView, spawnPoint, parentPosition);
        }
    }
}