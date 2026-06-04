using UnityEngine;

public class BallController : MonoBehaviour
{
    //public float force = 1;
    //public Rigidbody rb;
    private Vector3 initialPosition = Vector3.zero;

    public float ballSpeed = 1;
    public bool canMove = true;
    public Vector3 moveVector = new Vector3(1f, 1f, 0f);

    [SerializeField] private int bricksInLevel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector2.one * force, ForceMode.Force);*/
        initialPosition = transform.position;

        BrickController[] bricks = FindObjectsByType<BrickController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        bricksInLevel = bricks.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) 
        {
            transform.position += moveVector * ballSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Limit" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Brick") 
        {
            moveVector = Vector3.Reflect(moveVector, collision.contacts[0].normal);
        }
    }

    public int Bricks() 
    {
        return bricksInLevel;
    }

    public void ResetMovement()
    {
        transform.position = initialPosition;
        moveVector = new Vector3(1f, 1f, 0f);
    }

    public void ResetValues() 
    {
        BrickController[] bricks = FindObjectsByType<BrickController>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (var brick in bricks)
        {
            brick.ResetValue();
        }
        ResetMovement();
    }
}
