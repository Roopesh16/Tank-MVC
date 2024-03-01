using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material color;
    public float blastRadius;
    public float firingRate;

    private BulletController bulletController;

    public BulletModel(float bulletSpeed,BulletType bulletType,Material color,
                       float blastRadius,float firingRate)
    {
        this.bulletSpeed = bulletSpeed;
        this.bulletType = bulletType;
        this.color = color;
        this.blastRadius = blastRadius;
        this.firingRate = firingRate;
    }

    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}
