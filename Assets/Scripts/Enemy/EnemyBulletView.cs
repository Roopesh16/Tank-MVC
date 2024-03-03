using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletView : MonoBehaviour
{
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
        if(other.gameObject.CompareTag("Player"))
            Debug.Log("hit");
        Destroy(gameObject);
    }

    public void SetEnemyBulletView(Vector3 forward, float bulletSpeed)
    {
        transform.forward = forward;
        this.bulletSpeed = bulletSpeed;
        canMove = true;
    }
}
