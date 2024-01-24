using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody2D;

    private float horizontalInput;
    private float moveSpeed = 10f;
    private float jumpSpeed = 9f;

    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayerMask;

    //INVENTORY
    private Inventory inventory;
    [SerializeField] private UI_Inventory ui_Inventory;
   
    private void Awake()
    {
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
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * horizontalInput, rigidbody2D.velocity.y);
    }

    private bool IsOnTheGround()
    {
        /*Color raycatHitColor;
        if (raycatHitColor.collider != null)
        {
            raycatHitColor = Color.green;
        }
        else
        {
            raycatHitColor = Color.red;
        }
        */


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

   /* private void PassLevel()
    {
        if(collision.gameObject.tag == "PassLevel")
        {
            SceneManager.LoadScene("Level2");
        }
    }
   */
}
