using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameOver gameOver;

    public GameObject player;

    private Rigidbody2D rigidbody2D;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    private float horizontalInput;
    private float moveSpeed = 10f;
    

    //JUMP CONDITIONS
    public int jumpsMade = 0;
    public int maxJumps = 2;
    public float jumpSpeed = 10f;

    private float xMinRange = -38f;
    private float xMaxRange = 7f; //límite pantalla horizontal

    private void Awake()
    {
        anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        boxCollider2D = GetComponentInChildren<BoxCollider2D>();
    }

    private void Start()
    {
        gameOver = GetComponent<GameOver>();

    }

    private void Update()
    {
        RunAnim();

                //JUMP
                horizontalInput = Input.GetAxis("Horizontal");
                //bool isOnTheGround = IsOnTheGround();

                if (Input.GetKeyDown(KeyCode.Space) && (IsOnTheGround() || jumpsMade < maxJumps))
                {
                    rigidbody2D.velocity = Vector2.up * jumpSpeed;
                    anim.SetTrigger("jump");
                    jumpsMade++;
        
                }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * horizontalInput, rigidbody2D.velocity.y);
    }


    private bool IsOnTheGround()
    {

        float extraHeight = 0.025f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center,
                                                        Vector2.down,
                                                        boxCollider2D.bounds.extents.y + extraHeight,
                                                        groundLayerMask);
        bool isOnTheGround = raycastHit2D.collider != null;//comprobacion
     
        if (isOnTheGround)
        {
            jumpsMade = 0;
        }//operador ternario (if else)
        Debug.Log(jumpsMade);

        //visualice raycast
        Color raycatHitColor = isOnTheGround ? Color.green : Color.red;
        Debug.DrawRay(boxCollider2D.bounds.center,
                        Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight),
                        raycatHitColor);

        return isOnTheGround;


    }

    /*private void PlayerInBounds()
    {
        Vector2 pos = transform.position;
        if (pos.x < -xRange)
        {
            transform.position = new Vector3(-xRange, pos.y);
        }

        if (pos.x > xRange)
        {
            transform.position = new Vector3(xRange, pos.y);
        }
    }*/


    private void RunAnim()
    {
       //Run
        if (horizontalInput > 0f) //right direction
        {
            anim.SetBool("running", true);
            transform.rotation = Quaternion.identity;
        }
        else if (horizontalInput < 0f) //left direction
        {
            anim.SetBool("running", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            anim.SetBool("running", false);
        } 
    }
}
