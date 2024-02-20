using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScenes : MonoBehaviour
{
    public static UIScenes Instance { get; private set; }
    //VARIABLES BUTTONS
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }

    //SCENES

    public void GotoPlayerPrefScene()
    {
        SceneManager.LoadScene("PlayerPref");
    }

    public void GotoLevelOneScene()
    {
        
        SceneManager.LoadScene("Level1");
    }

    public void GotoLevelTwoScene()
    {

        SceneManager.LoadScene("Level2");
    }

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
