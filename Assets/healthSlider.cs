using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeActualHealth(float healthAmount)
    {
        slider.value = healthAmount;
    }
    public void InicialiceHealthSlider(float healthAmount)
    {
        ChangeMaxHealth(healthAmount);
        ChangeActualHealth(healthAmount);
    }

}
