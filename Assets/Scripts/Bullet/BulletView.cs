using UnityEngine;
using UnityEngine.Rendering;

public class BulletView : MonoBehaviour
{
    [SerializeField] private LayerMask impactLayer;
    
    private bool canMove = false;
    private ParticleSystem bulletBlastParticle;
    private MeshRenderer meshRenderer;
    private BulletController bulletController;
    private float blastRadius;
    private float bulletSpeed;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        bulletBlastParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(transform.forward * 
                                              (bulletSpeed * Time.deltaTime), Space.World);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Buildings") || other.gameObject.CompareTag("EnemyTank"))
        {
            BlastImpact();
            bulletBlastParticle.Play();
            canMove = false;
            meshRenderer.enabled = false;
            Destroy(gameObject,bulletBlastParticle.main.duration);
        }
    }

    public void InitBulletView(Material color, float blastRadius,float bulletSpeed)
    {
        meshRenderer.material = color;
        this.blastRadius = blastRadius;
        this.bulletSpeed = bulletSpeed;
        canMove = true;
    }

    public void SetBulletController(BulletController bulletController) => this.bulletController = bulletController;

    private void BlastImpact()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, blastRadius, impactLayer);

        foreach (Collider hit in hits)
        {
            if(hit.CompareTag("EnemyTank"))
                hit.GetComponent<EnemyView>().DecreaseHealth();
        }
    }
}
