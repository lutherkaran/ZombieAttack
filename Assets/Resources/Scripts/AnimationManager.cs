using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    float SnappedHorizontal = 0;
    float SnappedVertical = 0;

    public Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void HandleAnimatorValues(float HoziontalMovement, float VerticalMovement)
    {
        SnapMovements(HoziontalMovement, VerticalMovement);

        Animator.SetFloat("Horizontal", HoziontalMovement, 0.1f, Time.deltaTime);
        Animator.SetFloat("Vertical", VerticalMovement, 0.1f, Time.deltaTime);
    }

    private void SnapMovements(float HoziontalMovement, float VerticalMovement)
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
        { SnappedVertical = 0; }
    }
}
