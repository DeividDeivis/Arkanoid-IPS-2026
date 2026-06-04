using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball") 
        {
            player.AddPoint();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }      
    }

    public void ResetValue() 
    {
        gameObject.SetActive(true);
    }
}
