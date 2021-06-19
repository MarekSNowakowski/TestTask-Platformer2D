using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrollingEnemyMovement : MonoBehaviour
{   
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform[] path;

    private Vector3 position;
    private Transform currentGoal;
    private int currentPoint;
    private bool facingRight = true;
    private float directionX;

    public readonly float ROUNDING_DISTANCE = 0.01f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeGoal();
    }

    private void FixedUpdate()
    {
        MoveAlongThePath();
    }

    private void MoveAlongThePath()
    {
        if (Vector3.Distance(transform.position, path[currentPoint].position) > ROUNDING_DISTANCE)
        {
            position = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(position);
        }
        else
        {
            ChangeGoal();
        }
    }

    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }

        directionX = transform.position.x - currentGoal.position.x;
        CheckFlip(directionX);
    }

    private void CheckFlip(float directionX)
    {
        if (facingRight == false && directionX < 0)
        {
            Flip();
        }
        else if (facingRight == true && directionX > 0)
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
