using UnityEngine;

namespace Bullet
{
    public class ArmourBulletController : BulletController
    {
        protected override void DisableBullet()
        {
            GameManager.Instance.GetBulletSpawner().ReturnBulletToPool(this);
        }
    }
}