using System;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public static Action OnBallCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball") 
        {
            OnBallCollision?.Invoke();
            gameObject.SetActive(false);
        }      
    }

    public void ResetValue() 
    {
        gameObject.SetActive(true);
    }
}