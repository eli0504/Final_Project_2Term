using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLibrary : MonoBehaviour
{
    public static AudioClip hurtSound, coinSound, enemySound, attackSound, poisonSound, gameOverSound, generalSound;
    static AudioSource audioSource;

    void Start()
    {
        hurtSound = Resources.Load<AudioClip>("general");
        hurtSound = Resources.Load<AudioClip>("hurt");
        coinSound = Resources.Load<AudioClip>("coin");
        enemySound = Resources.Load<AudioClip>("enemy");
        attackSound = Resources.Load<AudioClip>("attack");
        poisonSound = Resources.Load<AudioClip>("poison");
        gameOverSound = Resources.Load<AudioClip>("gameOverSound");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hurt":
                audioSource.PlayOneShot(hurtSound);
                    break;
            case "coin":
                audioSource.PlayOneShot(coinSound);
                break;
            case "enemy":
                audioSource.PlayOneShot(enemySound);
                break;
            case "attack":
                audioSource.PlayOneShot(attackSound);
                break;
            case "poison":
                audioSource.PlayOneShot(poisonSound);
                break;
            case "gameOverSound":
                audioSource.PlayOneShot(gameOverSound);
                break;
            case "general":
                audioSource.PlayOneShot(generalSound);
                break;
        }
    }
}
