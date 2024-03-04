using System;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    private Transform spawnPoint;
    private Transform parentPosition;


    public BulletController(BulletModel bulletModel, BulletView bulletView, Transform spawnPoint, Transform parentPosition)
    {
        this.bulletModel = bulletModel;
        this.bulletView = bulletView;

        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
        this.spawnPoint = spawnPoint;
        this.parentPosition = parentPosition;
    }

    public void Shoot()
    {
        BulletView bullet = GameObject.Instantiate<BulletView>(bulletView, spawnPoint);
        bullet.transform.SetParent(parentPosition);
        bullet.SetBulletData(bulletModel.color, bulletModel.bulletSpeed, bulletModel.blastRadius);
    }

    public int GetDamage() => bulletModel.damage;
}
