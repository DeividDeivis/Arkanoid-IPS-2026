using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 initialPosition = Vector3.zero;

    public float ballSpeed = 1;
    public bool canMove = true;
    public Vector3 moveVector = new Vector3(1f, 1f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
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

    public void ResetMovement()
    {
        transform.position = initialPosition;
        moveVector = new Vector3(1f, 1f, 0f);
    }
}
