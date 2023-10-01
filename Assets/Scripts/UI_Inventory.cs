using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    public PlayerCtrl player;
    
    private InventoryCtrl inventory;
    private Transform itemSlotContainer, itemSlot;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlot = itemSlotContainer.Find("ItemSlot");
    }

    public void SetInventory(InventoryCtrl inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventory();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlot) continue;
            Destroy(child.gameObject);
        }
        
        int xPos = 0;
        int yPos = 0;
        float itemSLotCellSize = 156f;
        
        foreach (ItensCtrl item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<UI_Button>().ClickFunc = () =>
            {
                inventory.UseItem(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(xPos * itemSLotCellSize, yPos);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
            

            if (xPos <= 6)
            {
                xPos++;
                player.canCollect = true;
            }
            
            if (xPos > 6)
            {
                player.canCollect = false;
            }
        }
    }
}
