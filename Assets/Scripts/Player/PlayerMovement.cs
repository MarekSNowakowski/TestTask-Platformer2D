using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IKnockbackable
{
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private int extraJumps;
    private int extraJumpsLeft;

    [SerializeField]
    private GroundCheck groundCheck;

    [SerializeField]
    private PlayerAnimations playerAnimations;

    private Rigidbody2D myRigidbody;
    private bool facingRight = true;
    private float moveInputX;
    [SerializeField]
    private float knockbackTime;
    [SerializeField]
    private float knocbackForce;

    private PlayerMoveState moveState = PlayerMoveState.Idle;

    private readonly string HORIZONTAL_AXIS = "Horizontal";

    private readonly string JUMP_KEY = "Jump";

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (moveState == PlayerMoveState.Idle || moveState == PlayerMoveState.Moving || moveState == PlayerMoveState.Falling)
        {
            Move();
            ChangeSide();
        }
    }

    private readonly float fallingVelocityValue = -0.3f;

    private void LateUpdate()
    {
        HandleFalling();
    }

    private void Update()
    {
        Jump();
    }

    private void HandleFalling()
    {
        if (myRigidbody.velocity.y < fallingVelocityValue &&
            (moveState == PlayerMoveState.Idle || moveState == PlayerMoveState.Moving || moveState == PlayerMoveState.Falling))
        {
            moveState = PlayerMoveState.Falling;
            playerAnimations.SetFallingBool(true);
            playerAnimations.SetAttackAnimationFalse();
        }
        else
        {
            playerAnimations.SetFallingBool(false);
        }
    }

    private void Move()
    {
        moveInputX = Input.GetAxis(HORIZONTAL_AXIS);

        SetRunningAnimation();

        myRigidbody.velocity = new Vector2(moveInputX * horizontalSpeed, myRigidbody.velocity.y);
    }

    private void SetRunningAnimation()
    {
        if (Mathf.Abs(moveInputX) > 0)
        {
            ChangeStateToMoving();
            playerAnimations.SetRunningBool(true);
        }
        else
        {
            ChangeStateToIdle();
            playerAnimations.SetRunningBool(false);
        }
    }

    private void Jump()
    {   
        if(groundCheck.IsGrounded())
        {
            extraJumpsLeft = extraJumps;
            playerAnimations.StopJumpingAnimation();
        }
        if (Input.GetButtonDown(JUMP_KEY) && extraJumpsLeft > 0 &&
            ( moveState == PlayerMoveState.Idle || moveState == PlayerMoveState.Moving || moveState == PlayerMoveState.Falling ))
        {
            myRigidbody.velocity = Vector2.up * jumpSpeed;
            extraJumpsLeft--;
            playerAnimations.StartJumpingAnimation();
        }
    }

    private void ChangeSide()
    {
        if (facingRight == false && moveInputX > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInputX < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        if (groundCheck.IsGrounded())
        {
            playerAnimations.CreateDust();
        }
    }

    private void ChangeStateToMoving()
    {
        moveState = PlayerMoveState.Moving;
    }

    public void OnAttackStart()
    {
        moveState = PlayerMoveState.Attacking;
        myRigidbody.velocity = Vector2.zero;
    }

    public void OnAttackStop()
    {
        ChangeStateToIdle();
    }

    public bool IsPlayerGrounded()
    {
        return groundCheck.IsGrounded();
    }

    public void StartKnocback(Vector2 enemyPosition)
    {
        moveState = PlayerMoveState.Stagger;
        playerAnimations.SetFallingBool(false);
        Vector2 direction = new Vector2(transform.position.x - enemyPosition.x, transform.position.y - enemyPosition.y);
        ApplyKnockBack(direction);
    }

    private void ApplyKnockBack(Vector2 direction)
    {
        myRigidbody.velocity = direction * knocbackForce;
    }

    public void EndKnocback()
    {
        ChangeStateToIdle();
    }

    private void ChangeStateToIdle()
    {
        moveState = PlayerMoveState.Idle;
    }

    public float GetKnockbackTime()
    {
        return knockbackTime;
    }

    public void PlayerDead()
    {
        moveState = PlayerMoveState.Dead;
    }
}

enum PlayerMoveState
{
    Idle,
    Moving,
    Attacking,
    Falling,
    Stagger,
    Dead
}

