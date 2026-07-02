using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int playerlifes = 3; // Max Lifes
    private HealthSystem health;
    [SerializeField] private int pointsForBrick = 1; // Reward points peer brick destroyed
    private PointSystem points;

    private BallController ball;
    private PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = new HealthSystem(playerlifes);
        points = new PointSystem(BricksManager.Instance.TotalBricks);

        ball = FindFirstObjectByType<BallController>();
        player = FindFirstObjectByType<PlayerController>();

        UIController.Instance.SetUpUI(ResetGame);

        BrickController.OnBallCollision += UpdatePoints;
        BottomLimit.OnBallFall += OnLoseLife;

        ResetGame();
    }

    public void UpdatePoints()
    {
        points.AddPoints(pointsForBrick);

        if (points.IsWin)
        {
            UIController.Instance.ShowEndMessage("GAME COMPLETE", Color.green);
            Time.timeScale = 0;
        }
    }

    private void OnLoseLife()
    {
        health.SubstractHealth();
        if (health.IsDead)
        {
            UIController.Instance.ShowEndMessage("GAME OVER", Color.red);
            Time.timeScale = 0;
        }
        else 
        {
            player.ResetPosition();
            ball.ResetMovement();
        }
    }

    private void ResetGame()
    {
        UIController.Instance.ResetUI();
        BricksManager.Instance.ResetBricks();

        ball.ResetMovement();
        player.ResetPosition();

        points.ResetPoint();
        health.ResetHealth();
        //health = new HealthSystem(playerlifes); // Alternative reset option

        Time.timeScale = 1;
    }
}
