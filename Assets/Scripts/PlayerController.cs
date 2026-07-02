using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float limitX = 2;
    private GameActions actionsInputs;

    void Awake()
    {
        actionsInputs = new GameActions();
        ResetPosition();
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

        // Limit X movement
        float clampPosX = Mathf.Clamp(transform.position.x, -limitX, limitX);
        transform.position = new Vector3(clampPosX, transform.position.y, transform.position.z);
    }

    public void ResetPosition() 
    {
        transform.position = new Vector3(0f, transform.position.y, 0f);
    }
}

