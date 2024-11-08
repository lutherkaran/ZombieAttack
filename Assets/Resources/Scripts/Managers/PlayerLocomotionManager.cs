using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotionManager : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    InputManager inputManager;
    PlayerManager playerManager;

    [Header("Camera Transform")]
    public Transform playerCameraTransform;

    [Header("Movement Speed")]
    public float roationSpeed = 3.5f;
    public float quickTurnSpeed = 8f;

    [Header("Rotation Fields")]
    Quaternion targetRotation;
    Quaternion playerRotation;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        playerManager = GetComponent<PlayerManager>();
    }

    public void HandleAllLocomotion()
    {
        HandleRotation();
        //HandleFalling();
    }

    public void HandleRotation()
    {
        targetRotation = Quaternion.Euler(0, playerCameraTransform.eulerAngles.y, 0);
        playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, roationSpeed * Time.deltaTime);

        if (inputManager.verticalMovementInput != 0 || inputManager.horizontalMovementInput != 0)
        {
            transform.rotation = playerRotation;
        }

        if (playerManager.isPerformingQuickTurn)
        {
            playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, quickTurnSpeed * Time.deltaTime);
            transform.rotation = playerRotation;
        }
    }
}
