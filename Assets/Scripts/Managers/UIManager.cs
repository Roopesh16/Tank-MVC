using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveNumberText;
    public static UIManager instance = null;

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

    private void Start()
    {
        waveNumberText.gameObject.SetActive(false);
    }

    public async void SetWaveText(int waveNumber)
    {
        waveNumberText.gameObject.SetActive(true);
        waveNumberText.text = "WAVE NO. " + waveNumber;
        await Task.Delay(3000);
        waveNumberText.gameObject.SetActive(false);
    }
}
