using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CameraLook cameraLook;

    private void Update()
    {
        playerMovement.MovePlayer();
        cameraLook.PlayerLook();
    }
}
