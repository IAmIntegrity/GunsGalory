using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameInput gameInput;
    private float xRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PlayerLook()
    {
        float mouseX = gameInput.GetLookVector2().x;
        float mouseY = gameInput.GetLookVector2().y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity; //calculate for looking up and down, rotating on x axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamp so can look straight up and down

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity); //rotate player to look left and right
    }
}
