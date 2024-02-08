using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OnTrigger : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int Counter;

    public GameObject player;

    private float smallPowerUp = 0.5f;

    private GameOver gameOver;

    private bool inStairs = false;

    private Animator anim;

    public GameObject potion;

    private void Start()
    {
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

        //stairs
        if (other.CompareTag("stairs"))
        {
            inStairs = true;
            anim.SetBool("ladder", true);
        }

        //edges
        if (other.CompareTag("Edge"))
        {
            gameOver.IsGameOver();
        }

        //box
        if (other.CompareTag("box"))
        {
            // Instancia el prefab en la posición del objeto trigger
            Instantiate(potion, new Vector3(-6, -2, 0), Quaternion.identity);

            // Puedes agregar más lógica aquí si es necesario
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("stairs"))
        {
            inStairs = false;
            anim.SetBool("ladder", false);
        }
    }
}
