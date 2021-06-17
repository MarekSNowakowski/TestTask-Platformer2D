using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D myRigidbody;

    private readonly string PLAYER_RUNNING = "running";
    private readonly string PLAYER_JUMPING = "jumping";
    private readonly string PLAYER_FALLING = "falling";

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetRunningBool(bool running)
    {
        animator.SetBool(PLAYER_RUNNING, running);
    }

    public void SetJumpingBool(bool jumping)
    {
        animator.SetBool(PLAYER_JUMPING, jumping);
    }

    //Set jumping bool to flase inside of startJump animation
    public void StopJumpingBool()
    {
        SetJumpingBool(false);
    }

    public void SetFallingBool(bool falling)
    {
        animator.SetBool(PLAYER_FALLING, falling);
    }

    private readonly float fallingVelocityValue = -0.3f;

    private void LateUpdate()
    {
        if (myRigidbody.velocity.y < fallingVelocityValue)
        {
            SetFallingBool(true);
        }
        else
        {
            SetFallingBool(false);
        }
    }
}
