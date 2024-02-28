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
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(tanks[2].movementSpeed, tanks[2].rotationSpeed, tanks[2].tankType, tanks[2].color);
        TankController tankController = new TankController(tankModel, tankPrefab);
    }
}
