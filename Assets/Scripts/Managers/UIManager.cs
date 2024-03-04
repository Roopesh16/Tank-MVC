using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI waveNumberText;
    private GameObject gameOverObject;

    public UIManager(TextMeshProUGUI waveNumberText, GameObject gameOverObject)
    {
        this.waveNumberText = waveNumberText;
        this.gameOverObject = gameOverObject;
        Init();
    }

    private void OnEnable()
    {
        EventManager.Instance.OnGameOver.AddListener(DisplayGameOver);
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGameOver.RemoveListener(DisplayGameOver);
    }

    private void Init()
    {
        waveNumberText.gameObject.SetActive(false);
        gameOverObject.SetActive(false);
    }

    public void SetWaveText()
    {
        waveNumberText.gameObject.SetActive(true);
        waveNumberText.text = "WAVE NO. " + GameManager.Instance.waveManager.GetWaveNumber();
    }

    public void DisableWaveText() => waveNumberText.gameObject.SetActive(false);

    public void DisplayGameOver() => gameOverObject.SetActive(true);
}
