using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.U2D;

public class enemy : MonoBehaviour
{
    [SerializeField] private Transform player;

    private float speed = 2f;

    private float distance;

    private Animator anim;

    private bool playerInVisionRange;
    private bool playerInAttackRange;

    // PATROL

    [SerializeField] private Transform[] waypoints; // Las localizaciones donde hara un recorrido de patrulla
    private int totalWaypoints;
    [SerializeField] private int nextPoint;

    //ATTACK

    private float timeBetweenAttacks = 2f;
    private bool canAttack;

    private void Start()
    {
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
        canAttack = false;
    }


    private void Update() // Se movera hacia el destino
    {
            //distance between player and enemy
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            //moves the enemy towards a given pos
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            direction.Normalize();

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
        if (Vector2.Distance(transform.position, waypoints[nextPoint].position) < 2.5f)
        {
            nextPoint++;

            if (nextPoint == totalWaypoints)
            {
                nextPoint = 0;
            }

            transform.LookAt(waypoints[nextPoint].position);
        }
    }

    private void Chase()
    {
        anim.SetBool("Run", true);

        transform.LookAt(player);
        if (distance < 3)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(AttackCoolDown());

            anim.SetBool("Attack", true);
        }
    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }
}
