using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public float movement;
    public float rotation;
    public TankTypes tankTypes;
    public Material color;

    public TankModel(float movement,float rotation,TankTypes tankTypes,Material color)
    {
        this.movement = movement;
        this.rotation = rotation;
        this.tankTypes = tankTypes;
        this.color = color;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
