using UnityEngine;

public class EnemyBulletView : MonoBehaviour
{
    private float bulletSpeed;
    private bool canMove = false;
    void Update()
    {
        if (canMove)
        {
            transform.Translate(transform.forward * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    public void SetEnemyBulletView(Vector3 forward, float bulletSpeed)
    {
        transform.forward = forward;
        this.bulletSpeed = bulletSpeed;
        canMove = true;
    }
}
