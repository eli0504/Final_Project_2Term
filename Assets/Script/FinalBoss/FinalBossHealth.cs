using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBossHealth : MonoBehaviour
{
    public Animator anim;

    public int maxHealth = 100;
    private float currentHealth;

    public Slider healthSlider;

    public float damageValue = 20f; //damage from th player

    private void Start()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        UpdateHealth();
    }

    //called when player hits
    public void TakeDamage()
    {
        // Reduzca la salud del enemigo cuando recibe daño
        currentHealth -= damageValue;

        // Asegúrate de que la salud no sea menor que cero
        currentHealth = Mathf.Max(currentHealth, 0f);

        // Actualiza la barra de vida
        UpdateHealth();

        // Verifica si el enemigo ha muerto
        if (currentHealth == 0f)
        {
            Die();
            anim.SetBool("isDead", true);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void UpdateHealth()
    {
        // Actualiza el valor del Slider
        healthSlider.value = currentHealth / maxHealth;
    }
}