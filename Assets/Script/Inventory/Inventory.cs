using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Items> itemList;

    public event Action OnItemListChanged;

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

        if (item.IsStackable())
        {
            //check if the item is in the inventory
            bool itemInInventory = false;
            foreach (Items inventoryItem in itemList)
            {
                if (item.itemType == inventoryItem.itemType)
                {
                    itemInInventory = true;
                    inventoryItem.amount += item.amount;
                }
            }
            if (!itemInInventory) { itemList.Add(item); }
        }
        else
        {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke();
    }

    public void RemoveItem(Items item)
    {
        if (item.IsStackable())
        {
            Items itemInInventory = null;
            foreach (Items inventoryItem in itemList)
            {
                if (item.itemType == inventoryItem.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }

        OnItemListChanged?.Invoke();
    }


    public List<Items> GetItemsList()
    { 
        return itemList;
    }
}
