using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
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

        inventory.OnItemListChanged += InventoryCtrl_OnItemListChanged;
        RefreshInventory();
    }

    private void InventoryCtrl_OnItemListChanged(object sender, System.EventArgs e)
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
        float itemSLotCellSize = 182f;
        
        foreach (ItensCtrl item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTranform = Instantiate(itemSlot, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTranform.gameObject.SetActive(true);

            itemSlotRectTranform.anchoredPosition = new Vector2(xPos * itemSLotCellSize, yPos);
            Image image = itemSlotRectTranform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            xPos++;
        }
    }
}
