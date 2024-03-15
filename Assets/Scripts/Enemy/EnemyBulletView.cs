using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletView : MonoBehaviour
{
    [SerializeField] private GameObject tankExplosionParticle;
    private bool canMove = false;
    private float timer = 0f;
    private const float maxTime = 3f;

    private EnemyController enemyController;

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
            GameObject particle = Instantiate(tankExplosionParticle);
            particle.transform.position = transform.position;
            particle.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
            Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject, particle.GetComponent<ParticleSystem>().main.duration);
        }
    }

    public void SetEnemyController(EnemyController enemyController) => this.enemyController = enemyController;

    public void InitEnemyBulletView(Vector3 forward)
    {
        transform.forward = forward;
        canMove = true;
    }
}
