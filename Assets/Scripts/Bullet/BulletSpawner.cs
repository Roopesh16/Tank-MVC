using System;
using UnityEngine;
using Bullet;
using System.Collections.Generic;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private BulletScriptableObject[] bulletList;
    
    private bool hasTankSpawned = false;
    private Transform bulletSpawnPoint;
    private BulletPool bulletPool;
    private BulletModel bulletModel;
    private TankTypes tankType;

    private Dictionary<TankTypes, BulletController> bulletDict = new();
    
    public void CreateBullet(TankTypes tankType, Transform bulletSpawnPoint)
    {
        int bId = (int)tankType;
        this.tankType = tankType;
        bulletPool = new BulletPool();    
        bulletModel = new BulletModel(bulletList[bId]);
        this.bulletSpawnPoint = bulletSpawnPoint;
        hasTankSpawned = true;
        InitBulletDictionary();
    }

    private void Update()
    {
        if (hasTankSpawned && Input.GetKeyDown(KeyCode.Space))
        {
            BulletController bulletController = bulletDict[tankType];
            bulletController.ShootBullet();
        }
    }

    private void InitBulletDictionary()
    {
        bulletDict.Add(TankTypes.RED, bulletPool.GetBullet<ArmourBulletController>(bulletModel, 
                                                    bulletPrefab, bulletSpawnPoint, transform));
        
        bulletDict.Add(TankTypes.GREEN, bulletPool.GetBullet<ExplosiveBulletController>(bulletModel, 
                                                     bulletPrefab, bulletSpawnPoint, transform));
        
        bulletDict.Add(TankTypes.BLUE, bulletPool.GetBullet<GuidedBulletController>(bulletModel, 
                                                    bulletPrefab, bulletSpawnPoint, transform));
    }
    
    public int GetDamage() => bulletModel.damage;

    public void ReturnBulletToPool(BulletController bulletToReturn) => bulletPool.ReturnItem(bulletToReturn);
}
