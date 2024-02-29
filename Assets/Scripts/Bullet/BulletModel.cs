using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float bulletSpeed;
    public BulletType bulletType;
    public Material color;

    public BulletModel(float bulletSpeed,BulletType bulletType,Material color)
    {
        this.bulletSpeed = bulletSpeed;
        this.bulletType = bulletType;
        this.color = color;
    }
}
