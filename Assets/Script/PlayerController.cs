using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private float horizontalInput;
    private float moveSpeed = 10f;
    private float jumpSpeed = 8f;

    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        boxCollider2D = GetComponentInChildren<BoxCollider2D>();
    }

    private void Update()
    {
        //jump
        //horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * jumpSpeed;
        }
    }

    private void FixedUpdate()
    {
        //left direction
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
        }
        else
        {     //right direction
            if (Input.GetKeyDown(KeyCode.D))
            {
                rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
            }
        }       
    }

    private bool IsGrounded()
    {
        Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y);
    }
}
