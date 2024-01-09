using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerOptions : MonoBehaviour
{
    public static UIManagerOptions sharedInstance;

    public static string PLAYER_USERNAME = "playerUsername";
    [SerializeField] private TMP_InputField usernameInputField;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

        private void Start()
    {
        // Configuramos el nombre de usuario del player
        ShowPlayerUsername();

    }

    public void ChangeUsername()
    {
        string username = usernameInputField.text;

        if (username != "")
        {
            // Guardamos el nombre de usuario en PlayerPrefs
            PlayerPrefs.SetString(PLAYER_USERNAME, username);
        }
    }

    private void ShowPlayerUsername()
    {
        string username;
        if (PlayerPrefs.HasKey(PLAYER_USERNAME))
        {
            username = PlayerPrefs.GetString(PLAYER_USERNAME);
        }
        else
        {
            username = "ENTER USERNAME";
        }

        usernameInputField.placeholder.GetComponent<TextMeshProUGUI>().text = username;
    }
}
