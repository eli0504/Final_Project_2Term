using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody2D;

    private Animator anim;

    private SpriteRenderer sprite;

    private float horizontalInput;
    private float moveSpeed = 10f;
    public float jumpSpeed = 25f;

    private float smallPowerUp = 0.5f;

    public TextMeshProUGUI counterText;
    private int Counter;

    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    private float gameTime = 0f;
    private bool isGameOver = false;
    public GameObject gameOverPanel;

    private int jumps = 0;
    public int maxJumps = 2;

    //INVENTORY
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private const string ITEM_TAG = "Item";

    private void Awake()
    {
        anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        boxCollider2D = GetComponentInChildren<BoxCollider2D>();

        inventory = new Inventory();
    }

    private void Start()
    {
        uiInventory.SetInventory(inventory);

        gameOverPanel.SetActive(false);
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


    public Vector3 GetPosition()
    {
        return transform.position;
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

        //INVENTORY
        if (other.gameObject.CompareTag(ITEM_TAG))
        {
            ItemWorld itemWorld = other.gameObject.GetComponent<ItemWorld>();
            inventory.AddItem(itemWorld.GetItem());
            Destroy(other.gameObject);
        }

        //Traps
        if (other.gameObject.tag == "traps")
        {
            GameOver();
        }


    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Detener el tiempo
        gameOverPanel.SetActive(true);
    }
    //ANIMATIONS
    private void Animations()
    {
       //Run
        if (horizontalInput > 0f) //right direction
        {
            anim.SetBool("running", true);
            //sprite.flipX = false; //for flip to the right direction
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0f) //left direction
        {
            anim.SetBool("running", true);
            // sprite.flipX = true;
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
