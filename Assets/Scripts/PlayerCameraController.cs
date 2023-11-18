using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraController : MonoBehaviour
{
    //[SerializeField] private CinemachineVirtualCamera walkCam;
    [SerializeField] private CinemachineVirtualCamera runCam;
    [SerializeField] private Player player;

    private void Update()
    {
        runCam.gameObject.SetActive(player.IsRuning());
    }
}
