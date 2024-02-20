using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Health : MonoBehaviour
{
    public float intensity = 0f;
    //PostProcessVolume volume;
    Vignette vignette;

    private GameOver gameOver;

    public static int lives = 3;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        gameOver = GetComponent<GameOver>();
    }

    private void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(lives > numberOfHearts)
            {
                lives = numberOfHearts;
            }

            if(i < lives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void GetDamage()
    {
        Health.lives--;
        if (Health.lives <= 0)
        {
            gameOver.IsGameOver();
            gameObject.SetActive(true);
        }
    }

}
