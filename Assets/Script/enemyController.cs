using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private chasing chasing;

    private GameOver gameOver;

    private Rigidbody2D rb;
    private Animator anim;

    public GameObject pointA;
    public GameObject pointB;

    private Transform currentPoint;
    public float speed;

    public Transform player;//player pos

    //chasing
    public GameObject playerPrefab;

    private float distance;
    private float maxChaseRadius = 5F;
    private float minChaseRadius = 3f;


    private void Start()
    {
        chasing = GetComponent<chasing>();
        gameOver = GetComponent<GameOver>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentPoint = pointB.transform; //initial start point
        anim.SetBool("run", true);


        playerPrefab = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
    }

    public void Patrol()
    {
        Vector2 direction = currentPoint.position - transform.position; //direction my enemy wants to go
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

    private void Chasing()
    {
        //chasing
        distance = Vector3.Distance(player.transform.position, transform.position); //estado
        if (distance <= maxChaseRadius && distance >= minChaseRadius) //campos
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); //move the enemy to the player 
        }
    }

    private void Attack()
    {
        if(player)
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
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

        //chasing
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxChaseRadius);
        //atttack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minChaseRadius);
    }

}
