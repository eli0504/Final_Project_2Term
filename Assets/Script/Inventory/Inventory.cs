using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Items> itemList;

    public Inventory()
    {
        itemList = new List<Items>();
       
        //display the items
        AddItem(new Items { itemType = Items.ItemType.Sword, amount = 1 });
        AddItem(new Items { itemType = Items.ItemType.HealthPotion, amount = 1 });
        AddItem(new Items { itemType = Items.ItemType.Coin, amount = 1 });

        Debug.Log(itemList.Count);
    }

    //Add items to our list 
    public void AddItem(Items item)
    {
        itemList.Add(item);
    }

    public List<Items> GetItemsList()
    { 
        return itemList;
    }
}
