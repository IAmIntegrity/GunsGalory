using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVector2Normalized()
    {
        Vector2 playerInputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        playerInputVector = playerInputVector.normalized;

        return playerInputVector;
    }

    public Vector2 GetLookVector2()
    {
        Vector2 playerLookVector = playerInputActions.Player.Look.ReadValue<Vector2>();

        return playerLookVector;
    }
}
