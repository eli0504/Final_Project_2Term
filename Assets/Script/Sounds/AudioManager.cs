using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    public TextMeshProUGUI volumeTextUI = null;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeValue"))
        {
            PlayerPrefs.SetFloat("VolumeValue", 1);
        }
        else
        {
            LoadValues();
        }
   
    }

    public void ChangeSoundVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolumeButton();
    }

    public void SaveVolumeButton()
    {
        PlayerPrefs.SetFloat("VolumeValue", volumeSlider.value);
        LoadValues();
    }

    public void LoadValues()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeValue");
    }
}
