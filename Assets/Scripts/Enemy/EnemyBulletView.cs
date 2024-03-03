using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletView : MonoBehaviour
{
    [SerializeField] private GameObject tankExplosionParticle;
    private float bulletSpeed;
    private bool canMove = false;
    private float timer = 0f;
    private float maxTime = 3f;

    private void Update()
    {
        if (canMove)
        {
            transform.Translate(transform.forward * bulletSpeed * Time.deltaTime, Space.World);

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

    public void SetEnemyBulletView(Vector3 forward, float bulletSpeed)
    {
        transform.forward = forward;
        this.bulletSpeed = bulletSpeed;
        canMove = true;
    }
}
