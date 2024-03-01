using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void SetEnemyView(Material material,float movementSpeed,float rotationSpeed ,float stoppingDistance)
    {
        meshRenderer.material = material;
        navMeshAgent.speed = movementSpeed;
        navMeshAgent.angularSpeed = rotationSpeed;
        navMeshAgent.stoppingDistance = stoppingDistance;
    }
}
