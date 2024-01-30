using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    private Items item;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI amountText;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // spawn items in the scenery
    public static ItemWorld SpawnItemWorld(Vector3 position, Items item)
    {
        Transform itemTransform = Instantiate(ItemAssets.Instance.itemWorldPrefab, position, Quaternion.identity);

        ItemWorld itemWorld = itemTransform.GetComponent<ItemWorld>();
        itemWorld.SetUpItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Items item)
    {
        Vector3 randomDirection = new Vector3(0, 2);

        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDirection, item);
        return itemWorld;
    }

    public Items GetItem()
    {
        return item;
    }


    private void SetUpItem(Items item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        amountText.text = item.amount > 1 ? item.amount.ToString() : "";
    }

    //For destroy the gameobject in the scene wen you get the item
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
