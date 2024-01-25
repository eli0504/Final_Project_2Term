using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;

    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;


    private void Awake()
    {
        //REFERENCES
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = transform.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    //cycle through all the items in the inventory
    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        foreach(Items item in inventory.GetItemsList())
        {
            //instantiate our container
            if(itemSlotTemplate != null)
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true); //enable our container
                                                                  //container pos
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                x++;
                if (x > 4)
                {
                    x = 0;
                    y++;
                }
            }
            else
            {
                Debug.Log("the item slot template is null");
            }     
        }
    }

}
