using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem dustPS;

    private Animator animator;
    private Rigidbody2D myRigidbody;

    private readonly string PLAYER_RUNNING = "running";
    private readonly string PLAYER_JUMPING = "jumping";
    private readonly string PLAYER_FALLING = "falling";
    private readonly string PLAYER_DIEING = "dieing";
    private readonly string PLAYER_DAMAGED = "damaged";

    private bool playerDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetRunningBool(bool running)
    {
        animator.SetBool(PLAYER_RUNNING, running);
    }

    private void SetJumpingBool(bool jumping)
    {
        animator.SetBool(PLAYER_JUMPING, jumping);
    }

    public void StartJumpingAnimation()
    {
        if(!playerDead)
        {
            SetJumpingBool(true);
            CreateDust();
        }
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
        if(!playerDead)
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

    public void StartDieAnimation()
    {
        playerDead = true;
        animator.SetBool(PLAYER_DIEING, true);
        SetFallingBool(false);
    }

    public void SetDieingBoolFlase()
    {
        animator.SetBool(PLAYER_DIEING, false);
    }

    public void PlayerDamagedAnimation()
    {
        animator.SetBool(PLAYER_DAMAGED, true);
    }

    public void SetDamagedAnimationFalse()
    {
        animator.SetBool(PLAYER_DAMAGED, false);
    }

    public void CreateDust() { dustPS.Play(); }
}
