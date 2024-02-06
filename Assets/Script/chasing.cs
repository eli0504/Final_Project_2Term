using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing : MonoBehaviour
{

    public GameObject player;
    public float speed;

    private float distance;
    public float maxChaseRadius;
    public float minChaseRadius;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        //chasing
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= maxChaseRadius && distance >= minChaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); //move the enemy to the player 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxChaseRadius);
    }
}
