using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerLocomotionManager playerLocomotionManager;
    CameraManager playerCamera;
    InputManager inputManager;
    AnimatorManager animationManager;

    [Header("Player Flags")]
    public bool isPerformingAction;
    public bool isPerformingQuickTurn;

    private void Awake()
    {
        playerCamera = FindObjectOfType<CameraManager>();
        inputManager = GetComponent<InputManager>();
        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        animationManager = GetComponent<AnimatorManager>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        isPerformingAction = animationManager.animator.GetBool("IsPerformingAction");
        isPerformingQuickTurn = animationManager.animator.GetBool("IsPerformingQuickTurn");
    }

    private void FixedUpdate()
    {
        playerLocomotionManager.HandleAllLocomotion();
    }

    private void LateUpdate()
    {
        playerCamera.HandleCameraMovement();
    }
}
