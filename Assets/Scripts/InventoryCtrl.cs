using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl
{
    public event EventHandler OnItemListChanged;
    
    private List<ItensCtrl> itensList;
    private Action<ItensCtrl> useItemAct;

    public InventoryCtrl(Action<ItensCtrl> useItemAct)
    {
        this.useItemAct = useItemAct;
        itensList = new List<ItensCtrl>();
    }

    public void AddItem(ItensCtrl item)
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
            }
        }
        else
        {
            itensList.Add(item);
        }
       
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(ItensCtrl item)
    {
        itensList.Remove(item);
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
}
