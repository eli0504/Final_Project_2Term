using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossCombat : MonoBehaviour
{
<<<<<<< HEAD
    private Animator animator;
    public Rigidbody2D rb;
    public Transform player;

    private EnemyHealth enemyHealthBar;
    private float live;

    [SerializeField] Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;

    private void Update()
    {
        float playerDistance = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("player_distance", playerDistance);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Attack()
    {

    }
=======
    
>>>>>>> parent of 23f4b3f (newboss)
}
