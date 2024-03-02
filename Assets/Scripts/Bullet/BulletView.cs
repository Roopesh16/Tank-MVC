using UnityEngine;
using UnityEngine.Rendering;

public class BulletView : MonoBehaviour
{
    [SerializeField] private GameObject bulletBlastPrefab;
    [SerializeField] private LayerMask impactLayer;
    bool canMove = false;
    private MeshRenderer meshRenderer;
    private BulletController bulletController;
    private float blastRadius;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Buildings")
        {
            BlastImpact();
            GameObject shellBlast = Instantiate(bulletBlastPrefab);
            shellBlast.transform.position = transform.position;
            shellBlast.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
            Destroy(shellBlast, shellBlast.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject, shellBlast.GetComponent<ParticleSystem>().main.duration);
        }
    }

    public void SetBulletData(Material color, float bulletSpeed, float blastRadius)
    {
        meshRenderer.material = color;
        this.bulletSpeed = bulletSpeed;
        this.blastRadius = blastRadius;
        canMove = true;
    }

    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    private void BlastImpact()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, blastRadius, impactLayer);
    }
}
