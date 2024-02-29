using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tank
{
    public float movementSpeed;
    public float rotationSpeed;
    public TankTypes tankType;
    public Material color;
}

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankPrefab;
    [SerializeField] private List<Tank> tanks = new List<Tank>();

    void Start()
    {
    }

    public void CreateTank(TankTypes tankTypes)
    {
        int tankId = (int)tankTypes;
        TankModel tankModel = new TankModel(tanks[tankId].movementSpeed, tanks[tankId].rotationSpeed, tanks[tankId].tankType, tanks[tankId].color);
        TankController tankController = new TankController(tankModel, tankPrefab);
    }
}
