using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : GenericMonoSingleton<GameManager>
{
    [SerializeField] private BulletSpawner bulletSpawner;
    
    [Header("Game Manager References")]
    [SerializeField] private float maxTime;
    [SerializeField] private Camera newCamera;

    [Header("Wave Manager References")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private List<WaveScriptableObject> wavesList = new();

    [Header("UI Manager References")]
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject lobbyUI;

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
        eventManager.OnGameOver.AddListener(SetNewCamera);
    }

    private void OnDisable()
    {
        uIManager.OnDisable();
        waveManager.OnDisable();
        eventManager.OnGameOver.RemoveListener(SetNewCamera);
    }

    private void Start()
    {
        waveManager = new WaveManager(enemySpawner, wavesList);
        uIManager = new UIManager(waveNumberText, gameOverObject, mainMenu, lobbyUI);
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
        uIManager.SetWaveText();
        StartCoroutine(WaitProcess());
    }

    public void PlayButton()
    {
        uIManager.DisplayLobby();
    }

    private IEnumerator WaitProcess()
    {
        yield return new WaitForSeconds(maxTime);
        eventManager.OnNewWave.InvokeEvent();
    }

    public BulletSpawner GetBulletSpawner() => bulletSpawner;
}
