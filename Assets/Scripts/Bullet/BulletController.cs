using System;
using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    private Transform spawnPoint;

    public BulletController(BulletModel bulletModel, BulletView bulletView, Transform spawnPoint)
    {
        this.bulletModel = bulletModel;
        this.bulletView = bulletView;

        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
        this.spawnPoint = spawnPoint;

    }

    public void Shoot()
    {
        BulletView bullet = GameObject.Instantiate<BulletView>(bulletView, spawnPoint);
        bullet.SetBulletData(bulletModel.color,bulletModel.bulletSpeed);
    }
}
