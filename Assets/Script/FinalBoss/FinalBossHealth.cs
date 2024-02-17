using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealth : MonoBehaviour
{
    public int health = 500;

    public bool isInvulnerable = false;

    //called when player hits
    public void TakeDamage(int damage)
    {
        if (isInvulnerable) //if we try to damage the boss and is invunerable just return out and dont do nothing
            return;

            health -= damage;
        

        if(health <= 200)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
