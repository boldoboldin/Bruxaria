using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Transform prefabUI_Item;
    
    private InventoryCtrl inventory;
    private Transform itemSlotContainer, itemSlot;

    public PlayerCtrl player;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlot = itemSlotContainer.Find("ItemSlot");
        itemSlot.gameObject.SetActive(false);
    }

    public void SetPlayer(PlayerCtrl player)
    {
        this.player = player;
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
        float itemSlotCellSize = 156f;

        foreach (InventoryCtrl.InventorySlot inventorySlot in inventory.GetInventorySlotArray())
        {
            ItensCtrl item = inventorySlot.GetItem();

            RectTransform itemSlotRectTransform = Instantiate(itemSlot, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<UI_Button>().ClickFunc = () =>
            {
                //inventory.UseItem(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(xPos * itemSlotCellSize, yPos);

            if (!inventorySlot.IsEmpty())
            {
                // Not Empty, has Item
                Transform uiItemTransform = Instantiate(prefabUI_Item, itemSlotContainer);
                uiItemTransform.GetComponent<RectTransform>().anchoredPosition = itemSlotRectTransform.anchoredPosition;
                UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
                uiItem.SetItem(item);
            }

            InventoryCtrl.InventorySlot tmpInventorySlot = inventorySlot;

            UI_ItemSlot uiItemSlot = itemSlotRectTransform.GetComponent<UI_ItemSlot>();
            uiItemSlot.SetOnDropAction(() => {

                ItensCtrl draggedItem = UI_ItemDrag.Instance.GetItem();
                draggedItem.RemoveFromItemHolder();
                inventory.AddItem(draggedItem, tmpInventorySlot);
            });

            
            int itemRowMax = 6;
            if (xPos <= itemRowMax)
            {
                xPos++;
            }
        }
    }
}
