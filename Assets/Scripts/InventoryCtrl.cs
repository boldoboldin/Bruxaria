using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl : IItemHolder
{
    public event EventHandler OnItemListChanged;
    
    private List<ItensCtrl> itensList;
    private Action<ItensCtrl> useItemAct;
    public InventorySlot[] inventorySlotArray;

    public InventoryCtrl(Action<ItensCtrl> useItemAct, int inventorySlotCount)
    {
        this.useItemAct = useItemAct;
        itensList = new List<ItensCtrl>();

        inventorySlotArray = new InventorySlot[inventorySlotCount];
        for (int i = 0; i < inventorySlotCount; i++)
        {
            inventorySlotArray[i] = new InventorySlot(i);
        }

        //AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Sapphire });
        //AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Ruby });
        //AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Emerald });
    }

    public InventorySlot GetEmptyInventorySlot()
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.IsEmpty())
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find an empty InventorySlot!");
        return null;
    }

    public InventorySlot GetInventorySlotWithItem(ItensCtrl item)
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.GetItem() == item)
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find Item " + item + " in a InventorySlot!");
        return null;
    }


    public void AddItem(ItensCtrl item)
    {
        //itensList.Add(item);
        //item.SetItemHolder(this);
        //GetEmptyInventorySlot().SetItem(item);
        //OnItemListChanged?.Invoke(this, EventArgs.Empty);
        AddItemMergeAmount(item);
    }

    public void AddItemMergeAmount(ItensCtrl item)
    {
        if (item.IsStackable())
        {
            bool itemAlredyInInventory = false;

            foreach (ItensCtrl inventory in itensList)
            {
                if (inventory.itemType == item.itemType)
                {
                    inventory.amount += item.amount;
                    itemAlredyInInventory = true;
                }
            }

            if (!itemAlredyInInventory)
            {
                itensList.Add(item);
                item.SetItemHolder(this);
                GetEmptyInventorySlot().SetItem(item);
            }
        }
        else
        {
            itensList.Add(item);
            item.SetItemHolder(this);
            GetEmptyInventorySlot().SetItem(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(ItensCtrl item)
    {
        GetInventorySlotWithItem(item).RemoveItem();
        itensList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItemRemoveAmount(ItensCtrl item)
    {
        if (item.IsStackable())
        {
            ItensCtrl itemInInventory = null;

            foreach (ItensCtrl inventory in itensList)
            {
                if (inventory.itemType == item.itemType)
                {
                    inventory.amount -= item.amount;
                    itemInInventory = inventory;
                }
            }

            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                GetInventorySlotWithItem(itemInInventory).RemoveItem();
                itensList.Remove(itemInInventory);
            }
        }
        else
        {
            GetInventorySlotWithItem(item).RemoveItem();
            itensList.Remove(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddItem(ItensCtrl item, InventorySlot inventorySlot)
    {
        // Add Item to a specific Inventory slot
        itensList.Add(item);
        item.SetItemHolder(this);
        inventorySlot.SetItem(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem (ItensCtrl item)
    {
        useItemAct(item);
    }

    public List<ItensCtrl> GetItemList()
    {
        return itensList;
    }

    public InventorySlot[] GetInventorySlotArray()
    {
        return inventorySlotArray;
    }

    public bool CanAddItem()
    {
        return GetEmptyInventorySlot() != null;
    }

    public class InventorySlot
    {

        private int index;
        private ItensCtrl item;

        public InventorySlot(int index)
        {
            this.index = index;
        }

        public ItensCtrl GetItem()
        {
            return item;
        }

        public void SetItem(ItensCtrl item)
        {
            this.item = item;
        }

        public void RemoveItem()
        {
            item = null;
        }

        public bool IsEmpty()
        {
            return item == null;
        }

    }
}