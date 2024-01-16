using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isPaused;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        // Lógica de Pause con tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        UIPause.Instance.ShowPausePanel();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        UIPause.Instance.QuitPausePanel();
        isPaused = false;
    }
}
