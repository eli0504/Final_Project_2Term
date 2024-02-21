using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIPause : MonoBehaviour
{
    public static UIPause Instance { get; private set; }

    //VARIABLES
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;

    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button resumeButton;

    private void Awake()
    {
        //SINGLETON
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;

        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ResumeGame();
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
         
        });

        QuitPausePanel();
    }

    public void ShowPausePanel()
    {
        
       pausePanel.SetActive(true);
        
    }
    public void QuitPausePanel()
    {
        pausePanel.SetActive(false);
    }

    //SCENES
    public void GotoCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void GotoSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }
    public void GotoMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
