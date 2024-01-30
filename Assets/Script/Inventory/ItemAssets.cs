using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
   public static ItemAssets Instance {  get; private set; }

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }

    public Transform itemWorldPrefab;

    //Assets
    public Sprite swordSprite;
    public Sprite CoinSprite;
    public Sprite AppleSprite;
    public Sprite HealthPotionSprite;
}
