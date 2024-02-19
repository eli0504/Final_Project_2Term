using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    


    private Rigidbody2D rb;
    private Animator anim;

    public Transform pointA;
    public Transform pointB;

    private Transform currentPoint;
    public float speed = 5;


    public Transform player;//player pos


    private float distance;
    private float chaseRadius = 5f;
    private float attackRadius = 2f;
    //attack
    private float lastAttackTime;
    public float attackCooldown = 1.0f;  // Tiempo de espera entre ataques

    public int damage;
    public int health;
    public Slider healthbar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    private void Start()
    {
       
        currentPoint = pointB; //initial start point
        anim.SetBool("run", true);
    }

    private void Update()
    {
      //  healthbar.value = health;

        distance = Vector3.Distance(player.position, transform.position);

        if (distance > chaseRadius)
        {
            Patrol();  
        }
        else if(distance > attackRadius)
        {
            Chasing();   
        }
        else
        {
            Attack();  // Si el jugador está dentro del rango de ataque, ataca.
        }
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
        
    }

    public void Patrol()
    {
        anim.SetBool("run", true);
        //if enemy reach the current point
        if (Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointB)
        {
             
            currentPoint = pointA;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointA)
        {
            transform.rotation = Quaternion.identity;
            currentPoint = pointB;
          
        } else if (currentPoint == player)
        {
            transform.rotation = Quaternion.identity;
            currentPoint = pointB;
        }
    }

    private void Chasing()
    {
        anim.SetBool("run", true);
        LookAtPlayer();
        currentPoint = player;
        //chasing
        //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //move the enemy to the player 
        
    }

    private void Attack()
    {
       
        LookAtPlayer();
        currentPoint = transform; //se queda en el sitio a atacar
        anim.SetBool("run", false);
        anim.SetTrigger("attack");

        //if (Time.time - lastAttackTime > attackCooldown) //el enemigo puede realizar otro ataque
        //{
        //       // Flip();
        //        anim.SetBool("run", false);
        //        anim.SetTrigger("attack");
        //        lastAttackTime = Time.time;  // Actualiza el tiempo del último ataque
        //}
        //else
        //{
        //    //Flip();
        //    anim.SetBool("run", true);
        //    lastAttackTime = Time.time;
        //}
    }

    private void LookAtPlayer()
    {
       Vector2 directionToPlayer = player.position - transform.position;
        Debug.Log("flipping");
       if(directionToPlayer.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    //visual
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.position, 0.5f);

        //chasing
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        //atttack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
