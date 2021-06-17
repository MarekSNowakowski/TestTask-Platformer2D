using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask ground;

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, checkRadius, ground);
    }
}
