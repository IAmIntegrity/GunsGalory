using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    private const string IS_WALKING = "IsWalking";
    private const string IS_RUNNING = "IsRunning";

    private void Update()
    {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
        animator.SetBool(IS_RUNNING, playerMovement.IsRuning());
    }
}
