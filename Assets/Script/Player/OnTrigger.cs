using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OnTrigger : MonoBehaviour
{
    private Postprocessing postprocessing;
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
    private Health healthScript;

    private Animator anim;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider;
    public ParticleSystem boxParticles;

    private float verticalInput;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider2D>();
    }
    private void Start()
    {
        playerDataPersistence = GetComponent<PlayerDataPersistence>();
        postprocessing = GetComponent<Postprocessing>();
        gameOver = GetComponent<GameOver>();
        healthScript = GetComponent<Health>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //pass to level2
        if (other.gameObject.tag == "PassLevel")
        {
        
            SceneManager.LoadScene("Level2");
    
        }
        else if (other.gameObject.tag == "FinalBoss")
        {
            SceneManager.LoadScene("FinalBoss");
            Debug.Log("finalBoss");
        }

        //coins
        if (other.gameObject.tag == "coins")
        {
            audioLibrary.PlaySound("coin");
            Destroy(other.gameObject); //the collectable dissapear 
            coinsCounter++;
            coinsCounterText.text = $"{coinsCounter}";
        }

        //keys
        if (other.gameObject.tag == "keys")
        {
            audioLibrary.PlaySound("live");
            Destroy(other.gameObject); //the collectable dissapear 
            keysCounter++;
            keysCounterText.text = $"{keysCounter}";
        }else if((other.gameObject.tag == "goldKey"))
        {
            audioLibrary.PlaySound("live");
            Destroy(other.gameObject); //the collectable dissapear 
            keysCounter++;
            keysCounterText.text = $"{keysCounter}";
            Time.timeScale = 0f;
           // winPanel.SetActive(true);
        }

        //smallPowerUp
        if (other.gameObject.tag == "smallPowerUp")
        {
            audioLibrary.PlaySound("poison");
            transform.localScale = new Vector3(smallPowerUp, smallPowerUp, 0);
        }
        else if(other.gameObject.tag == "bigPowerUp")
        {
            audioLibrary.PlaySound("poison");
            transform.localScale = new Vector3(bigPowerUp, bigPowerUp, 0);
        }

        //Traps
        if (other.gameObject.tag == "traps")
        {
            // damageEffects.TakeDamageEffect();
         
            healthScript.GetDamage();
        }

        //box
        if (other.CompareTag("box"))
        {
            // Instancia el prefab en la posición del objeto trigger
            Instantiate(smallPotion, new Vector3(-6, -2, 0), Quaternion.identity);
            boxParticles.Stop();

        }
        else if (other.CompareTag("box2"))
        {
            Instantiate(bigPotion, new Vector3(12, -5, 0), Quaternion.identity);
            boxParticles.Stop();
        }

        //live
        if (other.CompareTag("live"))
        {
            audioLibrary.PlaySound("live");
            Health.lives++;
            Destroy(other.gameObject);
        }

        //edges
        if (other.CompareTag("Edge"))
        {
           transform.position = new Vector3 (-15f, -2.78f, 1f);
        }else if (other.CompareTag("Edge2"))
        {
            transform.position = new Vector3(152.7f, 5.23f, 1f);
        }
        
        /*
        //checkpoint
        if (other.CompareTag("CheckPoint"))
        {
            healthScript.GetDamage();
        }
        */

        

    }
}
