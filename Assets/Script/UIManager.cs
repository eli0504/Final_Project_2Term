using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;

    [SerializeField] private TextMeshProUGUI usernameText;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    private void Start()
    {
        SetUserName();
    }

    private void SetUserName()
    {
        string username;
        if (PlayerPrefs.HasKey(UIManagerOptions.PLAYER_USERNAME))
        {
            username = PlayerPrefs.GetString(UIManagerOptions.PLAYER_USERNAME);
        }
        else
        {
            username = "Guest";
        }

        usernameText.text = username;
    }
}
