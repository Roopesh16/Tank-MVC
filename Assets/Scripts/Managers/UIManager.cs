using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI waveNumberText;
    private GameObject gameOverObject;
    public static UIManager instance = null;

    public UIManager(TextMeshProUGUI waveNumberText, GameObject gameOverObject)
    {
        this.waveNumberText = waveNumberText;
        this.gameOverObject = gameOverObject;
    }

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

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        EventManager.Instance.OnGameOver.AddListener(DisplayGameOver);
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGameOver.RemoveListener(DisplayGameOver);
    }

    private void Start()
    {
        waveNumberText.gameObject.SetActive(false);
        gameOverObject.SetActive(false);
    }

    public void SetWaveText()
    {
        waveNumberText.gameObject.SetActive(true);
        waveNumberText.text = "WAVE NO. " + WaveManager.instance.GetWaveNumber();
    }

    public void DisableWaveText() => waveNumberText.gameObject.SetActive(false);

    public void DisplayGameOver() => gameOverObject.SetActive(true);
}
