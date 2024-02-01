using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverPanel;
    [SerializeField] private PlayerController _playerController;

    private float gameTime = 0f;
    private bool isGameOver = false;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();

        gameOverPanel.SetActive(false);
    }

    public void PlayerDied()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Detener el tiempo
        gameOverPanel.SetActive(true);
    }
}
