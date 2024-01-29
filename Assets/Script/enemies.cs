using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class enemies : MonoBehaviour
{
    private float speed = 2f;
    public GameObject player;

    private float distance;

    private Animator anim;

    private void Update()
    {
        //distance between player and enemy
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //moves the enemy towards a given pos
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        direction.Normalize();

        EnemyChase();
    }

    private void EnemyChase()
    {
        //chase range
        if (distance < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    
}
