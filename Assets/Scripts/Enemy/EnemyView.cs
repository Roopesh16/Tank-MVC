using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetEnemyView(float movementSpeed,float rotationSpeed ,float stoppingDistance)
    {
        transform.LookAt(Vector3.zero, Vector3.up);
        navMeshAgent.speed = movementSpeed;
        navMeshAgent.angularSpeed = rotationSpeed;
        navMeshAgent.stoppingDistance = stoppingDistance;

        // var direction = transform.position - Vector3.zero;
        // transform.forward = direction;

        navMeshAgent.SetDestination(Vector3.zero);

    }
}
