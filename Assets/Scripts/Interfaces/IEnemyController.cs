using UnityEngine;

    public interface IEnemyController
    {
        public void DecreaseHealth();

        public void EnableTank();

        public void MoveBullet();

        public void SpawnBullets(Transform bulletSpawnPosition);
    }