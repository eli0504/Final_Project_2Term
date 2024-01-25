using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody2D;

    private Animator anim;

    private SpriteRenderer sprite;

    private float horizontalInput;
    private float moveSpeed = 10f;
    private float jumpSpeed = 9f;

    private int points;
    private float smallPowerUp = 0.5f;

    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    //INVENTORY
    private Inventory inventory;
    [SerializeField] private UI_Inventory ui_Inventory;
   
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
        //INVENTORY -> passing in the inventory object on to our UI script
        inventory = new Inventory();
        ui_Inventory.SetInventory(inventory);
    }

    private void Update()
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

        if (Input.GetKeyDown(KeyCode.Space) && !isOnTheGround)
        {
            anim.SetBool("fall", true);
            Debug.Log("NO POSSIBLE");
        }

        Animations();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * horizontalInput, rigidbody2D.velocity.y);
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
            points++;
        }

        //smallPowerUp
        if (other.gameObject.tag == "smallPowerUp")
        {
            player.transform.localScale = new Vector3(smallPowerUp, smallPowerUp, smallPowerUp);
        }
           
    }


    //ANIMATIONS
    private void Animations()
    {
       //Run
        if (horizontalInput > 0f) //right direction
        {
            anim.SetBool("running", true);
            sprite.flipX = false; //for flip to the right direction
        }
        else if (horizontalInput < 0f) //left direction
        {
            anim.SetBool("running", true);
            sprite.flipX = true; 
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
