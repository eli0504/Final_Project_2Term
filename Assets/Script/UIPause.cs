using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    public static UIPause Instance { get; private set; }

    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button resumeButton;

    private void Awake()
    {
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
            Loader.Load(Loader.Scene.MainMenu);
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
