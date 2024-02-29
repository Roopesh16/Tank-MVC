using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private float bulletSpeed;
    private BulletType bulletType;
    private Material color;

    public BulletModel(float bulletSpeed,BulletType bulletType,Material color)
    {
        this.bulletSpeed = bulletSpeed;
        this.bulletType = bulletType;
        this.color = color;
    }
}
