using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OnTrigger : MonoBehaviour
{
    private DamageEffects damageEffects;
    private PlayerDataPersistence playerDataPersistence;
    public TextMeshProUGUI coinsCounterText;
    public TextMeshProUGUI keysCounterText;

    public GameObject player;
    public GameObject bigPotion;
    public GameObject smallPotion;
    public GameObject heart;

    public float speed = 25f;
    public float stairsSpeed = 5f;
    private float smallPowerUp = 0.3f;
    private float bigPowerUp = 1f;
    private int coinsCounter;
    private int keysCounter;

    private GameOver gameOver;
    private Animator anim;

    private Rigidbody2D rigidbody2D;

    private float verticalInput;
    private void Awake()
    {
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        playerDataPersistence = GetComponent<PlayerDataPersistence>();
        damageEffects = GetComponent<DamageEffects>();
        gameOver = GetComponent<GameOver>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //pass to level2
        if (other.gameObject.tag == "PassLevel")
        {
        
            SceneManager.LoadScene("Level2");
            Debug.Log("You will pass to the next level!");
        }
        else if (other.gameObject.tag == "secretRoom")
        {
            SceneManager.LoadScene("SecretRoomLevel1");
        }
        else if (other.gameObject.tag == "FinalBoss")
        {
            SceneManager.LoadScene("FinalBoss");
            Debug.Log("finalBoss");
        }

        //coins
        if (other.gameObject.tag == "coins")
        {
            Destroy(other.gameObject); //the collectable dissapear 
            coinsCounter++;
            coinsCounterText.text = $"{coinsCounter}";
        }

        //keys
        if (other.gameObject.tag == "keys")
        {
            Destroy(other.gameObject); //the collectable dissapear 
            keysCounter++;
            keysCounterText.text = $"{keysCounter}";
        }

        //smallPowerUp
        if (other.gameObject.tag == "smallPowerUp")
        {
            player.transform.localScale = new Vector3(smallPowerUp, smallPowerUp, 0);
        }else if(other.gameObject.tag == "bigPowerUp")
        {
            player.transform.localScale = new Vector3(bigPowerUp, bigPowerUp, 0);
        }

        //Traps
        if (other.gameObject.tag == "traps")
        {
            Health.lives--;
           // damageEffects.TakeDamageEffect();
   
            if (Health.lives <= 0)
            {
                gameOver.IsGameOver();
                gameObject.SetActive(true);
            }
        }

      
       /* //edges
        if (other.CompareTag("Edge"))
        {
            gameOver.IsGameOver();
        }*/

        //box
        if (other.CompareTag("box"))
        {
            // Instancia el prefab en la posición del objeto trigger
            Instantiate(smallPotion, new Vector3(-6, -2, 0), Quaternion.identity);

        }else if (other.CompareTag("box2"))
        {
            Instantiate(bigPotion, new Vector3(12, -5, 0), Quaternion.identity);
        }

        //live
        if (other.CompareTag("live"))
        {
            Health.lives++;
            Destroy(heart);
        }


        /*//ENEMIES
        if (other.CompareTag("enemy"))
        {
            Health.lives--;
            if(Health.lives <= 0)
            {
                gameOver.IsGameOver();
                gameObject.SetActive(true);
            }
        }*/
    }


    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //stairs
        if (other.CompareTag("stairs") && verticalInput > 0) // Verifica si el jugador está en las escaleras
        {
            rigidbody2D.velocity = new Vector2(0, stairsSpeed * verticalInput);
            anim.SetBool("ladder", true);
        }
        else
        {
            anim.SetBool("ladder", false);
        }

    }
}
