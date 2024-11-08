using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animationManager;
    PlayerManager playerManager;
    Animator animator;

    [Header("Player Movement")]
    public float verticalMovementInput;
    public float horizontalMovementInput;
    private Vector2 movementInput;

    [Header("Camera Rotation")]
    public float verticalCameraInput;
    public float horizontalCameraInput;
    private Vector2 cameraInput;

    [Header("Button Inputs")]
    public bool runInput;
    public bool quickTurnInput;

    private void Awake()
    {
        animationManager = GetComponent<AnimatorManager>();
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += ctx => cameraInput = ctx.ReadValue<Vector2>();
            playerControls.PlayerMovement.Run.performed += ctx => runInput = true;
            playerControls.PlayerMovement.Run.canceled += ctx => runInput = false;
            playerControls.PlayerMovement.QuickTurn.performed += ctx => quickTurnInput = true;
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleCameraInput();
        HandleQuickTurnInput();
    }

    public void HandleMovementInput()
    {
        horizontalMovementInput = movementInput.x;
        verticalMovementInput = movementInput.y;
        animationManager.HandleAnimatorValues(horizontalMovementInput, verticalMovementInput, runInput);
    }

    public void HandleCameraInput()
    {
        horizontalCameraInput = cameraInput.x;
        verticalCameraInput = cameraInput.y;
    }

    private void HandleQuickTurnInput()
    {
        if (playerManager.isPerformingAction) return;
        if (quickTurnInput)
        {
            animator.SetBool("IsPerformingQuickTurn", true);
            animationManager.PlayAnimationWithoutRootMotion("QuickTurn", true);
        }
    }
}
