using UnityEditor;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Rigidbody tankRb;
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

        if(movement!=0)
            tankController.Move(movement, 30f);
        
        if(rotation!=0)
            tankController.Rotate(rotation, 20f);
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
        mainCamera.transform.SetParent(gameObject.transform);
        mainCamera.transform.position = new Vector3(0f, 3f, -6f);
    }
}
