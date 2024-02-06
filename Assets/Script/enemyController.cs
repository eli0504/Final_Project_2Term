using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private GameOver gameOver;

    private Rigidbody2D rb;
    private Animator anim;

    public GameObject pointA;
    public GameObject pointB;

    private Transform currentPoint;
    public float speed;

    public Transform player;//player pos

    private void Start()
    {
        gameOver = GetComponent<GameOver>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentPoint = pointB.transform; //initial start point
        anim.SetBool("run", true);
    }

    private void Update()
    {
            Patrol();
    }

    private void Patrol()
    {
        Vector2 point = currentPoint.position - transform.position; //direction my enemy wants to go
        //go to direction A to B
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        //if enemy reach the current point
        if (Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //visual
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    }

}
