using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private GameObject bulletBlastPrefab;
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
        if (other.tag == "Buildings")
        {
            GameObject shellBlast = Instantiate(bulletBlastPrefab);
            shellBlast.transform.position = transform.position;
            shellBlast.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
            Destroy(shellBlast, shellBlast.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject, shellBlast.GetComponent<ParticleSystem>().main.duration);
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
