using UnityEngine;
using Bullet;

public class BulletView : MonoBehaviour
{
    [SerializeField] private LayerMask impactLayer;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem bulletBlastParticle;
    
    private bool canMove = false;
    private BulletController bulletController;
    private float blastRadius;
    private float bulletSpeed;
    

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
            bulletController.OnBulletHit();
        }
    }

    public void InitBulletView(Material color, float blastRadius,float bulletSpeed)
    {
        meshRenderer.material = color;
        this.blastRadius = blastRadius;
        this.bulletSpeed = bulletSpeed;
    }

    public void ShootBullet()
    {
        meshRenderer.enabled = true;
        canMove = true;
    }

    public void SetBulletController(BulletController bulletController) => this.bulletController = bulletController;

    public void BlastImpact()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, blastRadius, impactLayer);

        foreach (Collider hit in hits)
        {
            if(hit.CompareTag("EnemyTank"))
                hit.GetComponent<EnemyView>().DecreaseHealth();
        }
    }

    public ParticleSystem GetBlastParticle() => bulletBlastParticle;

    public void StopBullet(Transform spawnPoint)
    {
        canMove = false;
        transform.position = spawnPoint.position;
        transform.forward = spawnPoint.forward;
    }
    public void DisableMesh() => meshRenderer.enabled = false;

}
