using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bullet
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material color;
}

public class BulletSpawner : MonoBehaviour
{
    public BulletView bulletPrefab;
    public List<Bullet> bullets = new List<Bullet>();
    
    public void CreateBullet(TankTypes tankTypes)
    {
        int bulId = (int)tankTypes;
        BulletModel bulletModel = new BulletModel(bullets[bulId].bulletSpeed, bullets[bulId].bulletType, bullets[bulId].color);
        BulletController bulletController = new BulletController(bulletModel, bulletPrefab);
    }
}
