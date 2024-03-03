using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private const int uiTimer = 3000;

    public int UITimer
    {
        get { return uiTimer; }
    }

    private int bulletDamage;
    private int enemyDamage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void SetupNewGame(TankController tankController, int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
        WaveManager.instance.SetTankController(tankController);
        WaveManager.instance.SetupNewWave();
    }

    public int GetBulletDamage()
    {
        return bulletDamage;
    }

    public int GetEnemyDamage()
    {
        return enemyDamage;
    }

    public void SetEnemyDamage(int enemyDamage)
    {
        this.enemyDamage = enemyDamage;
    }

    public void SetNewCamera(Vector3 position, Vector3 angles)
    {
        newCamera.gameObject.SetActive(true);
        newCamera.transform.position = position;
        newCamera.transform.eulerAngles = angles;
    }
}
