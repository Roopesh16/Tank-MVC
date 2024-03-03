using System;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;
    [SerializeField] private List<TankScriptableObject> tankList = new List<TankScriptableObject>();
    private Transform bulletSpawn;
    private TankController tankController;

    public void CreateTank(TankTypes tankTypes)
    {
        int tankId = (int)tankTypes;
        TankModel tankModel = new TankModel(tankList[tankId].movementSpeed, tankList[tankId].rotationSpeed, tankList[tankId].tankType, tankList[tankId].tankColor, tankList[tankId].tankHealth);
        tankController = new TankController(tankModel, tankPrefab);
        bulletSpawn = tankController.GetBulletSpawn();
    }

    public Transform GetBulletSpawn()
    {
        return bulletSpawn;
    }

    public TankController GetTankController()
    {
        return tankController;
    }
}
