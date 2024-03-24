using UnityEngine;

public partial class ArtilleryEnemyController:IEnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private EnemyBulletView enemyBulletView;
    private int damage;
    private TankView tankView;
    private Ray ray;

    public ArtilleryEnemyController(TankView tankView, EnemyModel enemyModel, EnemyView enemyView, Transform spawnPosition, int damage)
    {
        this.tankView = tankView;
        this.enemyModel = enemyModel;
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView, spawnPosition);
        this.enemyView.SetEnemyController(this);
        this.enemyView.SetEnemyView(enemyModel.movementSpeed, enemyModel.rotationSpeed, enemyModel.stoppingDistance, enemyModel.firingRate);
        this.enemyView.gameObject.SetActive(false);
        this.damage = damage;
        GameManager.Instance.SetEnemyDamage(enemyModel.bulletDamage);
    }

    public void DecreaseHealth()
    {
        enemyModel.health -= damage;

        if (enemyModel.health <= 0)
        {
            enemyView.gameObject.SetActive(false);
            GameManager.Instance.waveManager.SpawnNextTank();
        }
    }

    public void EnableTank()
    {
        enemyView.gameObject.SetActive(true);
        enemyView.StartTank(tankView.transform.position);
    }

    public void MoveBullet()
    {
        enemyBulletView.transform.Translate(enemyBulletView.transform.forward * (enemyModel.bulletSpeed * Time.deltaTime),
                                    Space.World);
    }

    public void SpawnBullets(Transform bulletSpawnPosition)
    {
        enemyBulletView = GameObject.Instantiate<EnemyBulletView>(enemyModel.enemyBullet, bulletSpawnPosition);
        enemyBulletView.SetEnemyController(this);
        enemyBulletView.InitEnemyBulletView(enemyView.transform.forward);
    }

    public void MoveTank()
    {
        Vector3 direction = tankView.transform.position - enemyView.transform.position;
        enemyView.transform.forward = direction;
        
        if (Vector3.Magnitude(direction) > enemyView.GetNaveMesh().stoppingDistance)
        {
            enemyView.GetNaveMesh().isStopped = false;
            enemyView.GetNaveMesh().SetDestination(tankView.transform.position);
        }
        else
        {
            enemyView.GetNaveMesh().isStopped = true;
        }
    }

    public void TrackPlayerTank()
    {
        ray = new Ray(enemyView.transform.position, enemyView.transform.forward);
        if (Physics.Raycast(ray, enemyView.GetNaveMesh().stoppingDistance, enemyView.GetPlayerLayer()))
        {
            if (enemyView.GetTimerOff())
            {
                SpawnBullets(enemyView.GetBulletSpawnPosition());
                enemyView.BeginTimer();
            }
        }
    }
}
