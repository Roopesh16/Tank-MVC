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

    void Start()
    {
        SetupCamera();
    }

    void Update()
    {
        Movement();

        if (movement != 0)
            tankController.Move(movement, tankController.GetTankModel().movement);

        if (rotation != 0)
            tankController.Rotate(rotation, tankController.GetTankModel().rotation);
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    public Rigidbody GetRigidbody()
    {
        return tankRb;
    }

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

    public Transform GetSpawnPoint()
    {
        return bulletSpawn;
    }

    public Transform GetPosition()
    {
        return transform;
    }
}
