using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material color;
    private BulletController bulletController;

    public BulletModel(float bulletSpeed,BulletType bulletType,Material color)
    {
        this.bulletSpeed = bulletSpeed;
        this.bulletType = bulletType;
        this.color = color;
    }

    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}
