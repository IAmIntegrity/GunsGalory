using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] CameraLook cameraLook;
    [SerializeField] private float playerWalkSpeed = 3f;
    [SerializeField] private float playerRunSpeed = 5f;
    private float playerMovementSpeed;
    private bool isWalking;
    private bool isRuning;

    private void Start()
    {
        playerMovementSpeed = playerWalkSpeed;
    }

    public void MovePlayer()
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

        transform.position += transform.TransformDirection(moveDirection) * playerMovementSpeed * Time.deltaTime;
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
