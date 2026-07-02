using System;
using UnityEngine;

public class BottomLimit : MonoBehaviour
{
    public static Action OnBallFall;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Ball") 
        { 
            OnBallFall?.Invoke();
        }    
    }
}
