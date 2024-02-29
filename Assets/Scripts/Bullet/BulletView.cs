using UnityEngine;

public class BulletView : MonoBehaviour
{
    bool canMove = false;
    private MeshRenderer meshRenderer;
    private BulletController bulletController;
    private float bulletSpeed;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(transform.forward * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Buildings")
        {
            Destroy(gameObject);
        }
    }

    public void SetBulletData(Material color, float bulletSpeed)
    {
        meshRenderer.material = color;
        this.bulletSpeed = bulletSpeed;
        canMove = true;
    }

    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}
