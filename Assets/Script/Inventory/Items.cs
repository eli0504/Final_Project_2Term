using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType
    {
        Sword,
        HealthPotion,
        Coin,
        Apple,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Sword: return ItemAssets.Instance.swordSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.HealthPotionSprite;
            case ItemType.Coin: return ItemAssets.Instance.CoinSprite;
            case ItemType.Apple: return ItemAssets.Instance.AppleSprite;
        }
    }
}
