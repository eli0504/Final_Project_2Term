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
       /* if (!PlayerPrefs.HasKey("VolumeValue"))
        {
            PlayerPrefs.SetFloat("VolumeValue", 1);
        }
        else
        {
           
        }*/
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void ChangeSoundVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolumeButton();
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
