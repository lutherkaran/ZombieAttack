using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    float SnappedHorizontal = 0;
    float SnappedVertical = 0;

    [SerializeField]
    float speed = 100f;

    public Animator animator;
    PlayerLocomotionManager playerLocomotionManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }

    public void Update()
    {

    }
    public void PlayAnimationWithoutRootMotion(string targetAnimation, bool isPerformingAction)
    {
        animator.SetBool("IsPerformingAction", isPerformingAction);
        animator.applyRootMotion = false;
        animator.CrossFade(targetAnimation, 0.2f);
    }

    public void HandleAnimatorValues(float HoziontalMovement, float VerticalMovement, bool isRunning)
    {
        if (HoziontalMovement > 0)
        {
            SnappedHorizontal = 1;
        }
        else if (HoziontalMovement < 0)
        {
            SnappedHorizontal = -1;
        }
        else { SnappedHorizontal = 0; }

        if (VerticalMovement > 0)
        {
            SnappedVertical = 1;
        }
        else if (VerticalMovement < 0)
        {
            SnappedVertical = -1;
        }
        else
        {
            SnappedVertical = 0;
        }

        if (isRunning && SnappedVertical > 0)
        {
            SnappedVertical = 2;
        }

        animator.SetFloat("Horizontal", SnappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat("Vertical", SnappedVertical, 0.1f, Time.deltaTime);
    }

    // Whenever there's an animation playing on animator and has a root motion, it's gonna mimic that animation to player's rigidbody. 
    private void OnAnimatorMove()
    {
        Vector3 animationDeltaPosition = animator.deltaPosition;
        animationDeltaPosition.y = 0;

        Vector3 velocity = animationDeltaPosition / Time.deltaTime;
        playerLocomotionManager.playerRigidbody.drag = 0;
        playerLocomotionManager.playerRigidbody.velocity = velocity;
        transform.rotation *= animator.deltaRotation;

    }
}
