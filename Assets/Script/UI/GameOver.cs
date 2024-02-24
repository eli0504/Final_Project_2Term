using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private PlayerController playerController;

    private float gameTime = 0f;
    private bool isGameOver = false;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        gameOverPanel.SetActive(false);
    }
    public void IsGameOver()
    {
     
        isGameOver = true;
        Time.timeScale = 0f; // Detener el tiempo
        gameOverPanel.SetActive(true);
        audioLibrary.PlaySound("gameOverSound");
    }
}
