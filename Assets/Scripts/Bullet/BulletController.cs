using System;
using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;

    public BulletController(BulletModel bulletModel, BulletView bulletView)
    {
        this.bulletModel = bulletModel;
        this.bulletView = GameObject.Instantiate<BulletView>(bulletView);
        
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
        this.bulletView.SetBullet(bulletModel.color);
        
    }
}
