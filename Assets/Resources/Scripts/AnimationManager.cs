using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    float SnappedHorizontal = 0;
    float SnappedVertical = 0;

    [SerializeField]
    float speed = 100f;

    public Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void Update()
    {
        PlayerInput();
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

    private void PlayerInput()
    {
        float xDirection = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(xDirection, yDirection, 0).normalized * speed * Time.deltaTime;

        HandleAnimatorValues(moveDirection.x, moveDirection.y);
    }
}
