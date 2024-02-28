using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel tankModel,TankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = tankView;
        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        Object.Instantiate(tankView.gameObject);
    }
}
