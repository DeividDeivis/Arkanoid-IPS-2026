using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int lifes = 3; // Max Lifes
    private int currentLife = 0; // Real Time Lifes
    [SerializeField] private int points = 0;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float limitX = 2;
    private GameActions actionsInputs;

    [SerializeField] private BallController ball;

    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button restartBtn;

    void Awake()
    {
        actionsInputs = new GameActions();
        //currentLife = lifes;
        ResetValues();
        restartBtn.onClick.AddListener(ResetValues);
    }

    void OnEnable()
    {
        actionsInputs.Enable();
    }

    void OnDisable()
    {
        actionsInputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        float moveX = actionsInputs.Player.Horizontal.ReadValue<float>();
        transform.position += new Vector3(moveX * moveSpeed * Time.deltaTime, 0f, 0f);

        //Debug.Log("Distance : " + Vector3.Distance(transform.position, ball.transform.position));

        // Limit X movement
        float clampPosX = Mathf.Clamp(transform.position.x, -limitX, limitX);
        transform.position = new Vector3(clampPosX, transform.position.y, transform.position.z);
    }

    public void SubstractLife() 
    {
        currentLife--;
        currentLife = Mathf.Clamp(currentLife, 0, lifes);
        SetLife(currentLife);
        if (currentLife == 0) 
        {
            resultText.text = "<color=red>GAME OVER</color>";
            restartBtn.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddPoint()
    {
        UpdatePoint(1);
        if (points == ball.Bricks())
        {
            resultText.text = "<color=green>GAME COMPLETE</color>";
            restartBtn.gameObject.SetActive(true);
            Time.timeScale = 0;     
        }
    }

    private void UpdatePoint(int point) 
    {
        points += point;
        pointText.text = $"Puntos: {points}";
    }

    /// <summary>
    /// Metodo que setea el valor actual de la vida
    /// </summary>
    /// <param name="life">valor a guardar en current life</param>
    private void SetLife(int life)
    {
        currentLife = life;
        lifeText.text = $"Vidas: {currentLife}";
    }

    /// <summary>
    /// 
    /// </summary>
    public void ResetPosition() 
    {
        transform.position = new Vector3(0f, transform.position.y, 0f);
    }

    private void ResetValues() 
    {
        ResetPosition();
        UpdatePoint(-points);
        SetLife(lifes);
        resultText.text = string.Empty;
        restartBtn.gameObject.SetActive(false);
        ball.ResetValues();
        Time.timeScale = 1;
    }
}
