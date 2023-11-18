using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerWalkSpeed = 3f;
    [SerializeField] private float playerRunSpeed = 5f;
    [SerializeField] private float playerRotationSpeed = 6f;
    private float playerMovementSpeed;
    private bool isWalking;

    private void Start()
    {
        playerMovementSpeed = playerWalkSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 playerInputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            playerInputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerInputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerInputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerInputVector.x = 1;
        }
        playerInputVector = playerInputVector.normalized;

        Vector3 moveDirection = new Vector3(playerInputVector.x, 0f, playerInputVector.y);
        isWalking = moveDirection != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, playerRotationSpeed * Time.deltaTime);

        transform.position += moveDirection * playerMovementSpeed * Time.deltaTime;
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
