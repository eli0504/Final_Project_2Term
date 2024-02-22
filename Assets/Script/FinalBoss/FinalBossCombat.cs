using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossCombat : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public Transform player;

    private EnemyHealth enemyHealthBar;
    private float live;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

}
