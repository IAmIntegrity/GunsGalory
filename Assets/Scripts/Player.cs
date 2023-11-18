using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] private float playerWalkSpeed = 3f;
    [SerializeField] private float playerRunSpeed = 5f;
    [SerializeField] private float playerRotationSpeed = 6f;
    private float playerMovementSpeed;
    private bool isWalking;
    private bool isRuning;

    private void Start()
    {
        playerMovementSpeed = playerWalkSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isWalking)
        {
            isRuning = true;
            playerMovementSpeed = playerRunSpeed;
        }
        else
        {
            isRuning = false;
            playerMovementSpeed = playerWalkSpeed;
        }

        Vector2 playerInputVector = gameInput.GetMovementVector2Normalized();

        Vector3 moveDirection = new Vector3(playerInputVector.x, 0f, playerInputVector.y);
        isWalking = moveDirection != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, playerRotationSpeed * Time.deltaTime);

        transform.position += moveDirection * playerMovementSpeed * Time.deltaTime;
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    public bool IsRuning()
    {
        return isRuning;
    }
}
