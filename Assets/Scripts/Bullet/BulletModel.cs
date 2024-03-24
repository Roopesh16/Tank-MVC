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
    public int damage;

    private BulletController bulletController;

    public BulletModel(BulletScriptableObject bulletSO)
    {
        bulletSpeed = bulletSO.bulletSpeed;
        bulletType = bulletSO.bulletType;
        color = bulletSO.bulletColor;
        blastRadius = bulletSO.blastRadius;
        firingRate = bulletSO.firingRate;
        damage = bulletSO.damage;
    }

    public void SetBulletController(BulletController bulletController) => this.bulletController = bulletController;
}
