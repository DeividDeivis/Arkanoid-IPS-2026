using UnityEngine;

public class BottomLimit : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Ball") 
        { 
            player.SubstractLife();
            player.ResetPosition();
            collider.GetComponent<BallController>().ResetMovement();
        }    
    }
}
