using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing : MonoBehaviour
{
    private enemyController enemyController;

    public GameObject player;
    public float speed;

    private float distance;
    public float maxChaseRadius;
    public float minChaseRadius;

    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        enemyController = GetComponent<enemyController>();
    }


    void Update()
    {
        //chasing
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= maxChaseRadius && distance >= minChaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); //move the enemy to the player 
            anim.SetBool("attack", true);
        }
        else
        {
            enemyController.Patrol();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxChaseRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minChaseRadius);
    }
}
