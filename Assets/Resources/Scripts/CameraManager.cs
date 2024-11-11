using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("References")]
    public InputManager inputManager;
    public Transform cameraPivot;
    public Camera cameraObject;
    public GameObject player;

    Vector3 targetPosition;
    Vector3 cameraFollowVelocity = Vector3.zero;
    Vector3 cameraRotation;
    Quaternion targetRotation;

    [Header("Camera Speed")]
    public float cameraSmoothTime = 0.2f;

    float lookAmountVertical;
    float lookAmountHorizontal;
    float maximumPivotAngle = 15f;
    float minimumPivoteAngle = -15f;


    private void Awake()
    {
    }

    public void HandleCameraMovement()
    {
        //Follow The player
        FollowPlayer();
        //Rotate The Camera
        RotateCamera();

        HandleCameraCollision();
    }

    public void FollowPlayer()
    {
        targetPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraFollowVelocity, cameraSmoothTime * Time.deltaTime);
        transform.position = targetPosition;
    }

    public void RotateCamera()
    {
        lookAmountVertical += inputManager.horizontalCameraInput; // how much to look right/light around y-axis 
        lookAmountHorizontal -= inputManager.verticalCameraInput; // how much To look up/down around x-axis
        lookAmountHorizontal = Mathf.Clamp(lookAmountHorizontal, minimumPivoteAngle, maximumPivotAngle);

        cameraRotation = Vector3.zero;
        cameraRotation.y = lookAmountVertical;
        targetRotation = Quaternion.Euler(cameraRotation);
        targetRotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSmoothTime);
        transform.rotation = targetRotation;

        if (inputManager.quickTurnInput)
        {
            inputManager.quickTurnInput = false;
            lookAmountVertical += 180;
            cameraRotation.y += 180;
            transform.rotation = targetRotation;
        }

        cameraRotation = Vector3.zero;
        cameraRotation.x = lookAmountHorizontal;
        targetRotation = Quaternion.Euler(cameraRotation);
        targetRotation = Quaternion.Slerp(cameraPivot.localRotation, targetRotation, cameraSmoothTime);
        cameraPivot.localRotation = targetRotation;
    }

    public void HandleCameraCollision()
    {

    }
}
