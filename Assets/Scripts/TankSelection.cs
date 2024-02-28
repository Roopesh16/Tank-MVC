using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawner tankSpawner;

    public void GreenTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.GREEN);
        gameObject.SetActive(false);
    }

    public void RedTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.RED);
        gameObject.SetActive(false);
    }

    public void BlueTankSelection()
    {
        tankSpawner.CreateTank(TankTypes.BLUE);
        gameObject.SetActive(false);
    }
}
