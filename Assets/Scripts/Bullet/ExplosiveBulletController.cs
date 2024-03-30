using UnityEngine;

namespace Bullet
{
    public class ExplosiveBulletController : BulletController
    {
        protected override void DisableBullet()
        {
            GameManager.Instance.GetBulletSpawner().ReturnBulletToPool(this);
        }
    }
}