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

    private float horizontalInput;
    private float moveSpeed = 10f;

    private float smallPowerUp = 0.5f;

    public TextMeshProUGUI counterText;
    private int Counter;

    private EdgeCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    public float jumpSpeed = 25f;


    private void Awake()
    {
        anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        boxCollider2D = GetComponentInChildren<EdgeCollider2D>();
    }

    private void Start()
    {
        gameOver = GetComponent<GameOver>();
    }

    private void Update()
    {
        Jump();

        Animations();

    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * horizontalInput, rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        //JUMP
        horizontalInput = Input.GetAxis("Horizontal");


        bool isOnTheGround = IsOnTheGround();
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            rigidbody2D.velocity = Vector2.up * jumpSpeed;
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }

    private bool IsOnTheGround()
    {
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(boxCollider2D.bounds.center,
                                                       Vector2.down,
                                                      boxCollider2D.bounds.extents.y + extraHeight,
                                                      groundLayerMask);
        bool isOnTheGround = raycastHit2D.collider != null;

        //visualice raycast
        Color raycatHitColor = isOnTheGround ? Color.green : Color.red;
        Debug.DrawRay(boxCollider2D.bounds.center,
                      Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight),
                      raycatHitColor);

        return isOnTheGround;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //pass to level2
        if (other.gameObject.tag == "PassLevel")
        {
            SceneManager.LoadScene("Level2");
            Debug.Log("You will pass to the next level!");
        }
        else if(other.gameObject.tag == "secretRoom")
        {
            SceneManager.LoadScene("SecretRoomLevel1");
        }

       //coins
        if (other.gameObject.tag == "coins")
        {
            Destroy(other.gameObject); //the collectable dissapear 
            Counter++;
            counterText.text = $"{Counter}";
        }

        //smallPowerUp
          if (other.gameObject.tag == "smallPowerUp")
        {
            player.transform.localScale = new Vector3(smallPowerUp, smallPowerUp, smallPowerUp);
        }

        //Traps
        if (other.gameObject.tag == "traps")
        {
            gameOver.IsGameOver();
        }
    }


    //ANIMATIONS
    private void Animations()
    {
       //Run
        if (horizontalInput > 0f) //right direction
        {
            anim.SetBool("running", true);
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0f) //left direction
        {
            anim.SetBool("running", true);
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            anim.SetBool("running", false);
        }

        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }
}
