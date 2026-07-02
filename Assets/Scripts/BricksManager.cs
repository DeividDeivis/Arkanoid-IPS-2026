using UnityEngine;

public class BricksManager : MonoBehaviour
{
    [SerializeField] private int bricksInLevel = 0;
    public int TotalBricks => bricksInLevel;

    #region Singleton
    private static BricksManager _instance;
    public static BricksManager Instance { get { return _instance; } }

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

        FindBricks();
    }
    #endregion
    
    private void FindBricks()
    {
        BrickController[] bricks = FindObjectsByType<BrickController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        bricksInLevel = bricks.Length;
    }

    public void ResetBricks()
    {
        BrickController[] bricks = FindObjectsByType<BrickController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var brick in bricks)
        {
            brick.ResetValue();
        }
    }
}
