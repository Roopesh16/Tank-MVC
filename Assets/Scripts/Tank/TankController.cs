using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody tankRb;

    public TankController(TankModel tankModel, TankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);

        tankRb = this.tankView.GetRigidbody();
        this.tankModel.SetTankController(this);
        this.tankView.SetTankController(this);
        this.tankView.SetColor(tankModel.color);
    }

    public void Move(float movement, float movementSpeed)
    {
        tankRb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        tankRb.MoveRotation(tankRb.rotation * deltaRotation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

    public Transform GetBulletSpawn()
    {
        return tankView.GetSpawnPoint();
    }

    public TankView GetTankView()
    {
        return tankView;
    }

    public void DecreaseHealth()
    {
        tankModel.health -= GameManager.instance.GetEnemyDamage();

        if (tankModel.health <= 0)
        {
            GameManager.instance.SetNewCamera(tankView.transform.position, tankView.transform.eulerAngles);
            GameObject.Destroy(tankView.gameObject);
            UIManager.instance.DisplayGameOver();
        }
    }
}
