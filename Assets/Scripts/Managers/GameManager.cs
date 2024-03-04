using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : GenericMonoSingleton<GameManager>
{
    [Header("Game Manager References")]
    [SerializeField] private float maxTime;
    [SerializeField] private Camera newCamera;

    [Header("Wave Manager References")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private List<WaveScriptableObject> wavesList = new();

    [Header("UI Manager References")]
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private GameObject gameOverObject;

    private int bulletDamage;
    private int enemyDamage;

    public WaveManager waveManager { get; private set; }
    public UIManager uIManager { get; private set; }
    public EventManager eventManager { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        eventManager = new EventManager();
    }

    private void OnEnable()
    {
        EventManager.Instance.OnGameOver.AddListener(SetNewCamera);
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGameOver.RemoveListener(SetNewCamera);
    }

    void Start()
    {
        waveManager = new WaveManager(enemySpawner, wavesList);
        uIManager = new UIManager(waveNumberText, gameOverObject);

    }

    public void SetupNewGame(TankController tankController, int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
        waveManager.SetTankController(tankController);
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
        waveManager.StartNewWave();
    }
}
