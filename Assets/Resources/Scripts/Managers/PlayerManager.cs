using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerLocomotionManager playerLocomotionManager;
    CameraManager playerCamera;
    InputManager inputManager;
    AnimatorManager animationManager;
    PlayerManager playerManager;

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
        isPerformingAction = animationManager.animator.GetBool("IsPerformingAnimation");
        isPerformingQuickTurn = animationManager.animator.GetBool("isPerformingQuickTurn");
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
