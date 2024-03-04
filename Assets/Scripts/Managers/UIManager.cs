using UnityEngine;
using TMPro;

public class UIManager
{
    private TextMeshProUGUI waveNumberText;
    private GameObject gameOverObject;
    private GameObject mainMenu;
    private Button playButton;
    private GameObject lobbyUI;

    public UIManager(TextMeshProUGUI waveNumberText, GameObject gameOverObject,GameObject mainMenu, 
                    Button playButton, GameObject lobbyUI)
    {
        this.waveNumberText = waveNumberText;
        this.gameOverObject = gameOverObject;
        this.mainMenu = mainMenu;
        this.playButton = playButton;
        this.lobbyUI = lobbyUI;
        Init();
    }

    public void OnEnable()
    {
        GameManager.Instance.eventManager.OnGameOver.AddListener(DisplayGameOver);
        GameManager.Instance.eventManager.OnNewWave.AddListener(DisableWaveText);

    }

    public void OnDisable()
    {
        GameManager.Instance.eventManager.OnGameOver.RemoveListener(DisplayGameOver);
        GameManager.Instance.eventManager.OnNewWave.RemoveListener(DisableWaveText);
    }

    private void Init()
    {
        waveNumberText.gameObject.SetActive(false);
        gameOverObject.SetActive(false);
        OnEnable();
    }

    public void SetWaveText()
    {
        waveNumberText.gameObject.SetActive(true);
        waveNumberText.text = "WAVE NO. " + GameManager.Instance.waveManager.GetWaveNumber();
    }

    public void DisableWaveText() => waveNumberText.gameObject.SetActive(false);

    public void DisplayGameOver() => gameOverObject.SetActive(true);
}
