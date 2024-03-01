using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material color;
    public float damageRadius;
    public float firingRate;
    
    private BulletController bulletController;

    public BulletModel(float bulletSpeed,BulletType bulletType,Material color,float damageRadius,float firingRate)
    {
        this.bulletSpeed = bulletSpeed;
        this.bulletType = bulletType;
        this.color = color;
        this.damageRadius = damageRadius;
        this.firingRate = firingRate;
    }

    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}
