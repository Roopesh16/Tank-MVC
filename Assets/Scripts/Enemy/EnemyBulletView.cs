using UnityEngine;

public class EnemyBulletView : MonoBehaviour
{
    private ParticleSystem tankExplosionParticle;
    private bool canMove = false;
    private float timer = 0f;
    private const float maxTime = 3f;

    private IEnemyController enemyController;

    private void Awake()
    {
        tankExplosionParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (canMove)
        {
            enemyController.MoveBullet();
            
            timer += Time.deltaTime;
            if (timer >= maxTime)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tankExplosionParticle.Play();
            canMove = false;
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, tankExplosionParticle.main.duration);
        }
    }

    public void SetEnemyController(IEnemyController enemyController) => this.enemyController = enemyController;

    public void InitEnemyBulletView(Vector3 forward)
    {
        transform.forward = forward;
        canMove = true;
    }
}
