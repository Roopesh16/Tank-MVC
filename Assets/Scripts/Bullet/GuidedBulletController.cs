using UnityEngine;

namespace Bullet
{
    public class GuidedBulletController : BulletController
    {
        protected override void DisableBullet()
        {
            GameManager.Instance.GetBulletSpawner().ReturnBulletToPool(this);
        }
    }
}