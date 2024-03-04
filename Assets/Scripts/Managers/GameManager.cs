using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float maxTime;

    public static GameManager instance = null;
    private const int uiTimer = 3000;


    public Camera newCamera;

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

    private void OnEnable()
    {
        EventService.Instance.OnGameOver.AddListener(SetNewCamera);
    }

    private void OnDisable()
    {
        EventService.Instance.OnGameOver.RemoveListener(SetNewCamera);
    }

    void Start() => newCamera.gameObject.SetActive(false);

    public void SetupNewGame(TankController tankController, int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
        WaveManager.instance.SetTankController(tankController);
        SetupNewWave();
    }

    public int GetBulletDamage() => bulletDamage;

    public int GetEnemyDamage() => enemyDamage;

    public void SetEnemyDamage(int enemyDamage) => this.enemyDamage = enemyDamage;

    public void SetNewCamera() => newCamera.gameObject.SetActive(true);

    public void SetupNewWave()
    {
        UIManager.instance.SetWaveText();
        StartCoroutine(WaitProcess());
    }

    private IEnumerator WaitProcess()
    {
        yield return new WaitForSeconds(maxTime);
        UIManager.instance.DisableWaveText();
        WaveManager.instance.StartNewWave();
    }
}
