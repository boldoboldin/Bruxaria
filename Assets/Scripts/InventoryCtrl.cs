using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl
{
    public event EventHandler OnItemListChanged;
    
    private List<ItensCtrl> itensList;

    public InventoryCtrl()
    {
        itensList = new List<ItensCtrl>();

        AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Ruby, amount = 1 });
        AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Sapphire, amount = 1 });
        AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Emerald, amount = 1 });
    }

    public void AddItem(ItensCtrl item)
    {
        itensList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItensCtrl> GetItemList()
    {
        return itensList;
    }
}
