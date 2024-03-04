using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Rigidbody tankRb;
    [SerializeField] private MeshRenderer[] meshRenderers = new MeshRenderer[4];
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Transform cameraPosition;

    private TankController tankController;
    private float movement;
    private float rotation;

    private void OnEnable()
    {
        GameManager.Instance.eventManager.OnGameOver.AddListener(TankDisable);
    }

    private void OnDisable()
    {
        GameManager.Instance.eventManager.OnGameOver.RemoveListener(TankDisable);
    }

    private void Start() => SetupCamera();

    private void Update()
    {
        Movement();

        if (movement != 0)
            tankController.Move(movement, tankController.GetTankModel().movement);

        if (rotation != 0)
            tankController.Rotate(rotation, tankController.GetTankModel().rotation);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            tankController.DecreaseHealth();
        }
    }

    public void SetTankController(TankController tankController) => this.tankController = tankController;

    public Rigidbody GetRigidbody() => tankRb;

    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }

    private void SetupCamera()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.transform.SetParent(cameraPosition);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localEulerAngles = Vector3.zero;
    }

    public void SetColor(Material color)
    {
        for (int i = 0; i < 4; i++)
        {
            meshRenderers[i].material = color;
        }
    }

    public Transform GetSpawnPoint() => bulletSpawn;

    private void TankDisable() => gameObject.SetActive(false);
}
