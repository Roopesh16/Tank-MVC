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
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private List<Bullet> bullets = new List<Bullet>();
    private bool hasTankSpawned = false;
    private BulletController bulletController;

    public void CreateBullet(BulletType bulletTypes, Transform spawnPoint)
    {
        int bulId = (int)bulletTypes;
        BulletModel bulletModel = new BulletModel(bullets[bulId].bulletSpeed, bullets[bulId].bulletType, bullets[bulId].color);
        bulletController = new BulletController(bulletModel, bulletPrefab, spawnPoint,transform);
        hasTankSpawned = true;
    }

    private void Update()
    {
        if(hasTankSpawned && Input.GetKeyDown(KeyCode.Space))
        {
            bulletController.Shoot();
        }

    }
}
