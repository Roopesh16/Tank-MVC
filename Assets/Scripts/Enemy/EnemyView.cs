using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    private NavMeshAgent navMeshAgent;

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

    public void SetEnemyView(float movementSpeed, float rotationSpeed, float stoppingDistance)
    {
        transform.LookAt(Vector3.zero, Vector3.up);
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
        navMeshAgent.SetDestination(Vector3.zero);
    }
}
