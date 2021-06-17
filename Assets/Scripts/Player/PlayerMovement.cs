using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
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

    private readonly string HORIZONTAL_AXIS = "Horizontal";
    private readonly string JUMP_KEY = "Jump";

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        ChangeSide();
    }

    private void Update()
    {
        Jump();
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
            playerAnimations.SetRunningBool(true);
        }
        else
        {
            playerAnimations.SetRunningBool(false);
        }
    }

    private void Jump()
    {   
        if(groundCheck.IsGrounded())
        {
            extraJumpsLeft = extraJumps;
        }
        if (Input.GetButtonDown(JUMP_KEY) && extraJumpsLeft > 0)
        {
            myRigidbody.velocity = Vector2.up * jumpSpeed;
            extraJumpsLeft--;
            playerAnimations.SetJumpingBool(true);
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
    }
}
