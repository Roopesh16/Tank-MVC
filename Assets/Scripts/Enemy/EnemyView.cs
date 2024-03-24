using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask playerLayer;
    private IEnemyController enemyController;
    private bool canTrack = false;
    private float maxTime = 2f;
    private bool isTimerOff = true;
    private const string bulletString = "Bullet";

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
            enemyController.MoveTank();
        }
    }

    private void FixedUpdate()
    {
        if (canTrack)
        {
            enemyController.TrackPlayerTank();
        }
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(maxTime);
        isTimerOff = true;
    }

    public void SetEnemyView(float movementSpeed, float rotationSpeed, float stoppingDistance, float maxTime)
    {
        this.maxTime = maxTime;
        navMeshAgent.speed = movementSpeed;
        navMeshAgent.angularSpeed = rotationSpeed;
        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    public void SetEnemyController(IEnemyController enemyController) => this.enemyController = enemyController;

    public void StartTank(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
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

    public NavMeshAgent GetNaveMesh() => navMeshAgent;

    public bool GetTimerOff() => isTimerOff;

    public LayerMask GetPlayerLayer() => playerLayer;

    public Transform GetBulletSpawnPosition() => bulletSpawnPosition;

    public void BeginTimer()
    {
        StartCoroutine(StartTimer());
        isTimerOff = false;
    }
}
