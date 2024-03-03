using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    private NavMeshAgent navMeshAgent;
    private TankView playerTank;

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

    public void SetEnemyView(TankView playerTank, float movementSpeed, float rotationSpeed, float stoppingDistance)
    {
        this.playerTank = playerTank;
        transform.LookAt(this.playerTank.GetPosition(), Vector3.up);
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
        navMeshAgent.SetDestination(playerTank.GetPosition().position);
    }
}
