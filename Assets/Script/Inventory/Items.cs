using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType
    {
        Sword,
        HealthPotion,
        Rock,
    }

    public ItemType itemType;
    public int amount;
}
