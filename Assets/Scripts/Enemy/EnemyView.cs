using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask playerLayer;
    private IEnemyController enemyController;
    private NavMeshAgent navMeshAgent;
    private TankView playerTank;
    private bool canTrack = false;
    private Ray ray;
    private float maxTime = 2f;
    private bool isTimerOff = true;
    private const string bulletString = "Bullet";

    private void Awake() => navMeshAgent = GetComponent<NavMeshAgent>();

    private void OnEnable()
    {
        GameManager.Instance.eventManager.OnGameOver.AddListener(StopTank);
    }

    private void OnDisable()
    {
        GameManager.Instance.eventManager.OnGameOver.RemoveListener(StopTank);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(bulletString))
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

    private void FixedUpdate()
    {
        if (canTrack)
        {
            ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, navMeshAgent.stoppingDistance, playerLayer))
            {
                if (isTimerOff)
                {
                    enemyController.SpawnBullets(bulletSpawnPosition);
                    StartCoroutine(StartTimer());
                    isTimerOff = false;
                }
            }
        }
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(maxTime);
        isTimerOff = true;
    }

    public void SetEnemyView(TankView playerTank, float movementSpeed, float rotationSpeed, float stoppingDistance, float maxTime)
    {
        this.playerTank = playerTank;
        this.maxTime = maxTime;
        navMeshAgent.speed = movementSpeed;
        navMeshAgent.angularSpeed = rotationSpeed;
        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    public void SetEnemyController(IEnemyController enemyController) => this.enemyController = enemyController;

    public void StartTank()
    {
        navMeshAgent.SetDestination(playerTank.transform.position);
        canTrack = true;
    }

    public void DecreaseHealth()
    {
        enemyController.DecreaseHealth();
    }

    private void StopTank()
    {
        canTrack = false;
        navMeshAgent.isStopped = true;
    }
}
