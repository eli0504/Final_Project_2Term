using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private PlayerController player;

    [SerializeField] private Transform itemsContainerTransform;

    private void Awake()
    {
        HideAllItems();
    }

   private void Start()
    {
        player = FindObjectOfType<PlayerController>(); //connection script
    }

    private void OnDisable()
    {
        inventory.OnItemListChanged -= Inventory_OnItemListChanged;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged()
    {
        RefreshItems();
    }

    //All the children of the container are hiding
    private void HideAllItems()
    {
        foreach (Transform child in itemsContainerTransform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void RefreshItems() //ENABLE THE CHILD OF THE ITEM CONTAINER
    {
        HideAllItems();
        //Go throught the items List
        List<Items> itemsList = inventory.GetItemsList();
        for (int i = 0; i < itemsList.Count; i++)
        {
            Items item = itemsList[i];

            Transform itemSlotTemplate = itemsContainerTransform.GetChild(i);
            itemSlotTemplate.gameObject.SetActive(true);  //active the items in the grid

            SetUpItemSlot(item, itemSlotTemplate); //show the image of the item
        }
    }

    private void SetUpItemSlot(Items item, Transform itemSlotTemplate)
    {
        Image itemImage = itemSlotTemplate.Find("Item Image").GetComponent<Image>();
        itemImage.sprite = item.GetSprite(); //show the image of item

        TextMeshProUGUI amountText = itemSlotTemplate.Find("Amount Text").GetComponent<TextMeshProUGUI>(); //number of items in grid
        amountText.text = item.amount > 1 ? item.amount.ToString() : "";

        SetUpItemButtonsAction(item, itemSlotTemplate);
    }

    private void SetUpItemButtonAction(Items item, Transform itemSlotTemplate)
    {
        Button button = itemSlotTemplate.GetComponent<Button>();
        button.onClick.RemoveAllListeners(); //remove the item from the grid

        button.onClick.AddListener(() =>
        {
            Debug.Log("Click");

            Items duplicateItem = new Items { itemType = item.itemType, amount = item.amount };
            inventory.RemoveItem(item);
            ItemWorld.DropItem(player.GetPosition(), duplicateItem);
        });
    }

    //LEFT AND RIGHT CLICK
    private void SetUpItemButtonsAction(Items item, Transform itemSlotTemplate)
    {
        ClickableObject clickableObject = itemSlotTemplate.GetComponent<ClickableObject>();
        clickableObject.SetUpLeftButtonAction(() =>
        {
            //leave the items on stage
            Items duplicateItem = new Items { itemType = item.itemType, amount = item.amount };
            inventory.RemoveItem(item);
            ItemWorld.DropItem(player.GetPosition(), duplicateItem);
        });
       // clickableObject.SetUpRightButtonAction(() => Debug.Log("Right"));
    }
}
