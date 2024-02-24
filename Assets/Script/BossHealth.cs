using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Animator anim;

    public int maxHealth = 100;
    private float currentHealth;

    public Slider healthSlider;

    public float damageValue = 20f; //damage from th player

    public GameObject keyPrefab;



    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        UpdateHealth();
    }

    public void TakeDamage()
    {
        // Reduzca la salud del enemigo cuando recibe daño
        currentHealth -= damageValue;
        // Asegúrate de que la salud no sea menor que cero
        currentHealth = Mathf.Max(currentHealth, 0f);
        // Actualiza la barra de vida
        UpdateHealth();

        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Died();
            anim.SetBool("isDead", true);
            Instantiate(keyPrefab, transform.position, Quaternion.identity);
        }
    }

    private void Died()
    {
        Debug.Log("Enemy died!");

        anim.SetBool("isDead", true);

        Destroy(gameObject);

    }

    void UpdateHealth()
    {
        // Actualiza el valor del Slider
        healthSlider.value = currentHealth / maxHealth;
    }
}
