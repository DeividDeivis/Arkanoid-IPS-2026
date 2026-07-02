using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private Button restartBtn;

    private static UIController _instance;
    public static UIController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            _instance = this;
        }
    }

    public void SetUpUI(UnityAction OnClick) 
    {
        restartBtn.onClick.AddListener(OnClick);
    }

    public void ResetUI() 
    {
        pointText.text = $"Puntos: 0";
        resultText.text = string.Empty;
        restartBtn.gameObject.SetActive(false);
    }

    public void SetPointsUI(int currentPoints) 
    {
        pointText.text = $"Puntos: {currentPoints}";
    }

    public void SetHealthUI(int currentLife)
    {
        lifeText.text = $"Vidas: {currentLife}";
    }

    public void ShowEndMessage(string message, Color color) 
    {
        resultText.color = color;
        resultText.text = message;
        restartBtn.gameObject.SetActive(true);
    }
}
