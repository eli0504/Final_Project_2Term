using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public static mainMenu Instance { get; private set; }

    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }

    public void GotoLevelOneScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GotoCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
