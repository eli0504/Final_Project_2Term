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
    public bool isChasing;
    public float ChaseDistance; //how close you can get before the enemy chases the player

    private bool canAttack;
    private float timeBetweenAttacks = 2f;

    private float visionRange = 3.5f;
    private float attackRange = 2f;
    [SerializeField] private bool playerInVisionRange;
    [SerializeField] private bool playerInAttackRange;

    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        gameOver = GetComponent<GameOver>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform; //initial start point
        anim.SetBool("run", true);

        canAttack = false;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        playerInVisionRange = Physics.CheckSphere(pos, visionRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(pos, attackRange, playerLayer);
        if (!playerInVisionRange && !playerInAttackRange)
        {
            Patrol();
        }
        if (playerInVisionRange && !playerInAttackRange)
        {
            Chase();
        }
        if (playerInVisionRange && playerInAttackRange)
        {
            Attack();
        }
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

    private void Chase()
    {
        if (isChasing)
        {
            transform.LookAt(player);

            if (transform.position.x > player.position.x)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < player.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (transform.position.x == player.position.x)
            {
                AttackCoolDown();
            }

        }
        else
        {
            //check if the player is closer
            if (Vector2.Distance(transform.position, player.position) < ChaseDistance)
            {
                isChasing = true;

            }

            Patrol();
        }
    }

    private void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCoolDown());
        }
    }
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
        anim.SetBool("attack", true);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //pass to level2
        if (other.gameObject.tag == "Player")
        {
            gameOver.IsGameOver();
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

        // Esfera de visi�n
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);
        // Esfera de ataque
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
