using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask playerLayer;
    private EnemyController enemyController;
    private NavMeshAgent navMeshAgent;
    private TankView playerTank;
    private bool canTrack = false;
    private Ray ray;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyController.DecreaseHealth();
        }
    }

    private void Update()
    {
        if (canTrack)
        {
            Vector3 direction = playerTank.transform.position - transform.position;
            transform.forward = direction;
            if (Vector3.Magnitude(direction) > navMeshAgent.stoppingDistance)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(playerTank.transform.position);
            }
            else
            {
                navMeshAgent.isStopped = true;
            }
        }
    }

    private async void FixedUpdate()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, maxDistance, playerLayer))
        {
            enemyController.SpawnBullets(bulletSpawnPosition);
        }
    }

    public void SetEnemyView(TankView playerTank, float movementSpeed, float rotationSpeed, float stoppingDistance)
    {
        this.playerTank = playerTank;
        navMeshAgent.speed = movementSpeed;
        navMeshAgent.angularSpeed = rotationSpeed;
        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void StartTank()
    {
        navMeshAgent.SetDestination(playerTank.transform.position);
        canTrack = true;
    }
}
